using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AppMobileBackEnd.DbContexts;
using AppMobileBackEnd.Dtos.Account;
using AppMobileBackEnd.Dtos.Artist;
using AppMobileBackEnd.Entity;
using AppMobileBackEnd.Services.Implements;
using AppMobileBackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace AppMobileBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        private readonly IAccountServices _accountServices;
        private readonly ApplicationMyDBContext _context;
        private readonly AppSetting _appSetting;

        public AccountController(
            ApplicationMyDBContext context,
            IOptionsMonitor<AppSetting> optionsMonitor,
            IAccountServices accountServices,
            ILogger<AccountController> logger
        )
            : base(logger)
        {
            _accountServices = accountServices;
            _context = context;
            _appSetting = optionsMonitor.CurrentValue;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public ActionResult<List<AccountDto>> GetAll()
        {
            try
            {
                return Ok(_accountServices.GetAll());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Authorize]
        [HttpPost("Create")]
        public ActionResult Create(CreateAccountDto input)
        {
            _accountServices.Create(input);
            return Ok();
        }

        [Authorize]
        [HttpPut("Update")]
        public ActionResult Update(UpdateAccountDto input)
        {
            try
            {
                _accountServices.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Authorize]
        [HttpDelete("Delete")]
        public ActionResult Delete(int IdAccount)
        {
            try
            {
                _accountServices.Delete(IdAccount);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Validate(LoginAccount model)
        {
            var user = _context.accounts.SingleOrDefault(us =>
                us.Username == model.Username && us.Password == model.Password
            );
            if (user == null)
            {
                return Ok(
                    new ApiResponse { Success = false, Message = "Invalid username/password" }
                );
            }
            // cấp token
            var token = await GenerationToken(user);
            return Ok(
                new ApiResponse
                {
                    Success = true,
                    Message = "Authenticate success",
                    Data = token
                }
            );
        }

        private async Task<AccountToken> GenerationToken(Account account)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(
                            System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email,
                            account.Email
                        ),
                        new Claim(
                            System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,
                            account.Email
                        ),
                        new Claim(
                            System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString()
                        ),
                        new Claim("UserName", account.Username),
                        new Claim("PhoneNumber", account.PhoneNumber),
                        new Claim("Id", account.IdAccount.ToString()),
                        //Roles
                    }
                ),
                Expires = DateTime.UtcNow.AddSeconds(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerationRefreshToken();

            //Save to DataBase
            var refreshTokenEntity = new AccountRefreshToken
            {
                JwtId = token.Id,
                IdAccount = account.IdAccount,
                Token = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                IssuedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddHours(1),
            };
            await _context.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();
            return new AccountToken { AccessToken = accessToken, RefreshToken = refreshToken, };
        }

        private string GenerationRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ReNewToken(AccountToken model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
            var tokenValidateParam = new TokenValidationParameters
            {
                //tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,

                //ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false // khong kiem tra token het han
            };
            try
            {
                //check 1 : AccesToken valid format
                var tokenInVertification = jwtTokenHandler.ValidateToken(
                    model.AccessToken,
                    tokenValidateParam,
                    out var validatedToken
                );
                // check 2 : thuat toan
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(
                        SecurityAlgorithms.HmacSha512,
                        StringComparison.InvariantCultureIgnoreCase
                    );
                    if (!result) //false
                    {
                        return Ok(new ApiResponse { Success = false, Message = "Invalid token" });
                    }
                }
                //check 3 : Check accessToken expire ?

                var utcExpireDate = long.Parse(
                    tokenInVertification
                        .Claims.FirstOrDefault(x =>
                            x.Type == System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Exp
                        )
                        .Value
                );
                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return BadRequest(
                        new ApiResponse
                        {
                            Success = false,
                            Message = "Access token has not yet expired"
                        }
                    );
                }

                //check 4 : check refreshToken exist in DB
                var storedToken = _context.accountRefreshToken.FirstOrDefault(x =>
                    x.Token == model.RefreshToken
                );
                if (storedToken == null)
                {
                    return Ok(
                        new ApiResponse
                        {
                            Success = false,
                            Message = "Refresh token does not exits"
                        }
                    );
                }

                //check 5 : check refreshToken is used/revoked?

                if (storedToken.IsUsed)
                {
                    return Ok(
                        new ApiResponse { Success = false, Message = "Refresh token has been used" }
                    );
                }

                if (storedToken.IsRevoked)
                {
                    {
                        return Ok(
                            new ApiResponse
                            {
                                Success = false,
                                Message = "Refresh token has been revoked"
                            }
                        );
                    }
                }
                {
                    return Ok(
                        new ApiResponse { Success = false, Message = "Refresh token has been used" }
                    );
                }

                // check 6 : AccessToken id == jwtId in RefreshToken
                var jti = tokenInVertification
                    .Claims.FirstOrDefault(x =>
                        x.Type == System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti
                    )
                    .Value;

                if (storedToken.JwtId != jti)
                {
                    return Ok(
                        new ApiResponse { Success = false, Message = " token doesn't match " }
                    );
                }

                //Update token is used
                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;

                _context.Update(storedToken);
                await _context.SaveChangesAsync();

                // create new token
                var account = await _context.accounts.SingleOrDefaultAsync(a =>
                    a.IdAccount == storedToken.IdAccount
                );
                var token = await GenerationToken(account);

                return Ok(
                    new ApiResponse
                    {
                        Success = true,
                        Message = "Renew token success",
                        Data = token
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ApiResponse { Success = false, Message = "SomeThing went Wrong" }
                );
            }
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToLocalTime();

            return dateTimeInterval;
        }
    }
}
