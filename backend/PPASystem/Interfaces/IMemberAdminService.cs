using PPASystem.DTOs;
using PPASystem.Entities;

namespace PPASystem.Interfaces
{
    public interface IMemberAdminService
    {
        Task<string> RegisterForEvent(RaceEntryDto raceEntryDto);
        Task<List<Event>> GetUpcomingEventsAsync(string memberId);
        Task<List<Event>> GetPreviousEventsAsync(string memberId);
        Task<List<Member>> GetAllMembers();
        Task<Member> GetMember(string username);
    }
}
