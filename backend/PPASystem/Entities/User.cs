using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PPASystem.Entities
{
    public enum UserRole
    {
        Admin,
        Member,
        Participant
    }

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = new byte[64];

        public byte[] PasswordSalt { get; set; } = new byte[64];

        public DateTime LastLoggedIn { get; set; }

        public UserRole UserRole { get; set; }
    }
}
