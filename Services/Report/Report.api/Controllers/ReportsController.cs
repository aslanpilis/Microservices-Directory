using Microsoft.AspNetCore.Mvc;
using Report.Business.Interface;
using Report.Entities.Dtos;
using System.Threading.Tasks;

namespace Report.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : BaseController
    {
        private readonly IReportServices _reportServices;
        public ReportsController(IReportServices reportServices)
        {
            _reportServices= reportServices;    
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _reportServices.GetAllAsync();

            return BaseActionResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReportCreateDto reportCreateDto )
        {
            var response = await _reportServices.CreateAsync(reportCreateDto);

            return BaseActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ReportUpdateDto reportUpdateDto)
        {
            var response = await _reportServices.UpdateAsync(reportUpdateDto);

            return BaseActionResult(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _reportServices.GetAllByUserIdAsync(userId);

            return BaseActionResult(response);
        }

    }
}
