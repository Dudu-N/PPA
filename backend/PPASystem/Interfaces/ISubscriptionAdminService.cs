using MongoDB.Bson;
using PPASystem.Entities;

namespace PPASystem.Interfaces
{
    public interface ISubscriptionAdminService
    {
        Task<List<Subscription>> CheckForExpiring();
        Task RenewSubscription(string subscriptionId);
        Task PaySubscription(string subscriptionId);
    }
}
