using BlogApp.SharedLibrary.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(Response<T> response) where T : class
        {
            // NoContent 204
            if(response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }
            //Diğer StatasCode durumları 400,500,201 vb.
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };

        }
    }
}
