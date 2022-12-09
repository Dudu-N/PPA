using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMongoCollection<Member> _memberCollection;

        public MemberService(IOptions<PPADatabaseSettings> pdaDatabaseSettings)
        {
            var mongoClient = new MongoClient(pdaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(pdaDatabaseSettings.Value.DatabaseName);

            _memberCollection = mongoDatabase.GetCollection<Member>(pdaDatabaseSettings.Value.MemberCollectionName);
        }

        public async Task<List<Member>> GetAsync() =>
            await _memberCollection.Find(_ => true).ToListAsync();

        public async Task<Member?> GetAsync(string memberId) =>
            await _memberCollection.Find(x => x.MemberId == memberId).FirstOrDefaultAsync();

        public async Task CreateAsync(Member newMember) =>
            await _memberCollection.InsertOneAsync(newMember);

        public async Task UpdateAsync(string memberId, Member updatedMember) =>
            await _memberCollection.ReplaceOneAsync(x => x.MemberId == memberId, updatedMember);

        public async Task RemoveAsync(string memberId) =>
            await _memberCollection.DeleteOneAsync(x => x.MemberId == memberId);

        
        // Custom
        public async Task<List<Member>> Find(BsonDocument filter)
        {
            var members = await _memberCollection.FindAsync(filter);
            return members.ToList();
        }
    }
}
