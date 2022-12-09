using PPASystem.Entities;
using PPASystem.Interfaces;
using System.Net.Mail;

namespace PPASystem.Services
{
    public class SubscriptionAdminService : ISubscriptionAdminService
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMemberService _memberService;

        private readonly string _emailAddress;

        public SubscriptionAdminService(ISubscriptionService subscriptionService, IMemberService memberService, IConfiguration config)
        {
            _subscriptionService = subscriptionService;
            _memberService = memberService;
            _emailAddress = config["EmailAddress"];
        }

        public async Task<List<Subscription>> CheckForExpiring()
        {
            TimeSpan elevenMonths = TimeSpan.FromDays(335);
            DateTime currentDate = DateTime.Now;
            DateTime cuttOffDate = currentDate.Subtract(elevenMonths);

            return _subscriptionService.GetAsync().Result.Where(x => x.StartDate < cuttOffDate).ToList();
        }

        // Might be a frontend task
        //public async void SendNotification(List<Subscription> subscriptions)
        //{
        //    foreach(Subscription sub in subscriptions)
        //    {
        //        string mainMember = sub.MemberIdList.First();
        //        Member member = await _memberService.GetAsync(mainMember);

        //        string to = member.Email;
        //        string from = _emailAddress;

        //        MailMessage notification = new(from, to);
        //        notification.Subject = "Pedal Power Association Subscription Renewal";
        //        notification.Body = $"Hi {member.FirstName}, Thank you ";
        //    }
        //}

        public async Task RenewSubscription(string subscriptionId)
        {
            Subscription subscription = await _subscriptionService.GetAsync(subscriptionId);

            DateTime expiryDate = subscription.StartDate.AddDays(365);
            
            if (expiryDate < DateTime.Now)
            {
                subscription.StartDate = DateTime.Now;
            }
            else
            {
                subscription.StartDate = expiryDate;
            }

            await _subscriptionService.UpdateAsync(subscriptionId, subscription);
        }

        public async Task PaySubscription(string subscriptionId)
        {
            Subscription subscription = await _subscriptionService.GetAsync(subscriptionId);
            subscription.PaidStatus = PaidStatus.Paid;
            await _subscriptionService.UpdateAsync(subscriptionId, subscription);
        }
    }
}
