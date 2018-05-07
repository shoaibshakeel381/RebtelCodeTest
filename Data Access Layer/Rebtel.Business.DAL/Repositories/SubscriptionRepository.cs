using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;

namespace Rebtel.Business.DAL.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>
    {
        protected SubscriptionRepository(IAmbientDbContextLocator ambientDbContextLocator) 
            : base(ambientDbContextLocator)
        {
        }
    }
}
