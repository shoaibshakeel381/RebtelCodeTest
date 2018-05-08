using System;
using Mapster;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DTOs
{
    public class SubscriptionMappingConfiguration : IPropertyMappingConfiguration
    {
        public void Configuration()
        {
            TypeAdapterConfig<SubscriptionCreateDTO, SubscriptionEntity>.NewConfig()
                .Map(a => a.Id, Guid.NewGuid().ToString());

            TypeAdapterConfig<SubscriptionUpdateDTO, SubscriptionEntity>.NewConfig();

            TypeAdapterConfig<SubscriptionEntity, SubscriptionDetailDTO>.NewConfig();

            TypeAdapterConfig<SubscriptionEntity, SubscriptionListDTO>.NewConfig();
        }
    }
}
