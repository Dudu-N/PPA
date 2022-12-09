using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IMongoCollection<Subscription> _subscriptionCollection;

        public SubscriptionService(IOptions<PPADatabaseSettings> pdaDatabaseSettings)
        {
            var mongoClient = new MongoClient(pdaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(pdaDatabaseSettings.Value.DatabaseName);

            _subscriptionCollection = mongoDatabase.GetCollection<Subscription>(pdaDatabaseSettings.Value.SubscriptionCollectionName);
        }

        public async Task<List<Subscription>> GetAsync() =>
            await _subscriptionCollection.Find(_ => true).ToListAsync();

        public async Task<Subscription?> GetAsync(string subscriptionId) =>
            await _subscriptionCollection.Find(x => x.SubscriptionId == subscriptionId).FirstOrDefaultAsync();

        public async Task CreateAsync(Subscription newSubscription) =>
            await _subscriptionCollection.InsertOneAsync(newSubscription);

        public async Task UpdateAsync(string subscriptionId, Subscription updatedSubscription) =>
            await _subscriptionCollection.ReplaceOneAsync(x => x.SubscriptionId == subscriptionId, updatedSubscription);

        public async Task RemoveAsync(string subscriptionId) =>
            await _subscriptionCollection.DeleteOneAsync(x => x.SubscriptionId == subscriptionId);

        public async Task<List<Subscription>> Find(BsonDocument filter)
        {
            return await _subscriptionCollection.Find(filter).ToListAsync();
        }
    }
}
