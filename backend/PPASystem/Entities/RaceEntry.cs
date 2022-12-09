using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PPASystem.Entities
{
    public class RaceEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? RaceEntryId { get; set; }

        public string MemberId { get; set; } = string.Empty;

        public string EventId { get; set; } = string.Empty;

        public string RaceNumber { get; set; } = string.Empty;

        public string RaceTime { get; set; } = string.Empty;
    }
}
