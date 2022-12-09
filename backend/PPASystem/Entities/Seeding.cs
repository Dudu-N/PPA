using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PPASystem.Entities
{
    public class Seeding
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? SeedingId { get; set; }

        public string EventId { get; set; } = string.Empty;

        public string SeedingGroup { get; set; } = string.Empty;

        public List<string> MemberIdList { get; set; } = new List<string>();
    }
}
