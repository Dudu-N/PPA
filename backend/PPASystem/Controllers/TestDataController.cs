using Microsoft.AspNetCore.Mvc;
using PPASystem.TestData;

namespace PPASystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDataController : ControllerBase
    {
        private readonly ITestDataService _testDataService;

        public TestDataController(ITestDataService testDataService)
        {
            _testDataService = testDataService;
        }

        [HttpGet, Route("generate-register-data")]
        public async Task GenerateRegisterData(int count)
        {
            await _testDataService.GenerateRegisterData(count);
        }

        [HttpGet, Route("generate-event-data")]
        public async Task GenerateEventData(int count)
        {
            await _testDataService.GenerateEventData(count);
        }

        [HttpGet, Route("generate-race-entry-data")]
        public async Task GenerateRaceEntryData(string eventId)
        {
            await _testDataService.GenerateRaceEntryData(eventId);
        }
    }
}
