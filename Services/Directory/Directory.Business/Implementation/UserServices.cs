using Directory.Business.Interface;
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

        public UserServices() {

            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("Directory");

            _userCollection = database.GetCollection<User>("Users");

        }
        public async Task<string> CreateAsync(User obj)
        {
            //var category = _mapper.Map<Category>(categoryDto);
            await _userCollection.InsertOneAsync(obj);

            return "";
        }



    }
}
