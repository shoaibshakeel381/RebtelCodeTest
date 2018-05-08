using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Client.Entities;

namespace Rebtel.Client.ServiceContracts
{
    [ServiceContract]
    public interface ISubscriptionService
    {
        [OperationContract]
        IEnumerable<SubscriptionListDTO> GetAll();

        [OperationContract]
        SubscriptionDetailDTO Get(string id);

        [OperationContract]
        string Create(SubscriptionCreateDTO subscription);

        [OperationContract]
        string Update(SubscriptionUpdateDTO subscription);

        [OperationContract]
        bool Delete(string id);
    }
}
