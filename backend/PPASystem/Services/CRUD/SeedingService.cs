using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class SeedingService : ISeedingService
    {
        private readonly IMongoCollection<Seeding> _seedingCollection;

        public SeedingService(IOptions<PPADatabaseSettings> pdaDatabaseSettings)
        {
            var mongoClient = new MongoClient(pdaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(pdaDatabaseSettings.Value.DatabaseName);

            _seedingCollection = mongoDatabase.GetCollection<Seeding>(pdaDatabaseSettings.Value.SeedingCollectionName);
        }

        public async Task<List<Seeding>> GetAsync() =>
            await _seedingCollection.Find(_ => true).ToListAsync();

        public async Task<Seeding?> GetAsync(string seedingId) =>
            await _seedingCollection.Find(x => x.SeedingId == seedingId).FirstOrDefaultAsync();

        public async Task CreateAsync(Seeding newSeeding) =>
            await _seedingCollection.InsertOneAsync(newSeeding);

        public async Task UpdateAsync(string seedingId, Seeding updatedSeeding) =>
            await _seedingCollection.ReplaceOneAsync(x => x.SeedingId == seedingId, updatedSeeding);

        public async Task RemoveAsync(string seedingId) =>
            await _seedingCollection.DeleteOneAsync(x => x.SeedingId == seedingId);
    }
}

