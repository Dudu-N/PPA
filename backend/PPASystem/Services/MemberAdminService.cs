using MongoDB.Bson;
using MongoDB.Driver;
using PPASystem.DTOs;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class MemberAdminService : IMemberAdminService
    {
        private readonly IRaceEntryService _raceEntryService;
        private readonly IEventService _eventService;
        private readonly IMemberService _memberService;
        private readonly ISubscriptionService _subscriptionService;

        public MemberAdminService(IRaceEntryService raceEntryService, IEventService eventService, IMemberService memberService, ISubscriptionService subscriptionService)
        {
            _raceEntryService = raceEntryService;
            _eventService = eventService;
            _memberService = memberService;
            _subscriptionService = subscriptionService;
        }

        // Might move to RaceEntryAdmin
        public async Task<string> RegisterForEvent(RaceEntryDto raceEntryDto)
        {
            var filter = new BsonDocument { { "MemberIdList", raceEntryDto.MemberId } };
            List<Subscription> subscriptions = await _subscriptionService.Find(filter);
            if (subscriptions is null || subscriptions.Count == 0)
            {
                return null; // todo, exception "membership does not exist"
            }
            Subscription memberSubscription = subscriptions.First();

            if (memberSubscription.PaidStatus == PaidStatus.Unpaid)
            {
                return null; // todo, exception "membership not paid"
            }

            RaceEntry raceEntry = new()
            {
                MemberId = raceEntryDto.MemberId,
                EventId = raceEntryDto.EventId,
            };

            await _raceEntryService.CreateAsync(raceEntry);

            return raceEntry.RaceEntryId;
        }

        public async Task<List<Event>> GetUpcomingEventsAsync(string memberId)
        {
            var filterRaceId = new BsonDocument { { "MemberId", memberId } };
            List<RaceEntry> raceEntries = await _raceEntryService.Find(filterRaceId);

            var filterDate = new BsonDocument { { "Date", new BsonDocument { { "$gt", DateTime.Now } } } };
            var bsonArray = new BsonArray();
            foreach (var raceEntry in raceEntries)
            {
                bsonArray.Add(ObjectId.Parse(raceEntry.MemberId));
            }

            var filterEntries = new BsonDocument { { "_id", new BsonDocument { { "$in", bsonArray } } } };
            var filter = new BsonDocument { { "$and", new BsonArray { filterDate, filterEntries } } };

            return await _eventService.Find(filter);
        }

        public async Task<List<Event>> GetPreviousEventsAsync(string memberId)
        {
            var filterRaceId = new BsonDocument { { "MemberId", memberId } };
            List<RaceEntry> raceEntries = await _raceEntryService.Find(filterRaceId);

            var filterDate = new BsonDocument { { "Date", new BsonDocument { { "$gt", DateTime.Now } } } };
            var bsonArray = new BsonArray();
            foreach (var raceEntry in raceEntries)
            {
                bsonArray.Add(ObjectId.Parse(raceEntry.MemberId));
            }

            var filterEntries = new BsonDocument { { "_id", new BsonDocument { { "$in", bsonArray } } } };
            var filter = new BsonDocument { { "$and", new BsonArray { filterDate, filterEntries } } };

            return await _eventService.Find(filter);
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _memberService.GetAsync();
        }

        public async Task<Member> GetMember(string username)
        {
            var filter = new BsonDocument { { "Username", username } };
            var member = await _memberService.Find(filter);
            return member.First();
        }
    }
}
