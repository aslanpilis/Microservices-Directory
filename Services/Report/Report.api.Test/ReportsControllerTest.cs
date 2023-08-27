using Core.AzureServiceBus;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus.Management;
using Moq;
using Report.api.Controllers;
using Report.Business.Implementation;
using Report.Business.Interface;
using Report.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Report.api.Test
{
    public class ReportsControllerTest
    {
        private readonly IReportServices _reportServices ;
        private readonly ReportsController _reportsController ;
    
        private readonly ProducerServices _producerServices;
        public ReportsControllerTest()
        {
           
            _producerServices =new ProducerServices(new ManagementClient(BusConstants.ConnectionString));
           
            _reportServices = new ReportServices(_producerServices);
            _reportsController = new ReportsController(_reportServices);
        }


        [Fact]
        public async void GetAllTest()
        {

            var result = await _reportsController.GetAll();

            var obj = result as ObjectResult;

            Assert.IsType<Response<List<ReportDto>>>(obj.Value);



            var response = obj.Value as Response<List<ReportDto>>;

            Assert.Equal(200, response.StatusCode);
        }

   

        [Fact]
        public async void CreateTest()
        {
            var dto = new ReportCreateDto
            {

               CreatedTime= DateTime.Now,   
               Location="Test",
               Status=1,
               UserId="1"

            };

            var result = await _reportsController.Create(dto);

            var obj = result as ObjectResult;




            var response = obj.Value as Response<ReportDto>;

            Assert.Equal(200, response.StatusCode);
        }

        [Theory]
        [InlineData("64e73a3e933fe69c5c561aaf", "74e5b3ff3c1fcab60ec3d688")]
        public async void UpdateTest(string valid, string invalid)
        {
            var dto = new ReportUpdateDto
            {
                PhoneCount= 1,  
                UptedTime= DateTime.UtcNow,
                Status=2,
                UserCount= 1,   

            };

            dto.Id = invalid;
            var notFoundResult = await _reportsController.Update(dto);
            dto.Id = valid;
            var okResult = await _reportsController.Update(dto);

            var objnotFound = notFoundResult as ObjectResult;
            var objok = okResult as ObjectResult;



            var invalidresponse = objnotFound.Value as Response<ReportDto>;
            Assert.Equal(404, invalidresponse.StatusCode);

            var validresponse = objok.Value as Response<ReportDto>;
            Assert.Equal(200, validresponse.StatusCode);
        }

    }
}
