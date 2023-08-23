using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Report.Entities.Entity;
using Core.Dtos;
using Report.Entities.Dtos;
using AutoMapper;
using Report.Business.Interface;

namespace Report.Business.Implementation
{
    public class ReportServices: IReportServices
    {
        private readonly IMongoCollection<Reports> _reportCollection;
        const string connectionUri = "mongodb+srv://aslanpilis:a2RaTjeXQzcn1XZu@cluster0.izpn5l8.mongodb.net/?retryWrites=true&w=majority";
        private readonly IMapper _mapper;

        public ReportServices()
        {

            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("Report");

            _reportCollection = database.GetCollection<Reports>("Reports");

           
        }
        private MapperConfiguration autoMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Reports, ReportCreateDto>();
                cfg.CreateMap<Reports, ReportUpdateDto>();
                cfg.CreateMap<Reports, ReportDto>();
                

            });
        }
        public async Task<Response<ReportDto>> CreateAsync(ReportCreateDto reportCreateDto)
        {
            var  reports = _mapper.Map<Reports>(reportCreateDto);
            await _reportCollection.InsertOneAsync(reports);

            return Response<ReportDto>.Success(_mapper.Map<ReportDto>(reports), 200);
        } 
        
        public async Task<Response<ReportDto>> UpdateAsync(ReportUpdateDto reportUpdateDto)
        {
            var  report =  await _reportCollection.Find<Reports>(x => x.Id == reportUpdateDto.Id).FirstOrDefaultAsync();
            if (report == null)
            {
                return Response<ReportDto>.Fail("report not found", 404);
            }
            report.Status = reportUpdateDto.Status;
            report.UserCount= reportUpdateDto.UserCount;   
            report.PhoneCount= reportUpdateDto.PhoneCount;   
            report.UptedTime= DateTime.Now;

            var result = await _reportCollection.FindOneAndReplaceAsync(x => x.Id == reportUpdateDto.Id, report);

            return Response<ReportDto>.Success(_mapper.Map<ReportDto>(report), 200);
        }

        public async Task<Response<List<ReportDto>>> GetAllByUserIdAsync(string userId)
        {
            var reports = await _reportCollection.Find<Reports>(x => x.UserId == userId).ToListAsync();

            return Response<List<ReportDto>>.Success(_mapper.Map<List<ReportDto>>(reports), 200);
        }

    }
}
