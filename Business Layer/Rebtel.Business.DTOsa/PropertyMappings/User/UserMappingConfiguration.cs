using System;
using Mapster;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DTOs
{
    public class UserMappingConfiguration : IPropertyMappingConfiguration
    {
        public void Configuration()
        {
            TypeAdapterConfig<UserCreateDTO, UserEntity>.NewConfig()
                .Map(a => a.Id, Guid.NewGuid().ToString());

            TypeAdapterConfig<UserEntity, UserDetailDTO>.NewConfig();

            TypeAdapterConfig<UserEntity, UserListDTO>.NewConfig();
        }
    }
}
