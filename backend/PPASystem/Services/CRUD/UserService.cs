using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IOptions<PPADatabaseSettings> pdaDatabaseSettings)
        {
            var mongoClient = new MongoClient(pdaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(pdaDatabaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(pdaDatabaseSettings.Value.UserCollectionName);
        }

        public async Task<List<User>> GetAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetAsync(string userId) =>
            await _userCollection.Find(x => x.UserId == userId).FirstOrDefaultAsync();

        public async Task CreateAsync(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string userId, User updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.UserId == userId, updatedUser);

        public async Task RemoveAsync(string userId) =>
            await _userCollection.DeleteOneAsync(x => x.UserId == userId);
    }
}
