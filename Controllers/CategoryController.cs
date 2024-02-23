using AppMobileBackEnd.Dtos.Category;
using AppMobileBackEnd.Dtos.Music;
using AppMobileBackEnd.Services.Implements;
using AppMobileBackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMobileBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(
            ICategoryServices categoryServices,
            ILogger<CategoryController> logger
        )
            : base(logger)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<CategoryDto>> GetAll()
        {
            try
            {
                return Ok(_categoryServices.GetAll());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(CreateCategoryDto input)
        {
            _categoryServices.Create(input);
            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult Update(UpdateCategoryDto input)
        {
            try
            {
                _categoryServices.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(String NameCategort)
        {
            try
            {
                _categoryServices.Delete(NameCategort);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
