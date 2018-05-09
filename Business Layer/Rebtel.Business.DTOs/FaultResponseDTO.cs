using System.Runtime.Serialization;
using Rebtel.Core.Infrastructure;

namespace Rebtel.Business.DTOs
{
    [DataContract]
    public class FaultResponseDTO
    {
        [DataMember]
        public ResultCode Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        public FaultResponseDTO(ResultCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
