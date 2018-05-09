using System.Data.Entity;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.Services;
using Rebtel.Business.Services.ServiceContracts;

namespace Rebtel.Tests
{
    public class Bootstraper
    {
        public static ISubscriptionService GetSubsriptionService(DbContext dbContext)
        {
            return new SubscriptionService(GetRepositoryFactory(), GetDbContextScopeFactory(dbContext));
        }

        public static IUserService GetUserService(DbContext dbContext)
        {
            return new UserService(GetRepositoryFactory(), GetDbContextScopeFactory(dbContext));
        }

        public static IRepositoryFactory GetRepositoryFactory()
        {
            return new RepositoryFactory(new AmbientDbContextLocator());
        }

        public static IAmbientDbContextLocator GetAmbientDbContextLocator()
        {
            return new AmbientDbContextLocator();
        }

        public static IDbContextScopeFactory GetDbContextScopeFactory(DbContext dbContext)
        {
            return new DbContextScopeFactory(new DbContextFactory(dbContext));
        }

        public class DbContextFactory : IDbContextFactory
        {
            private readonly DbContext _context;

            public DbContextFactory(DbContext context)
            {
                _context = context;
            }

            public TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext
            {
                return _context as TDbContext;
            }
        }
    }
}
