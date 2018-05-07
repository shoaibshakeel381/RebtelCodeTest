using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Business.DTOs;

namespace Rebtel.Business.Services.ServiceContracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        IEnumerable<UserDetailDTO> GetAll();

        [OperationContract]
        UserDetailDTO Get(int id);

        [OperationContract]
        int Create(UserCreateDTO user);

        [OperationContract]
        bool Subscribe(int userId, int subscriptionId);

        [OperationContract]
        bool Delete(int id);
    }
}
