namespace PPASystem.Entities
{
    public class PPADatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string UserCollectionName { get; set; } = string.Empty;
        public string EventCollectionName { get; set; } = string.Empty;
        public string MemberCollectionName { get; set; } = string.Empty;
        public string ParticipantCollectionName { get; set; } = string.Empty;
        public string RaceEntryCollectionName { get; set; } = string.Empty;
        public string SeedingCollectionName { get; set; } = string.Empty;
        public string SubscriptionCollectionName { get; set; } = string.Empty;
    }
}
