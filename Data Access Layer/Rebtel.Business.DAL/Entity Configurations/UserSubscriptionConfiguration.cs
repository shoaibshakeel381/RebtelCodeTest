using System.Data.Entity.ModelConfiguration;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.EntityConfigurations
{
    class UserSubscriptionConfiguration : EntityTypeConfiguration<UserSubscriptionEntity>
    {
        public UserSubscriptionConfiguration()
        {
            ToTable("UserSubscription");
            HasKey(a => new {a.UserId, a.SubscriptionId});

            HasRequired(a => a.UserEntity)
                .WithMany(a => a.UserSubscriptions)
                .HasForeignKey(a => a.UserId);

            HasRequired(a => a.Subscription)
                .WithMany(a => a.UserSubscriptions)
                .HasForeignKey(a => a.SubscriptionId);
        }
    }
}
