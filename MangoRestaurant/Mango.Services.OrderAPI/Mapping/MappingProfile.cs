using AutoMapper;
using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Models.DTOs;

namespace Mango.Services.OrderAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
        }
    }
}
