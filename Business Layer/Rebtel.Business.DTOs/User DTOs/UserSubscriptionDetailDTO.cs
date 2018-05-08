using System.Runtime.Serialization;

namespace Rebtel.Business.DTOs
{
    [DataContract]
    public class UserSubscriptionDetailDTO
    {
        [DataMember]
        public string Id { get; set; }
        
        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public double PriceIncVat { get; set; }

        [DataMember]
        public int CallMinutes { get; set; }
    }
}
