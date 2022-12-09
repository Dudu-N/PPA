using MongoDB.Bson;
using PPASystem.DTOs;
using PPASystem.Entities;
using PPASystem.Interfaces;
using SharpCompress.Common.Rar;

namespace PPASystem.Services
{
    public class EventAdminService : IEventAdminSubscription
    {
        private readonly IEventService _eventService;
        private readonly ISeedingAdminService _seedingAdminService;
        private readonly IRaceEntryService _raceEntryService;
        private readonly IMemberService _memberService;
        private readonly IMemberAdminService _memberAdminService;

        public EventAdminService(IEventService eventService, ISeedingAdminService seedingAdminService, IRaceEntryService raceEntryService, IMemberService memberService)
        {
            _eventService = eventService;
            _seedingAdminService = seedingAdminService;
            _raceEntryService = raceEntryService;
            _memberService = memberService;
        }

        public async Task<string> CreateEvent(EventDto eventDto)
        {
            Event newEvent = new()
            {
                Code = eventDto.Code,
                Name = eventDto.Name,
                Date = eventDto.Date,
                StartVenue = eventDto.StartVenue,
                RouteDescription = eventDto.RouteDescription,
                Distance = eventDto.Distance,
                WinningTime = eventDto.WinningTime,
                AdjustedWinningTime = eventDto.AdjustedWinningTime,
                Format = eventDto.Format,
            };

            await _eventService.CreateAsync(newEvent);

            return newEvent.EventId;
        }

        public async Task CloseEventRegistration(string eventId)
        {
            await _seedingAdminService.ApplySeeding(eventId);
        }

        public async Task EndEvent(string eventId)
        {
            // get all related race entries
            var filterEntries = new BsonDocument { { "EventId", eventId } };
            List<RaceEntry> raceEntries = await _raceEntryService.Find(filterEntries);

            var rand = new Random();
            decimal[] raceTimes = new decimal[raceEntries.Count];
            for (int i = 0; i < raceEntries.Count; i++)
            {
                raceTimes[i] = new decimal(rand.NextDouble());
            }

            Event thisEvent = await _eventService.GetAsync(eventId);
            thisEvent.WinningTime = raceTimes.Max();
            await _eventService.UpdateAsync(eventId, thisEvent);

            foreach (var raceEntry in raceEntries)
            {
                int index = 0;
                raceEntry.RaceTime = raceTimes[index].ToString();
                await _raceEntryService.UpdateAsync(raceEntry.RaceEntryId, raceEntry);

                Member member = await _memberService.GetAsync(raceEntry.MemberId);
                member.NumberOfRaces += 1;
                member.AverageRaceTime = (member.AverageRaceTime + raceTimes[index]) / member.NumberOfRaces;
                await _memberService.UpdateAsync(member.MemberId, member);
            }
        }
    }
}
