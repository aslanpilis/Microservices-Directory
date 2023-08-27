using Core.Dtos;
using Directory.Api.Controllers;
using Directory.Business.Implementation;
using Directory.Business.Interface;
using Directory.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Transaction;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Directory.Api.Test
{
    public class UsersControllerTest
    {

        //private readonly Mock<IUserServices> _userMockServices;
        private readonly IUserServices _userServices;
        private readonly UsersController _usersController;

        public UsersControllerTest()
        {
            //_userMockServices=new Mock<IUserServices>();
            _userServices = new UserServices();
            _usersController = new UsersController(_userServices);
        }

        [Fact]
        public async void GetAllTest()
        {

            var result = await _usersController.GetAll();

            var obj = result as ObjectResult;

            Assert.IsType<Response<List<UserDto>>>(obj.Value);



            var response = obj.Value as Response<List<UserDto>>;

            Assert.Equal(200, response.StatusCode);
        }

        [Theory]
        [InlineData("64e5b3ff3c1fcab60ec3d688", "74e5b3ff3c1fcab60ec3d688")]
        public async void GetByIdTest(string valid, string invalid)
        {

            var notFoundResult = await _usersController.GetById(invalid);
            var okResult = await _usersController.GetById(valid);

            var objnotFound = notFoundResult as ObjectResult;
            var objok = okResult as ObjectResult;



            var invalidresponse = objnotFound.Value as Response<UserDto>;
            Assert.Equal(404, invalidresponse.StatusCode);

            var validresponse = objok.Value as Response<UserDto>;
            Assert.Equal(200, validresponse.StatusCode);


        }


        [Fact]
        public async void CreateTest()
        {
            var dto = new UserCreateDTO
            {

                Company = "Company_test",
                Surname = "Surname_test",
                Name = "Name_test",

            };

            var result = await _usersController.Create(dto);

            var obj = result as ObjectResult;




            var response = obj.Value as Response<UserDto>;

            Assert.Equal(200, response.StatusCode);
        }

        [Theory]
        [InlineData("64e5b3ff3c1fcab60ec3d688", "74e5b3ff3c1fcab60ec3d688")]
        public async void UpdateTest(string valid, string invalid)
        {
            var dto = new UserDto
            {
                Company = "Company_test",
                Surname = "Surname_test",
                Name = "Name_test",

            };

            dto.Id = invalid;
            var notFoundResult = await _usersController.Update(dto);
            dto.Id = valid;
            var okResult = await _usersController.Update(dto);

            var objnotFound = notFoundResult as ObjectResult;
            var objok = okResult as ObjectResult;



            var invalidresponse = objnotFound.Value as Response<NoContent>;
            Assert.Equal(404, invalidresponse.StatusCode);

            var validresponse = objok.Value as Response<NoContent>;
            Assert.Equal(204, validresponse.StatusCode);
        }

        [Theory]
        [InlineData("64e5b3ff3c1fcab60ec3d688", "74e5b3ff3c1fcab60ec3d688")]
        public async void DeleteTest(string valid, string invalid)
        {

            //var notFoundResult = await _usersController.Delete(invalid);
            //var okResult = await _usersController.Delete(valid);

            //var objnotFound = notFoundResult as ObjectResult;
            //var objok = okResult as ObjectResult;



            //var invalidresponse = objnotFound.Value as Response<UserDto>;
            //Assert.Equal(404, invalidresponse.StatusCode);

            //var validresponse = objok.Value as Response<UserDto>;
            //Assert.Equal(200, validresponse.StatusCode);


        }
    }
}
