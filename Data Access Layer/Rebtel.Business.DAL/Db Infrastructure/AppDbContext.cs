using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Db_Infrastructure;
using Rebtel.Business.DAL.ModelConfigurations;

namespace Rebtel.Business.DAL.DbInfrastructure
{
    public class AppDbContext : DbContext
    {
        #region DbSets
        public virtual DbSet<UserEntity> Users { get; set; }

        public virtual DbSet<SubscriptionEntity> Subscriptions { get; set; }
        #endregion

        /**
         * Constructor
         */
        public AppDbContext() : base("ConnectionString")
        {
            Database.SetInitializer(new AppDbInitializerDbNotExists());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Add Model Configurations
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new SubscriptionConfiguration());
            modelBuilder.Configurations.Add(new UserSubscriptionConfiguration());
        }
    }
}
