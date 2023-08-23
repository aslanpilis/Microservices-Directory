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
    public class UserServices: IUserServices
    {
        private readonly IMongoCollection<User> _userCollection;
        const string connectionUri = "mongodb+srv://aslanpilis:a2RaTjeXQzcn1XZu@cluster0.izpn5l8.mongodb.net/?retryWrites=true&w=majority";
        private readonly IMapper _mapper;

        public UserServices() {

            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("Directory");

            _userCollection = database.GetCollection<User>("Users");

        }
     
        public async Task<Response<List<UserDto>>> GetAllAsync()
        {
            var categories = await _userCollection.Find(user => true).ToListAsync();

            return Response<List<UserDto>>.Success(_mapper.Map<List<UserDto>>(categories), 200);
        }

        public async Task<Response<UserDto>> CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userCollection.InsertOneAsync(user);

            return Response<UserDto>.Success(_mapper.Map<UserDto>(user), 200);
        }

        public async Task<Response<UserDto>> GetByIdAsync(string id)
        {
            var user = await _userCollection.Find<User>(x => x.Id == id).FirstOrDefaultAsync();


            if (user == null)
            {
                return Response<UserDto>.Fail("User not found", 404);
            }

            return Response<UserDto>.Success(_mapper.Map<UserDto>(user), 200);
        }
        public async Task<Response<NoContent>> UpdateAsync(UserDto userDto)
        {
            var updateuser = _mapper.Map<User>(userDto);

            var result = await _userCollection.FindOneAndReplaceAsync(x => x.Id == userDto.Id, updateuser);

            if (result == null)
            {
                return Response<NoContent>.Fail("User not found", 404);
            }

           
            return Response<NoContent>.Success(204);
        }
        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _userCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("User not found", 404);
            }
        }
    }
}
