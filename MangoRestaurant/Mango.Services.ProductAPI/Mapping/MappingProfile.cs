using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.DTOs;

namespace Mango.Services.ProductAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
