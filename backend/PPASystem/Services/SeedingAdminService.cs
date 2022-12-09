using MongoDB.Bson;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Services
{
    public class SeedingAdminService : ISeedingAdminService
    {
        private readonly IRaceEntryService _raceEntryService;
        private readonly IMemberService _memberService;
        public SeedingAdminService(IRaceEntryService raceEntryService, IMemberService memberService)
        {
            _raceEntryService = raceEntryService;
            _memberService = memberService;
        }

        public async Task ApplySeeding(string eventId)
        {
            // get all related race entries
            var filterEntries = new BsonDocument { { "EventId", eventId } };
            List<RaceEntry> raceEntries = await _raceEntryService.Find(filterEntries);

            // get all related members
            var bsonArray = new BsonArray();
            foreach (var raceEntry in raceEntries)
            {
                bsonArray.Add(ObjectId.Parse(raceEntry.MemberId));
            }
            
            var filterMembers = new BsonDocument { { "_id", new BsonDocument { { "$in", bsonArray } } } };
            List<Member> members = await _memberService.Find(filterMembers);

            // sort list by average time
            members = members.OrderBy(x => x.AverageRaceTime).ToList();

            // apply seeding
            List<List<Member>> splitMembers = SplitMembers(members);

            // todo, update members
            await UpdateRaceNumbers(splitMembers, raceEntries);
        }

        private List<List<Member>> SplitMembers(List<Member> members)
        {
            return members
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index % 3)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        private async Task UpdateRaceNumbers(List<List<Member>> members, List<RaceEntry> raceEntries)
        {
            foreach (var member in members[0])
            {
                int i = 1;
                string index = string.Empty;
                if (i < 10)
                {
                    index = i.ToString().PadLeft(3, '0');
                }
                else if (i < 100)
                {
                    index = i.ToString().PadLeft(2, '0');
                }
                else
                {
                    index = i.ToString();
                }

                RaceEntry raceEntry = raceEntries.Where(entry => entry.MemberId == member.MemberId).First();
                raceEntry.RaceNumber = $"A{index}";
                await _raceEntryService.UpdateAsync(raceEntry.RaceEntryId, raceEntry);
                i++;
            }

            foreach (var member in members[1])
            {
                int i = 1;
                string index = string.Empty;
                if (i < 10)
                {
                    index = i.ToString().PadLeft(3, '0');
                }
                else if (i < 100)
                {
                    index = i.ToString().PadLeft(2, '0');
                }
                else
                {
                    index = i.ToString();
                }

                RaceEntry raceEntry = raceEntries.Where(entry => entry.MemberId == member.MemberId).First();
                raceEntry.RaceNumber = $"B{index}";
                await _raceEntryService.UpdateAsync(raceEntry.RaceEntryId, raceEntry);
                i++;
            }

            foreach (var member in members[2])
            {
                int i = 1;
                string index = string.Empty;
                if (i < 10)
                {
                    index = i.ToString().PadLeft(3, '0');
                }
                else if (i < 100)
                {
                    index = i.ToString().PadLeft(2, '0');
                }
                else
                {
                    index = i.ToString();
                }

                RaceEntry raceEntry = raceEntries.Where(entry => entry.MemberId == member.MemberId).First();
                raceEntry.RaceNumber = $"C{index}";
                await _raceEntryService.UpdateAsync(raceEntry.RaceEntryId, raceEntry);
                i++;
            }

            // todo, add race number for participant
        }
    }
}
