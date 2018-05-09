using System.Runtime.Serialization;
using Rebtel.Core.Infrastructure;

namespace Rebtel.Client.Entities
{
    public class FaultResponseDTO
    {
        public ResultCode Code { get; set; }
        
        public string Message { get; set; }
    }
}
