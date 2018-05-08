using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        void AddUserSubscription(UserEntity user, SubscriptionEntity subscription);
    }
}
