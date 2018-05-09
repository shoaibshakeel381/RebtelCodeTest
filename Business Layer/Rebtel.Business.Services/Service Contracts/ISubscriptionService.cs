using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Business.DTOs;

namespace Rebtel.Business.Services.ServiceContracts
{
    [ServiceContract]
    public interface ISubscriptionService
    {
        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        IEnumerable<SubscriptionListDTO> GetAll();

        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        SubscriptionDetailDTO Get(string id);

        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        string Create(SubscriptionCreateDTO subscription);

        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        string Update(SubscriptionUpdateDTO subscription);

        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        bool Delete(string id);
    }
}
