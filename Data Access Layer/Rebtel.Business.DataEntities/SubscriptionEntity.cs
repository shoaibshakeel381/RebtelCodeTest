using System.Collections.Generic;

namespace Rebtel.Business.DataEntities
{
    public class SubscriptionEntity : BaseEntity<string>
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public double PriceIncVat { get; set; }

        public int CallMinutes { get; set; }

        public virtual ICollection<UserSubscriptionEntity> UserSubscriptions { get; set; }
    }
}
