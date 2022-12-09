using Microsoft.AspNetCore.Mvc;
using PPASystem.Entities;
using PPASystem.Interfaces;

namespace PPASystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionAdminController : ControllerBase
    {
        private readonly ISubscriptionAdminService _subscriptionAdminService;

        public SubscriptionAdminController(ISubscriptionAdminService subscriptionAdminService)
        {
            _subscriptionAdminService = subscriptionAdminService;
        }

        [HttpGet, Route("check-for-expiring")]
        public async Task<List<Subscription>> CheckForExpiring()
        {
            return await _subscriptionAdminService.CheckForExpiring();
        }

        [HttpGet, Route("renew-subscription")]
        public async Task RenewSubscription(string subscriptionId)
        {
            await _subscriptionAdminService.RenewSubscription(subscriptionId);
        }

        [HttpGet, Route("pay-subscription")]
        public async Task PaySubscription(string subscriptionId)
        {
            await _subscriptionAdminService.PaySubscription(subscriptionId);
        }
    }
}
