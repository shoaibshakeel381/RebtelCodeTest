using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.ModelConfigurations
{
    class SubscriptionConfiguration : EntityTypeConfiguration<SubscriptionEntity>
    {
        public SubscriptionConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(a => a.Name).IsRequired().HasMaxLength(100);
            Property(a => a.CallMinutes).IsRequired();
            Property(a => a.Price).IsRequired();
            Property(a => a.PriceIncVat).IsRequired();
        }
    }
}
