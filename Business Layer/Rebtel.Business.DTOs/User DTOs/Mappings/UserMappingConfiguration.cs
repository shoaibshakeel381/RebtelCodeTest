using Rebtel.Business.DataEntities;
using Mapster;

namespace Rebtel.Business.DTOs.UserDTOs.Mappings
{
    public class UserMappingConfiguration : IPropertyMappingConfiguration
    {
        public void Configuration()
        {
            TypeAdapterConfig<UserCreateDTO, UserEntity>.NewConfig();

            TypeAdapterConfig<UserEntity, UserDetailDTO>.NewConfig();
        }
    }
}
