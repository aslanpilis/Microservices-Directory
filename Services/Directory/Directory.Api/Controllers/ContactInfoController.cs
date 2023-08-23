using Directory.Business.Implementation;
using Directory.Business.Interface;
using Directory.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Directory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactInfoController : BaseController
    {
        private readonly IContactInfoServices _contactInfoServices ;
        public ContactInfoController(IContactInfoServices contactInfoServices )
        {
            _contactInfoServices = contactInfoServices;


        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _contactInfoServices.GetAllAsync();

            return BaseActionResult(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _contactInfoServices.GetByIdAsync(id);

            return BaseActionResult(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _contactInfoServices.GetAllByUserIdAsync(userId);

            return BaseActionResult(response);
        } 
        
        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{location}")]
        public async Task<IActionResult> GetAllByLocation(string location)
        {
            var response = await _contactInfoServices.GetReportByLocationAsync(location);

            return BaseActionResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactInfoCreateDto ContactInfoDto)
        {
            var response = await _contactInfoServices.CreateAsync(ContactInfoDto);

            return BaseActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ContactInfoDto ContactInfoDto)
        {
            var response = await _contactInfoServices.UpdateAsync(ContactInfoDto);

            return BaseActionResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _contactInfoServices.DeleteAsync(id);

            return BaseActionResult(response);
        }
    }
}
