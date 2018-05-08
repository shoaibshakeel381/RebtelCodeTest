using System;
using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Client.Entities;
using Rebtel.Client.ServiceContracts;

namespace Rebtel.Client.ServiceProxies
{
    public class SubscriptionServiceClient : ClientBase<ISubscriptionService>, ISubscriptionService
    {
        public string Create(SubscriptionCreateDTO subscription)
        {
            return Channel.Create(subscription);
        }

        public bool Delete(string id)
        {
            return Channel.Delete(id);
        }

        public SubscriptionDetailDTO Get(string id)
        {
            return Channel.Get(id);
        }

        public IEnumerable<SubscriptionListDTO> GetAll()
        {
            return Channel.GetAll();
        }

        public string Update(SubscriptionUpdateDTO subscription)
        {
            return Channel.Update(subscription);
        }

        public void CleanUp()
        {
            try
            {
                if (State != CommunicationState.Faulted)
                    Close();
                else
                    Abort();
            }
            catch (Exception)
            {
                Abort();
            }
        }
    }
}
