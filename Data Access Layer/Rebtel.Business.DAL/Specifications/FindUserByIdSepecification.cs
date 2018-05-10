using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.Specifications
{
    public class FindUserByIdSepecification : Specification<UserEntity, string>
    {
        public FindUserByIdSepecification(string id) : base(a => a.Id == id)
        {
            AddInclude(a => a.UserSubscriptions);
            AddInclude("UserSubscriptions.Subscription");
        }
    }
}
