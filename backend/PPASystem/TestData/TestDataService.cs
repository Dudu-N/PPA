using Bogus;
using PPASystem.DTOs;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.TestData
{
    public class TestDataService : ITestDataService
    {
        private readonly IAccountService _accountService;
        private readonly IEventAdminSubscription _eventAdminSubscription;
        private readonly IMemberAdminService _memberAdminService;

        public TestDataService(IAccountService accountService, IEventAdminSubscription eventAdminSubscription, IMemberAdminService memberAdminService)
        {
            _accountService = accountService;
            _eventAdminSubscription = eventAdminSubscription;
            _memberAdminService = memberAdminService;
        }

        public async Task GenerateRegisterData(int count)
        {
            Randomizer.Seed = new Random(542156);

            var registerDtoFaker = new Faker<RegisterDto>()
                .RuleFor(x => x.Username, x => x.Person.Email)
                .RuleFor(x => x.Password, x => x.Random.AlphaNumeric(24))
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.IdentityNumber, x => x.Person.DateOfBirth.ToString())
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.ContactNumber, x => x.Phone.PhoneNumberFormat(10))
                .RuleFor(x => x.ChipNumber, x => x.Random.AlphaNumeric(10))
                .RuleFor(x => x.UserRole, x => UserRole.Member);

            foreach (var registerDto in registerDtoFaker.Generate(count))
            {
                _ = await _accountService.Register(registerDto);
            }
        }

        public async Task GenerateEventData(int count)
        {
            Randomizer.Seed = new Random(541254);

            var eventDtoFaker = new Faker<EventDto>()
                .RuleFor(x => x.Code, x => x.Random.Utf16String(5))
                .RuleFor(x => x.Name, x => x.Random.Word())
                .RuleFor(x => x.Date, x => x.Date.Soon(1))
                .RuleFor(x => x.StartVenue, x => x.Address.StreetAddress())
                .RuleFor(x => x.Distance, x => x.Random.Decimal(1, 20))
                .RuleFor(x => x.Format, x => EventFormat.FunRide);

            foreach (var eventDto in eventDtoFaker.Generate(count))
            {
                _ = await _eventAdminSubscription.CreateEvent(eventDto);
            }
        }

        public async Task GenerateRaceEntryData(string eventId)
        {
            List<Member> members = await _memberAdminService.GetAllMembers();
            foreach (var member in members)
            {
                _ = await _memberAdminService.RegisterForEvent(new() { EventId = eventId, MemberId = member.MemberId });
            }
        }
    }
}
