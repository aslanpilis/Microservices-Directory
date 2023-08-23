using Directory.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Directory.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {


        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices) {
            _userServices=userServices; 


        }
        [HttpGet]
        public IActionResult Test()
        {

            _userServices.CreateAsync(new Entities.Entity.User
            {
                Name= "Test",   
                Surname="Test", 
                Company="Test", 


            });
            return Ok();
        }
    }
}
