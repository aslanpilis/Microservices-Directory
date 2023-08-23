using AutoMapper;
using Core.Dtos;
using Directory.Business.Interface;
using Directory.Entities.Dtos;
using Directory.Entities.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory.Business.Implementation
{
    public class ContactInfoServices: IContactInfoServices
    {

      
        private readonly IMongoCollection<ContactInfo> _contactInfoCollection;
        const string connectionUri = "mongodb+srv://aslanpilis:a2RaTjeXQzcn1XZu@cluster0.izpn5l8.mongodb.net/?retryWrites=true&w=majority";
        private readonly IMapper _mapper;

        public ContactInfoServices()
        {

            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("Directory");

            _contactInfoCollection = database.GetCollection<ContactInfo>("ContactInfos");

            MapperConfiguration config = autoMapperConfig();
            _mapper = config.CreateMapper();
        }

        private MapperConfiguration autoMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ContactInfoCreateDto, ContactInfo>();
                cfg.CreateMap<ContactInfo, ContactInfoCreateDto>();
                cfg.CreateMap<ContactInfo, ContactInfoDto>();

            });
        }


        public async Task<Response<List<ContactInfoDto>>> GetAllAsync()
        {
            var ContactInfos = await _contactInfoCollection.Find(ContactInfo => true).ToListAsync();

            return Response<List<ContactInfoDto>>.Success(_mapper.Map<List<ContactInfoDto>>(ContactInfos), 200);
        }

        public async Task<Response<ContactInfoDto>> CreateAsync(ContactInfoCreateDto ContactInfoDto)
        {
            var ContactInfo = _mapper.Map<ContactInfo>(ContactInfoDto);
            await _contactInfoCollection.InsertOneAsync(ContactInfo);

            return Response<ContactInfoDto>.Success(_mapper.Map<ContactInfoDto>(ContactInfo), 200);
        }
        public async Task<Response<List<ContactInfoDto>>> GetAllByUserIdAsync(string userId)
        {
            var contactInfos = await _contactInfoCollection.Find<ContactInfo>(x => x.UserId == userId).ToListAsync();

            return Response<List<ContactInfoDto>>.Success(_mapper.Map<List<ContactInfoDto>>(contactInfos), 200);
        }  
        
        public async Task<Response<ReportContactInfoDto>> GetReportByLocationAsync(string location)
        {
            var contactInfos = await _contactInfoCollection.Find<ContactInfo>(x => x.Location == location).ToListAsync();

            var usercount= contactInfos.Select(p => p.UserId).Distinct().Count();

            var phonecount = contactInfos.Select(p => p.Phone).Distinct().Count();

            var reportContactInfoDto =new ReportContactInfoDto();
            reportContactInfoDto.Location = location;
            reportContactInfoDto.UserCount = usercount;
            reportContactInfoDto.PhoneCount = phonecount;

            return Response<ReportContactInfoDto>.Success(reportContactInfoDto, 200);
        }


        public async Task<Response<ContactInfoDto>> GetByIdAsync(string id)
        {
            var ContactInfo = await _contactInfoCollection.Find<ContactInfo>(x => x.Id == id).FirstOrDefaultAsync();


            if (ContactInfo == null)
            {
                return Response<ContactInfoDto>.Fail("ContactInfo not found", 404);
            }

            return Response<ContactInfoDto>.Success(_mapper.Map<ContactInfoDto>(ContactInfo), 200);
        }
        public async Task<Response<NoContent>> UpdateAsync(ContactInfoDto ContactInfoDto)
        {
            var updateContactInfo = _mapper.Map<ContactInfo>(ContactInfoDto);

            var result = await _contactInfoCollection.FindOneAndReplaceAsync(x => x.Id == ContactInfoDto.Id, updateContactInfo);

            if (result == null)
            {
                return Response<NoContent>.Fail("ContactInfo not found", 404);
            }


            return Response<NoContent>.Success(204);
        }
        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _contactInfoCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("ContactInfo not found", 404);
            }
        }


    }
}
