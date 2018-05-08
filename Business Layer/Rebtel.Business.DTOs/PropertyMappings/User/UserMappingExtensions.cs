using System.Collections.Generic;
using Mapster;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DTOs
{
    public static class UserMappingExtensions
    {
        /// <summary>
        /// Map Entity TO DetailsDTO
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static UserDetailDTO ToDetailsDTO(this UserEntity source)
        {
            return TypeAdapter.Adapt<UserEntity, UserDetailDTO>(source);
        }

        /// <summary>
        /// Map Entity TO ListDTO
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static IEnumerable<UserListDTO> ToListDTO(this IEnumerable<UserEntity> source)
        {
            return TypeAdapter.Adapt<IEnumerable<UserEntity>, IEnumerable<UserListDTO>>(source);
        }

        /// <summary>
        /// Map Entity TO ListDTO
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static UserSubscriptionDetailDTO ToUserSubscriptionDetailDTO(this SubscriptionEntity source)
        {
            return TypeAdapter.Adapt<SubscriptionEntity, UserSubscriptionDetailDTO>(source);
        }

        /// <summary>
        /// Map CreateDTO to Entity
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static UserEntity ToDomainEntity(this UserCreateDTO source)
        {
            return TypeAdapter.Adapt<UserCreateDTO, UserEntity>(source);
        }
    }
}
