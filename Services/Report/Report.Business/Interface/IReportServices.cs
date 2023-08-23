using Core.Dtos;
using Report.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Interface
{
    public interface IReportServices
    {
        Task<Response<ReportDto>> CreateAsync(ReportCreateDto reportCreateDto);
        Task<Response<ReportDto>> UpdateAsync(ReportUpdateDto reportUpdateDto);
        Task<Response<List<ReportDto>>> GetAllByUserIdAsync(string userId);
    }
}
