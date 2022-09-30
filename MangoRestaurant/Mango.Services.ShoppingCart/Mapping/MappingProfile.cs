using AutoMapper;
using Mango.Services.ShoppingCart.Models;
using Mango.Services.ShoppingCart.Models.DTOs;

namespace Mango.Services.ShoppingCart.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
        }
    }
}
