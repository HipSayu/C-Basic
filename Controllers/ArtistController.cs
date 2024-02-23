using AppMobileBackEnd.Dtos.Artist;
using AppMobileBackEnd.Dtos.Category;
using AppMobileBackEnd.Services.Implements;
using AppMobileBackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMobileBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ApiControllerBase
    {
        private readonly IArtistServices _artistServices;

        public ArtistController(IArtistServices artistServices, ILogger<ArtistController> logger)
            : base(logger)
        {
            _artistServices = artistServices;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ArtistDto>> GetAll()
        {
            try
            {
                return Ok(_artistServices.GetAll());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("GetByName")]
        public ActionResult<ArtistDto> GetByName(string NameArtist)
        {
            try
            {
                return Ok(_artistServices.GetByName(NameArtist));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(CreateArtistDto input)
        {
            _artistServices.Create(input);
            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult Update(UpdateArtistDto input)
        {
            try
            {
                _artistServices.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int IdArtist)
        {
            try
            {
                _artistServices.Delete(IdArtist);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
