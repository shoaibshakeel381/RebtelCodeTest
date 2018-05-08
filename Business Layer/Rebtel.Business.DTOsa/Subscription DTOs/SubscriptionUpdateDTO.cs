using System.Runtime.Serialization;

namespace Rebtel.Business.DTOs
{
    [DataContract]
    public class SubscriptionUpdateDTO : IExtensibleDataObject
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public double PriceIncVat { get; set; }

        [DataMember]
        public int CallMinutes { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}
