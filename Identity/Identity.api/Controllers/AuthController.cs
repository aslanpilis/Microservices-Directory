using Core.Dtos;
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
          
            var res = new Response<TokenDto>();
            res.IsSuccessful = true;
            res.StatusCode = 200;   
            res.Data = new TokenDto { Token = token };     
            return new ObjectResult(res);
        }
    }
}
