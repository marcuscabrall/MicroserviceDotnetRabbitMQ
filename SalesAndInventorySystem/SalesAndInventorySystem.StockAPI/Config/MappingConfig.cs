using AutoMapper;
using SalesAndInventorySystem.InventoryAPI.Data.ValueObjects;
using SalesAndInventorySystem.InventoryAPI.Model;

namespace SalesAndInventorySystem.InventoryAPI.Config

{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {

            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
