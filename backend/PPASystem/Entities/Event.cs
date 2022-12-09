using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PPASystem.Entities
{
    public enum EventFormat
    {
        FunRide,
        MountainBikeRide,
        SocialRide,
        PpaLeague
    }

    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? EventId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string StartVenue { get; set; }

        public string RouteDescription { get; set; }

        public decimal Distance { get; set; }

        public decimal WinningTime { get; set; }

        public decimal AdjustedWinningTime { get; set; }

        public EventFormat Format { get; set; }
    }
}
