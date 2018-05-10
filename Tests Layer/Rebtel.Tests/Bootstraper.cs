using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.Services;
using Rebtel.Business.Services.ServiceContracts;

namespace Rebtel.Tests
{
    public class Bootstraper
    {
        public static ISubscriptionService GetSubsriptionService()
        {
            return new SubscriptionService(GetRepositoryFactory(), GetDbContextScopeFactory());
        }

        public static IUserService GetUserService()
        {
            return new UserService(GetRepositoryFactory(), GetDbContextScopeFactory());
        }

        public static IRepositoryFactory GetRepositoryFactory()
        {
            return new RepositoryFactory<AppDbContext>(new AmbientDbContextLocator());
        }

        public static IAmbientDbContextLocator GetAmbientDbContextLocator()
        {
            return new AmbientDbContextLocator();
        }

        public static IDbContextScopeFactory GetDbContextScopeFactory()
        {
            return new DbContextScopeFactory();
        }
    }
}
