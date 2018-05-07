using System;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;

namespace Rebtel.Business.DAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>
    {
        public UserRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {
            
        }

        public override void Create(UserEntity entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            base.Create(entity);
        }
    }
}
