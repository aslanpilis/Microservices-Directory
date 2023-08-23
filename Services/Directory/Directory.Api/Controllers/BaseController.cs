using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Directory.Api.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult BaseActionResult<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
