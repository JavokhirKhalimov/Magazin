using AutoMapper;
using Magazin.Services.ProductAPI.Models;
using Magazin.Services.ProductAPI.Models.DTO;

namespace Magazin.Services.ProductAPI
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Product>();
                config.CreateMap<Product, ProductDTO>();

            });
            return mapperConfig;
        }
    }
}
