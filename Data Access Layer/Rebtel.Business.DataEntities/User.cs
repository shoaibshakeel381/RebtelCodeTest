using System.Collections.Generic;

namespace Rebtel.Business.DataEntities
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
