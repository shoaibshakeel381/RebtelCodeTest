using System.Runtime.Serialization;

namespace Rebtel.Business.DTOs
{
    [DataContract]
    public class UserListDTO
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}
