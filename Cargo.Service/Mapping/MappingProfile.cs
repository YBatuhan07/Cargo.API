using AutoMapper;
using Cargo.Repository.Entities;
using Cargo.Service.Dto.Order;

namespace Cargo.Service.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOrderRequest, Order>().ReverseMap();
        CreateMap<OrderResponse, Order>().ReverseMap();
    }
}
