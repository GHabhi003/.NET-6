using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIAssignment.Controllers
{
    [Route("error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error()
        {
            var response = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = response.Error;
            return Problem(detail:exception.StackTrace, statusCode:500, title:exception.Message);
        }
    }
}
