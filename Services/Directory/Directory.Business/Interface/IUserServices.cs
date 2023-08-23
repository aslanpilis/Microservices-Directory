using Core.Dtos;
using Directory.Entities.Dtos;
using Directory.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory.Business.Interface
{
    public interface IUserServices
    {
        Task<Response<List<UserDto>>> GetAllAsync();
        Task<Response<UserDto>> CreateAsync(UserDto userDto);
        Task<Response<UserDto>> GetByIdAsync(string id);

        Task<Response<NoContent>> UpdateAsync(UserDto userDto);

        Task<Response<NoContent>> DeleteAsync(string id);

    }
}
