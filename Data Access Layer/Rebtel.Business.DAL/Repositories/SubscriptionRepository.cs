using System;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;

namespace Rebtel.Business.DAL.Repositories
{
    public class SubscriptionRepository : GenericRepository<SubscriptionEntity, string>, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext dbContext) 
            : base(dbContext)
        {
        }

        public override void Create(SubscriptionEntity entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            base.Create(entity);
        }
    }
}
