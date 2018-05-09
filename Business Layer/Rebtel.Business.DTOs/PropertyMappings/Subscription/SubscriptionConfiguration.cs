using System;
using System.Collections.Generic;
using Mapster;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DTOs
{
    public class SubscriptionConfiguration : IPropertyMappingConfiguration
    {
        public void Configuration()
        {
            TypeAdapterConfig<SubscriptionCreateDTO, SubscriptionEntity>.NewConfig()
                .Map(a => a.Id, b => Guid.NewGuid().ToString())
                .Map(a => a.UserSubscriptions, b => new List<UserSubscriptionEntity>());

            TypeAdapterConfig<SubscriptionUpdateDTO, SubscriptionEntity>.NewConfig();

            TypeAdapterConfig<SubscriptionEntity, SubscriptionDetailDTO>.NewConfig();

            TypeAdapterConfig<SubscriptionEntity, SubscriptionListDTO>.NewConfig();
        }
    }
}
