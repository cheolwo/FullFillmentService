using AutoMapper;
using 주문Common;
using 주문Common.Model;

namespace OrderCommon.Mapper
{
    public class 주문Profile : Profile
    {
        public 주문Profile()
        {
            CreateMap<OrderRequestModel, 주문>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.OrderQuantity))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OrderName));
        }
    }
}
