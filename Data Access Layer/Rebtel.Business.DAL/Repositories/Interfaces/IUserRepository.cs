using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity, string>
    {
        void AddUserSubscription(UserEntity user, SubscriptionEntity subscription);
    }
}
