using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.EntityConfigurations
{
    class SubscriptionConfiguration : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Name).IsRequired().HasMaxLength(100);
            Property(a => a.CallMinutes).IsRequired();
            Property(a => a.Price).IsRequired();
            Property(a => a.PriceIncVat).IsRequired();
        }
    }
}
