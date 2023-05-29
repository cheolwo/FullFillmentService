using AutoMapper;
using MVVMToolkit.Blazor.SampleApp.ViewModels;
using OrderCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderCommon.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderRequestModel, Order>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.OrderQuantity))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OrderName))
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.OrdererId, opt => opt.Ignore())
                .ForMember(dest => dest.SellerCommodityId, opt => opt.Ignore())
                .ForMember(dest => dest.Price, opt => opt.Ignore())
                .ForMember(dest => dest.SellerCommodity, opt => opt.Ignore())
                .ForMember(dest => dest.Orderer, opt => opt.Ignore());
        }
    }
}
