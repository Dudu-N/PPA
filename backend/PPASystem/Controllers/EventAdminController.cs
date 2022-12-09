using Microsoft.AspNetCore.Mvc;
using PPASystem.DTOs;
using PPASystem.Interfaces;

namespace PPASystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventAdminController : ControllerBase
    {
        private readonly IEventAdminSubscription _eventAdminSubscription;

        public EventAdminController(IEventAdminSubscription eventAdminSubscription)
        {
            _eventAdminSubscription = eventAdminSubscription;
        }

        [HttpPost, Route("create-event")]
        public async Task<string> CreateEvent(EventDto eventDto)
        {
            return await _eventAdminSubscription.CreateEvent(eventDto);
        }

        [HttpGet, Route("close-event-registration")]
        public async Task CloseEventRegistration(string eventId)
        {
            await _eventAdminSubscription.CloseEventRegistration(eventId);
        }

        [HttpGet, Route("end-event")]
        public async Task EndEvent(string eventId)
        {
            await _eventAdminSubscription.EndEvent(eventId);
        }
    }
}
