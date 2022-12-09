using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IMongoCollection<Participant> _participantCollection;

        public ParticipantService(IOptions<PPADatabaseSettings> pdaDatabaseSettings)
        {
            var mongoClient = new MongoClient(pdaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(pdaDatabaseSettings.Value.DatabaseName);

            _participantCollection = mongoDatabase.GetCollection<Participant>(pdaDatabaseSettings.Value.ParticipantCollectionName);
        }

        public async Task<List<Participant>> GetAsync() =>
            await _participantCollection.Find(_ => true).ToListAsync();

        public async Task<Participant?> GetAsync(string participantId) =>
            await _participantCollection.Find(x => x.ParticipantId == participantId).FirstOrDefaultAsync();

        public async Task CreateAsync(Participant newParticipant) =>
            await _participantCollection.InsertOneAsync(newParticipant);

        public async Task UpdateAsync(string participantId, Participant updatedParticipant) =>
            await _participantCollection.ReplaceOneAsync(x => x.ParticipantId == participantId, updatedParticipant);

        public async Task RemoveAsync(string participantId) =>
            await _participantCollection.DeleteOneAsync(x => x.ParticipantId == participantId);
    }
}
