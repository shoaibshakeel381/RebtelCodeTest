using System;
using System.Linq;

namespace Rebtel.Business.DTOs
{
    /// <summary> Configure Property Mappings between DTOs and Domain Entities</summary>
    public static class PropertyMappingConfigurator
    {
        public static void Configure()
        {
            var mappings = typeof(IPropertyMappingConfiguration).Assembly.GetTypes()
                .Where(type => !type.IsAbstract && typeof(IPropertyMappingConfiguration).IsAssignableFrom(type)
                               && type.GetConstructor(Type.EmptyTypes) != null) // Must have Parameterless Constructor
                .Select(Activator.CreateInstance).Cast<IPropertyMappingConfiguration>();

            foreach (var mapping in mappings)
            {
                mapping.Configuration();
            }
        }
    }
}
