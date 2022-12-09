namespace PPASystem.TestData
{
    public interface ITestDataService
    {
        Task GenerateRegisterData(int count);
        Task GenerateEventData(int count);
        Task GenerateRaceEntryData(string eventId);
    }
}
