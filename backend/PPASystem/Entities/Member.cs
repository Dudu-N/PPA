using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PPASystem.Entities
{
    public enum MemberType
    {
        Elites,
        SubVeterans,
        Veterans,
        Masters,
        JuniorScholars,
        SeniorScholars,
        Ladies
    }

    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? MemberId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string IdentityNumber { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string ChipNumber { get; set; } = string.Empty;

        public decimal AverageRaceTime { get; set; } = decimal.Zero;
        public int NumberOfRaces { get; set; } = 0;

        public EmergencyContact EmergencyContact { get; set; } = new();

        public MemberType Type { get; set; }
    }

    public class EmergencyContact
    {
        public string Name { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
    }
}
