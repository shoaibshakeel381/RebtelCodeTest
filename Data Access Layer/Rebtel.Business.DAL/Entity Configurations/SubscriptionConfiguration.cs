using System.Data.Entity.ModelConfiguration;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.EntityConfigurations
{
    class SubscriptionConfiguration : EntityTypeConfiguration<SubscriptionEntity>
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
