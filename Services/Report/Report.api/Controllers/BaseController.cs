using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Report.api.Controllers
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
