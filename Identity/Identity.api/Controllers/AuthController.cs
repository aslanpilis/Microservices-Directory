using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult GetToken()
        {
            var token = JwtHelper.GenerateSecurityToken("1", "Admin");

            return Ok(token);
        }
    }
}
