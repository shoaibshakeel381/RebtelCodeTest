using System;
using System.Collections.Generic;
using Mapster;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DTOs
{
    public class UserConfiguration : IPropertyMappingConfiguration
    {
        public void Configuration()
        {
            TypeAdapterConfig<UserCreateDTO, UserEntity>.NewConfig()
                .Map(a => a.Id, b => Guid.NewGuid().ToString())
                .Map(a => a.UserSubscriptions, b => new List<UserSubscriptionEntity>());

            TypeAdapterConfig<SubscriptionEntity, UserSubscriptionDetailDTO>.NewConfig();

            TypeAdapterConfig<UserEntity, UserDetailDTO>.NewConfig();

            TypeAdapterConfig<UserEntity, UserListDTO>.NewConfig();
        }
    }
}
