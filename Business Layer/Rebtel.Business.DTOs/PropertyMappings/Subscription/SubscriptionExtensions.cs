using System.Collections.Generic;
using Mapster;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DTOs
{
    public static class SubscriptionMappingExtensions
    {
        /// <summary>
        /// Map Entity TO DetailsDTO
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static SubscriptionDetailDTO ToDetailsDTO(this SubscriptionEntity source)
        {
            return TypeAdapter.Adapt<SubscriptionEntity, SubscriptionDetailDTO>(source);
        }

        /// <summary>
        /// Map Entity TO ListDTO
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static IEnumerable<SubscriptionListDTO> ToListDTO(this IEnumerable<SubscriptionEntity> source)
        {
            return TypeAdapter.Adapt<IEnumerable<SubscriptionEntity>, IEnumerable<SubscriptionListDTO>>(source);
        }

        /// <summary>
        /// Map CreateDTO to Entity
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <returns></returns>
        public static SubscriptionEntity ToDomainEntity(this SubscriptionCreateDTO source)
        {
            return TypeAdapter.Adapt<SubscriptionCreateDTO, SubscriptionEntity>(source);
        }

        /// <summary>
        /// Map UpdateDTO to Entity
        /// </summary>
        /// <param name="source">Source Object</param>
        /// <param name="subscription">Destination Object</param>
        /// <returns></returns>
        public static SubscriptionEntity ToDomainEntity(this SubscriptionUpdateDTO source, SubscriptionEntity subscription)
        {
            return TypeAdapter.Adapt(source, subscription);
        }
    }
}
