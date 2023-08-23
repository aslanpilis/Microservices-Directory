using Core.Dtos;
using Directory.Business.Implementation;
using Directory.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory.Business.Interface
{
    public interface IContactInfoServices
    {
        Task<Response<List<ContactInfoDto>>> GetAllAsync();
        Task<Response<ContactInfoDto>> CreateAsync(ContactInfoCreateDto contactInfoDto);
        Task<Response<ContactInfoDto>> GetByIdAsync(string id);

        Task<Response<NoContent>> UpdateAsync(ContactInfoDto contactInfoDto);
        Task<Response<List<ContactInfoDto>>> GetAllByUserIdAsync(string userId);

        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<ReportContactInfoDto>> GetReportByLocationAsync(string location);
    }
}
