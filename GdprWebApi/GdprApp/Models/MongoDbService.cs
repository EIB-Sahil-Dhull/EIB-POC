using GdprApp.Models;
using MongoDB.Driver;

namespace GDPR_POC.Model
{
    public class MongoDbService
    {
        private readonly IMongoCollection<User> _users;

        public MongoDbService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase(config["DatabaseName"]);
            _users = database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var result = await _users.Find(user => true).ToListAsync();
            return result;
        }
        
        public async Task CreateUserAsync(User user) => await _users.InsertOneAsync(user);
    }

}
