using Mapster;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DTOs.User_DTOs.Mappings
{
    public static class UserMappingExtensions
    {
        /// <summary>
        /// Map Entity TO DetailsDTO
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static UserDetailDTO ToDetailsDTO(this User source)
        {
            return TypeAdapter.Adapt<User, UserDetailDTO>(source);
        }

        /// <summary>
        /// Map CreateDTO to Entity
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static User ToDomainEntity(this UserCreateDTO source)
        {
            return TypeAdapter.Adapt<UserCreateDTO, User>(source);
        }
    }
}
