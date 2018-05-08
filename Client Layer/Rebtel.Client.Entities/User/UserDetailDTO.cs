using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Rebtel.Client.Entities
{
    public class UserDetailDTO : IExtensibleDataObject
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public double TotalPriceIncVatAmount => Subscriptions.Sum(subscription => subscription.PriceIncVat);

        public double TotalCallMinutes => Subscriptions.Sum(subscription => subscription.CallMinutes);

        public IEnumerable<UserSubscriptionDetailDTO> Subscriptions { get; set; }

        [JsonIgnore]
        public ExtensionDataObject ExtensionData { get; set; }

        public UserDetailDTO()
        {
            Subscriptions = new List<UserSubscriptionDetailDTO>();
        }
    }
}
