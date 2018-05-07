using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Business.DTOs;

namespace Rebtel.Business.Services.ServiceContracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        IEnumerable<UserListDTO> GetAll();

        [OperationContract]
        UserDetailDTO Get(string id);

        [OperationContract]
        string Create(UserCreateDTO user);

        [OperationContract]
        bool Subscribe(string userId, string subscriptionId);

        [OperationContract]
        bool Delete(string id);
    }
}
