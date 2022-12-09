using MongoDB.Bson;
using PPASystem.Entities;

namespace PPASystem.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetAsync();
        Task<Event?> GetAsync(string eventId);
        Task CreateAsync(Event newEvent);
        Task UpdateAsync(string eventId, Event updatedEvent);
        Task RemoveAsync(string eventId);
        Task<List<Event>> Find(BsonDocument filter);
    }

    public interface IMemberService
    {
        Task<List<Member>> GetAsync();
        Task<Member?> GetAsync(string memberId);
        Task CreateAsync(Member newMember);
        Task UpdateAsync(string memberId, Member updatedMember);
        Task RemoveAsync(string memberId);
        Task<List<Member>> Find(BsonDocument filter);
    }

    public interface IParticipantService
    {
        Task<List<Participant>> GetAsync();
        Task<Participant?> GetAsync(string participantId);
        Task CreateAsync(Participant newParticipant);
        Task UpdateAsync(string participantId, Participant updatedParticipant);
        Task RemoveAsync(string participantId);
    }

    public interface IRaceEntryService
    {
        Task<List<RaceEntry>> GetAsync();
        Task<RaceEntry?> GetAsync(string raceEntryId);
        Task CreateAsync(RaceEntry newRaceEntry);
        Task UpdateAsync(string raceEntryId, RaceEntry updatedRaceEntry);
        Task RemoveAsync(string raceEntryId);
        Task<List<RaceEntry>> Find(BsonDocument filter);
    }

    public interface ISeedingService
    {
        Task<List<Seeding>> GetAsync();
        Task<Seeding?> GetAsync(string seedingId);
        Task CreateAsync(Seeding newSeeding);
        Task UpdateAsync(string seedingId, Seeding updatedSeeding);
        Task RemoveAsync(string seedingId);
    }

    public interface ISubscriptionService
    {
        Task<List<Subscription>> GetAsync();
        Task<Subscription?> GetAsync(string subscriptionId);
        Task CreateAsync(Subscription newSubscription);
        Task UpdateAsync(string subscriptionId, Subscription updatedSubscription);
        Task RemoveAsync(string subscriptionId);
        Task<List<Subscription>> Find(BsonDocument filter);
    }

    public interface IUserService
    {
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(string userId);
        Task CreateAsync(User newUser);
        Task UpdateAsync(string userId, User updatedUser);
        Task RemoveAsync(string userId);
    }
}
