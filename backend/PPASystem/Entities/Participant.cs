using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PPASystem.Entities
{
    public class Participant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ParticipantId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string IdentityNumber { get; set; } = string.Empty;

        // todo, add emergency contact
        // todo, add race number

        public decimal AverageRaceTime { get; set; } = decimal.Zero;
    }
}
