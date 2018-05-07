using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.Services.ServiceContracts
{
    [ServiceContract]
    public interface ISubscriptionService
    {
        [OperationContract]
        IEnumerable<Subscription> GetAll();

        [OperationContract]
        Subscription Get(int id);

        [OperationContract]
        int Create(Subscription subscription);

        [OperationContract]
        int Update(Subscription subscription);

        [OperationContract]
        bool Delete(int id);
    }
}
