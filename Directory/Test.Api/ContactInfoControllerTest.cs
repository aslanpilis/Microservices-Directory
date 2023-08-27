using Core.Dtos;
using Directory.Api.Controllers;
using Directory.Business.Implementation;
using Directory.Business.Interface;
using Directory.Entities.Dtos;
using Directory.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Api
{
    public class ContactInfoControllerTest
    {

        private readonly IContactInfoServices _contactInfoServices ;
        private readonly ContactInfoController _contactInfoController ;

        public ContactInfoControllerTest()
        {
            _contactInfoServices = new ContactInfoServices();
            _contactInfoController = new ContactInfoController(_contactInfoServices);
        }

        [Fact]
        public async void GetAllTest()
        {

            var result = await _contactInfoController.GetAll();

            var obj = result as ObjectResult;

            Assert.IsType<Response<List<ContactInfoDto>>>(obj.Value);



            var response = obj.Value as Response<List<ContactInfoDto>>;

            Assert.Equal(200, response.StatusCode);
        }

        [Theory]
        [InlineData("64e64269336b6d7743b38b5c", "84e64269336b6d7743b38b5c")]
        public async void GetByIdTest(string valid, string invalid)
        {

            var notFoundResult = await _contactInfoController.GetById(invalid);
            var okResult = await _contactInfoController.GetById(valid);

            var objnotFound = notFoundResult as ObjectResult;
            var objok = okResult as ObjectResult;



            var invalidresponse = objnotFound.Value as Response<ContactInfoDto>;
            Assert.Equal(404, invalidresponse.StatusCode);

            var validresponse = objok.Value as Response<ContactInfoDto>;
            Assert.Equal(200, validresponse.StatusCode);


        }

        [Fact]
        public async void GetAllByLocationTest()
        {
            var okResult = await _contactInfoController.GetAllByLocation("A");

      
            var objok = okResult as ObjectResult;

            var validresponse = objok.Value as Response<ReportContactInfoDto>;
            Assert.Equal(200, validresponse.StatusCode);

        }  


        [Fact]
        public async void GetAllByUserIdTest()
        {
            var okResult = await _contactInfoController.GetAllByUserId("A");

      
            var objok = okResult as ObjectResult;

            var validresponse = objok.Value as Response<UserDto>;
            Assert.Equal(200, validresponse.StatusCode);

        }


        [Fact]
        public async void CreateTest()
        {
            var dto = new ContactInfoCreateDto
            {

                Location = "Location_test",
                Email = "Email_test",
                Phone = "Phone_test",
                UserId = "UserId",

            };

            var result = await _contactInfoController.Create(dto);

            var obj = result as ObjectResult;




            var response = obj.Value as Response<UserDto>;

            Assert.Equal(200, response.StatusCode);
        }

        [Theory]
        [InlineData("64e64269336b6d7743b38b5c", "84e64269336b6d7743b38b5c")]
        public async void UpdateTest(string valid, string invalid)
        {
            var dto = new ContactInfoDto
            {
                Location = "Location_test",
                Email = "Email_test",
                Phone = "Phone_test",
                UserId = "UserId",

            };

            dto.Id = invalid;
            var notFoundResult = await _contactInfoController.Update(dto);
            dto.Id = valid;
            var okResult = await _contactInfoController.Update(dto);

            var objnotFound = notFoundResult as ObjectResult;
            var objok = okResult as ObjectResult;



            var invalidresponse = objnotFound.Value as Response<ContactInfoDto>;
            Assert.Equal(404, invalidresponse.StatusCode);

            var validresponse = objok.Value as Response<ContactInfoDto>;
            Assert.Equal(204, validresponse.StatusCode);
        }

        [Theory]
        [InlineData("64e5b3ff3c1fcab60ec3d688", "74e5b3ff3c1fcab60ec3d688")]
        public async void DeleteTest(string valid, string invalid)
        {

            //var notFoundResult = await _contactInfoController.Delete(invalid);
            //var okResult = await _contactInfoController.Delete(valid);

            //var objnotFound = notFoundResult as ObjectResult;
            //var objok = okResult as ObjectResult;



            //var invalidresponse = objnotFound.Value as Response<UserDto>;
            //Assert.Equal(404, invalidresponse.StatusCode);

            //var validresponse = objok.Value as Response<UserDto>;
            //Assert.Equal(200, validresponse.StatusCode);


        }
    }
}
