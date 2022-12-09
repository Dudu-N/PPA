using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _eventCollection;

        public EventService(IOptions<PPADatabaseSettings> pdaDatabaseSettings)
        {
            var mongoClient = new MongoClient(pdaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(pdaDatabaseSettings.Value.DatabaseName);

            _eventCollection = mongoDatabase.GetCollection<Event>(pdaDatabaseSettings.Value.EventCollectionName);
        }

        public async Task<List<Event>> GetAsync()
        {
            return await _eventCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Event?> GetAsync(string eventId)
        {
            return await _eventCollection.Find(x => x.EventId == eventId).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Event newEvent)
        {
            await _eventCollection.InsertOneAsync(newEvent);
        }

        public async Task UpdateAsync(string eventId, Event updatedEvent) =>
            await _eventCollection.ReplaceOneAsync(x => x.EventId == eventId, updatedEvent);

        public async Task RemoveAsync(string eventId) =>
            await _eventCollection.DeleteOneAsync(x => x.EventId == eventId);

        // Custom
        public async Task<List<Event>> Find(BsonDocument filter)
        {
            var events = await _eventCollection.FindAsync(filter);
            return events.ToList();
        }
    }
}

