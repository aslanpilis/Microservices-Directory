using Directory.Business.Interface;
using Directory.Entities.Dtos;
using Directory.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Directory.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseController
    {


        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices) {
            _userServices=userServices; 


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userServices.GetAllAsync();

            return BaseActionResult(response);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _userServices.GetByIdAsync(id);

            return BaseActionResult(response);
        }

       

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO userDto)
        {
            var response = await _userServices.CreateAsync(userDto);

            return BaseActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            var response = await _userServices.UpdateAsync(userDto);

            return BaseActionResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _userServices.DeleteAsync(id);

            return BaseActionResult(response);
        }

    }
}
