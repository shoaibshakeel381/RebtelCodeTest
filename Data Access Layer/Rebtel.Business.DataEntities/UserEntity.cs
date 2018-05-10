using System.Collections.Generic;

namespace Rebtel.Business.DataEntities
{
    public class UserEntity : BaseEntity<string>
    {   
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        public virtual ICollection<UserSubscriptionEntity> UserSubscriptions { get; set; }
    }
}
