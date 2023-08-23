using AutoMapper;
using Directory.Entities.Dtos;
using Directory.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory.Entities.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
        
    }
}
