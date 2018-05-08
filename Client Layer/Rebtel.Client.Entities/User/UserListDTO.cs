using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Rebtel.Client.Entities
{
    public class UserListDTO : IExtensibleDataObject
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
