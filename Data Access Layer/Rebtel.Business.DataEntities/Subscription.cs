using System.Collections.Generic;

namespace Rebtel.Business.DataEntities
{
    public class Subscription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double PriceIncVat { get; set; }

        public int CallMinutes { get; set; }

        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
