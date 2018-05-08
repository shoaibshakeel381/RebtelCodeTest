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
        public double TotalPriceIncVatAmount => Subscriptions.Sum(subscription => subscription.PriceIncVat);

        [DataMember]
        public double TotalCallMinutes => Subscriptions.Sum(subscription => subscription.CallMinutes);

        [DataMember]
        public IEnumerable<SubscriptionDetailDTO> Subscriptions { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }

        public UserDetailDTO()
        {
            Subscriptions = new List<SubscriptionDetailDTO>();
        }
    }
}
