using PPASystem.DTOs;

namespace PPASystem.Interfaces
{
    public interface IEventAdminSubscription
    {
        Task<string> CreateEvent(EventDto eventDto);
        Task CloseEventRegistration(string eventId);
        Task EndEvent(string eventId);
    }
}
