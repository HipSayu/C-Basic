using AppMobileBackEnd.Dtos.Exceptions;
using AppMobileBackEnd.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMobileBackEnd.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected ILogger _logger;

        public ApiControllerBase(ILogger logger)
        {
            _logger = logger;
        }

        protected ActionResult HandleException(Exception ex)
        {
            if (ex is UserFriendlyExceptions)
            {
                return BadRequest(new ResponseError() { Message = ex.Message });
            }
            _logger.LogError(ex, ex.Message);
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new ResponseError() { Message = ex.Message }
            );
        }
    }
}
