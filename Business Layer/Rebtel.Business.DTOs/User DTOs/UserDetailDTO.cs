using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Rebtel.Business.DTOs
{
    [DataContract]
    public class UserDetailDTO : IExtensibleDataObject
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public IEnumerable<UserSubscriptionDetailDTO> Subscriptions { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }

        public UserDetailDTO()
        {
            Subscriptions = new List<UserSubscriptionDetailDTO>();
        }
    }
}
