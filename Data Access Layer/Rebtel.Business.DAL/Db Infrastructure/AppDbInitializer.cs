using System;
using System.Data.Entity;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;

namespace Rebtel.Business.DAL.Db_Infrastructure
{
    public class AppDbInitializerDbModelChanges : DropCreateDatabaseIfModelChanges<AppDbContext> //Set it to CreateDatabaseIfNotExists
    {
        protected override void Seed(AppDbContext db)
        {
            var initializer = new AppDbInitializer();
            initializer.Seed(db);

            base.Seed(db);
        }
    }

    public class AppDbInitializerDbNotExists : CreateDatabaseIfNotExists<AppDbContext> //Set it to CreateDatabaseIfNotExists
    {
        protected override void Seed(AppDbContext db)
        {
            var initializer = new AppDbInitializer();
            initializer.Seed(db);

            base.Seed(db);
        }
    }

    internal class AppDbInitializer
    {
        private AppDbContext _context;

        public void Seed(AppDbContext db)
        {
            var transaction = db.Database.BeginTransaction();
            _context = db;

            try
            {
                InsertUsers();
                InsertSubscriptions();

                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private void InsertUsers()
        {
            _context.Users.Add(new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "UserAFirstName",
                LastName = "UserALastName",
                Email = "usera@email.com"
            });

            _context.Users.Add(new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "UserBFirstName",
                LastName = "UserBLastName",
                Email = "userb@email.com"
            });
        }

        private void InsertSubscriptions()
        {
            _context.Subscriptions.Add(new SubscriptionEntity
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Subscription A",
                Price = 10.0,
                PriceIncVat = 12.5,
                CallMinutes = 240
            });

            _context.Subscriptions.Add(new SubscriptionEntity
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Subscription B",
                Price = 100.0,
                PriceIncVat = 120.5,
                CallMinutes = 2400
            });
        }
    }
}
