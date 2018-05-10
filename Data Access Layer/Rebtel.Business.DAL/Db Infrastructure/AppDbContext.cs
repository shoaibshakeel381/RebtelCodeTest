using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Db_Infrastructure;
using Rebtel.Business.DAL.ModelConfigurations;

namespace Rebtel.Business.DAL.Infrastructure
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

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw new DbValidationException(ParseValidationErrors(e));
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Add Model Configurations
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new SubscriptionConfiguration());
            modelBuilder.Configurations.Add(new UserSubscriptionConfiguration());
        }



        /// <summary> Parses DbValidationException and adds errors to ModelState.</summary>
        /// <param name="e"> Details of the exception.</param>
        /// <returns> formatted error messages as a single string.</returns>
        protected List<string> ParseValidationErrors(DbEntityValidationException e)
        {
            var errorsList = new List<string>();

            var errors = e.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors);
            foreach (var error in errors)
            {
                errorsList.Add($"{error.PropertyName} => {error.ErrorMessage}");
            }

            return errorsList;
        }
    }
}
