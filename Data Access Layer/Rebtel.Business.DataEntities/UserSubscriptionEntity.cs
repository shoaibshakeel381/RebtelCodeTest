namespace Rebtel.Business.DataEntities
{
    public class UserSubscriptionEntity
    {
        public string UserId { get; set; }

        public UserEntity UserEntity { get; set; }

        public string SubscriptionId { get; set; }

        public SubscriptionEntity Subscription { get; set; }
    }
}
