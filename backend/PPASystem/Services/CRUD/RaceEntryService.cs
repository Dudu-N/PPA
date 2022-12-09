using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class RaceEntryService : IRaceEntryService
    {
        private readonly IMongoCollection<RaceEntry> _raceEntryCollection;

        public RaceEntryService(IOptions<PPADatabaseSettings> pdaDatabaseSettings)
        {
            var mongoClient = new MongoClient(pdaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(pdaDatabaseSettings.Value.DatabaseName);

            _raceEntryCollection = mongoDatabase.GetCollection<RaceEntry>(pdaDatabaseSettings.Value.RaceEntryCollectionName);
        }

        public async Task<List<RaceEntry>> GetAsync() =>
            await _raceEntryCollection.Find(_ => true).ToListAsync();

        public async Task<RaceEntry?> GetAsync(string raceEntryId) =>
            await _raceEntryCollection.Find(x => x.RaceEntryId == raceEntryId).FirstOrDefaultAsync();

        public async Task CreateAsync(RaceEntry newRaceEntry) =>
            await _raceEntryCollection.InsertOneAsync(newRaceEntry);

        public async Task UpdateAsync(string raceEntryId, RaceEntry updatedRaceEntry) =>
            await _raceEntryCollection.ReplaceOneAsync(x => x.RaceEntryId == raceEntryId, updatedRaceEntry);

        public async Task RemoveAsync(string raceEntryId) =>
            await _raceEntryCollection.DeleteOneAsync(x => x.RaceEntryId == raceEntryId);


        // Custom
        public async Task<List<RaceEntry>> Find(BsonDocument filter)
        {
            var members = await _raceEntryCollection.FindAsync(filter);
            return members.ToList();
        }
    }
}
