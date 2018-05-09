using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Client.Entities;

namespace Rebtel.Client.ServiceContracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        IEnumerable<UserListDTO> GetAll();

        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        UserDetailDTO Get(string id);

        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        string Create(UserCreateDTO user);

        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        bool Subscribe(string userId, string subscriptionId);

        [OperationContract]
        [FaultContract(typeof(FaultResponseDTO))]
        bool Delete(string id);
    }
}
