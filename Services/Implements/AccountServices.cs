using AppMobileBackEnd.DbContexts;
using AppMobileBackEnd.Dtos.Account;
using AppMobileBackEnd.Dtos.Music;
using AppMobileBackEnd.Entity;
using AppMobileBackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AppMobileBackEnd.Services.Implements
{
    public class AccountServices : IAccountServices
    {
        private readonly ApplicationMyDBContext _context;


        public AccountServices(ApplicationMyDBContext context)
        {
            _context = context;
        }

        [Authorize]
        public void Create(CreateAccountDto input)
        {
            _context.accounts.Add(
                new Account
                {
                    Email = input.Email,
                    BirthOfDate = input.BirthOfDate,
                    ImageUser = input.ImageUser,
                    NameUser = input.NameUser,
                    Password = input.Password,
                    PhoneNumber = input.PhoneNumber,
                    Username = input.Username,
                }
            );
            _context.SaveChanges();
        }

       
        public void Delete(int IdAccount)
        {
            var account = _context.accounts.SingleOrDefault(a => a.IdAccount == IdAccount);
            if (account == null)
            {
                throw new NotImplementedException($"không tìm thấy account nào");
            }
            _context.accounts.Remove(account);
            _context.SaveChanges();
        }

        
        public List<AccountDto> GetAll()
        {
            var accounts = _context.accounts.Select(a => new AccountDto
            {
                Email = a.Email,
                BirthOfDate = a.BirthOfDate,
                ImageUser = a.ImageUser,
                NameUser = a.NameUser,
                Password = a.Password,
                PhoneNumber = a.PhoneNumber,
                Username = a.Username,
            });
            return accounts.ToList();
        }

       
        public AccountDto getByEmail(string Email)
        {
            throw new NotImplementedException();
        }

       
        public AccountDto getById(int IdAccount)
        {
            throw new NotImplementedException();
        }

        
        public AccountDto getByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        
        public void Update(UpdateAccountDto input)
        {
            var account = _context.accounts.SingleOrDefault(m => m.IdAccount == input.IdAccount);
            if (account == null)
            {
                throw new NotImplementedException($"Không account có  nào có id {input.IdAccount}");
            }
            account.Email = input.Email;
            account.BirthOfDate = input.BirthOfDate;
            account.ImageUser = input.ImageUser;
            account.NameUser = input.NameUser;
            account.Password = input.Password;
            account.PhoneNumber = input.PhoneNumber;
            account.Username = input.Username;
            _context.SaveChanges();
        }

       
    }
}
