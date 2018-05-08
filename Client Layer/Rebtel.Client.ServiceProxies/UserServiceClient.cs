using System;
using System.Collections.Generic;
using System.ServiceModel;
using Rebtel.Client.Entities;
using Rebtel.Client.ServiceContracts;

namespace Rebtel.Client.ServiceProxies
{
    public class UserServiceClient : ClientBase<IUserService>, IUserService
    {
        public IEnumerable<UserListDTO> GetAll()
        {
            return Channel.GetAll();
        }

        public UserDetailDTO Get(string id)
        {
            return Channel.Get(id);
        }

        public bool Delete(string id)
        {
            return Channel.Delete(id);
        }

        public string Create(UserCreateDTO user)
        {
            return Channel.Create(user);
        }

        public bool Subscribe(string userId, string subscriptionId)
        {
            return Channel.Subscribe(userId, subscriptionId);
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
