using AutoMapper;
using 주문Common;
using 주문Common.Model;

namespace OrderCommon.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderRequestModel, 주문>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.OrderQuantity))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OrderName));
        }
    }
}
