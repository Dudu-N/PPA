using Microsoft.AspNetCore.Mvc;
using PPASystem.DTOs;
using PPASystem.Entities;
using PPASystem.Interfaces;
using PPASystem.Services;

namespace PPASystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberAdminController : ControllerBase
    {
        private readonly IMemberAdminService _memberAdminService;

        public MemberAdminController(IMemberAdminService memberAdminService)
        {
            _memberAdminService = memberAdminService;
        }

        [HttpPost, Route("register-for-event")]
        public async Task<string> RegisterForEvent(RaceEntryDto raceEntryDto)
        {
            return await _memberAdminService.RegisterForEvent(raceEntryDto);
        }

        [HttpGet, Route("get-upcoming-events")]
        public async Task<List<Event>> GetUpcomingEvents(string memberId)
        {
            return await _memberAdminService.GetUpcomingEventsAsync(memberId);
        }

        [HttpGet, Route("get-previous-events")]
        public async Task<List<Event>> GetPreviousEventsAsync(string memberId)
        {
            return await _memberAdminService.GetPreviousEventsAsync(memberId);
        }

        [HttpGet, Route("get-all-members")]
        public async Task<List<Member>> GetAllMembers()
        {
            return await _memberAdminService.GetAllMembers();
        }

        [HttpGet, Route("get-member")]
        public async Task<Member> GetMember(string username)
        {
            return await _memberAdminService.GetMember(username);
        }
    }
}
