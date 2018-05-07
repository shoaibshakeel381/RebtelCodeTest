using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.Services.ServiceContracts
{
    [ServiceContract]
    public interface ISubscriptionService
    {
        [OperationContract]
        IEnumerable<SubscriptionEntity> GetAll();

        [OperationContract]
        SubscriptionEntity Get(string id);

        [OperationContract]
        string Create(SubscriptionEntity subscription);

        [OperationContract]
        string Update(SubscriptionEntity subscription);

        [OperationContract]
        bool Delete(string id);
    }
}
