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
        Task<string> CreateAsync(User obj);
    }
}
