using AppMobileBackEnd.Dtos.Music;
using AppMobileBackEnd.Entity;
using AppMobileBackEnd.Services.Implements;
using AppMobileBackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static AppMobileBackEnd.Entity.Music;

namespace AppMobileBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ApiControllerBase
    {
        private readonly IMusciServices _musicServices;
        private readonly IMusicSeacrhServices _musicSeacrhServices;
       

        public MusicController(
            IMusciServices musicServices,
            IMusicSeacrhServices musicSeacrhServices,
          
            ILogger<MusicController> logger
        )
            : base(logger)
        {
            _musicServices = musicServices;
            _musicSeacrhServices = musicSeacrhServices;
          
        }

        [HttpGet("GetAll")]
        public ActionResult<List<MusicDto>> GetAll()
        {
            try
            {
                return Ok(_musicServices.GetAll());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("SearchByArtist")]
        public ActionResult<List<SearchMusicDto>> SearchByArtist(string NameArtist, int? from, int? to, int page)
        {
            try
            {
                return Ok(_musicSeacrhServices.SearchByArtist(NameArtist, from, to, page));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetMusicByArtist")]
        public ActionResult<List<SearchMusicDto>> GetMusicByArtist(string NameArtist)
        {
            try
            {
                return Ok(_musicSeacrhServices.GetAllByNameArtist(NameArtist));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetMusicByCategory")]
        public ActionResult<List<SearchMusicDto>> GetMusicByCategory(string NameCagetory)
        {
            try
            {
                return Ok(_musicSeacrhServices.GetAllByCagetory(NameCagetory));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(CreateMusicDto input)
        {
            _musicServices.Create(input);
            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult Update(UpdateMusicDto input)
        {
            try
            {
                _musicServices.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _musicServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
