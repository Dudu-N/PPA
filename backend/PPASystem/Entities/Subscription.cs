using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace PPASystem.Entities
{
    public enum SubscriptionType
    {
        IndividualMembership,
        MinorMembership,
        FamilyMembership
    }

    public enum PaidStatus
    {
        Unpaid,
        Paid
    }

    public class Subscription
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? SubscriptionId { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Price { get; set; } = decimal.Zero;

        public List<string> MemberIdList { get; set; } = new List<string>();

        public SubscriptionType SubscriptionType { get; set; }

        public PaidStatus PaidStatus { get; set; }
    }
}
