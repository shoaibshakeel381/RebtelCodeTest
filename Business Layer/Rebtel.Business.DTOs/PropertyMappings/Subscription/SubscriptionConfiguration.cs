using System;
using Mapster;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DTOs
{
    public class SubscriptionConfiguration : IPropertyMappingConfiguration
    {
        public void Configuration()
        {
            TypeAdapterConfig<SubscriptionCreateDTO, SubscriptionEntity>.NewConfig()
                .Map(a => a.Id, b => Guid.NewGuid().ToString());

            TypeAdapterConfig<SubscriptionUpdateDTO, SubscriptionEntity>.NewConfig();

            TypeAdapterConfig<SubscriptionEntity, SubscriptionDetailDTO>.NewConfig();

            TypeAdapterConfig<SubscriptionEntity, SubscriptionListDTO>.NewConfig();
        }
    }
}
