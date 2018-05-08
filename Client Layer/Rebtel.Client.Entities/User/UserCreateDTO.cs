using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Rebtel.Client.Entities
{
    public class UserCreateDTO : IExtensibleDataObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
