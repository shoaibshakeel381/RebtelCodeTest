using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Rebtel.Client.Entities
{
    public class SubscriptionDetailDTO : IExtensibleDataObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double PriceIncVat { get; set; }

        public int CallMinutes { get; set; }

        [JsonIgnore]
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
