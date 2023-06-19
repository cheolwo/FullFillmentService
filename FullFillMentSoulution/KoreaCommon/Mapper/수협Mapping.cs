using AutoMapper;
using 수협Common.DTO;
using 수협Common.Model;

namespace 수협Common.Mapper
{
    public class 수협Mapping : Profile
    {
        public 수협Mapping()
        {
            CreateMap<수산협동조합, Read수산협동조합DTO>();
            CreateMap<Create수산협동조합DTO, 수산협동조합>();
            CreateMap<Update수산협동조합DTO, 수산협동조합>();

            CreateMap<수산창고, Read수산창고DTO>();
            CreateMap<Create수산창고DTO, 수산창고>();
            CreateMap<Update수산창고DTO, 수산창고>();

            CreateMap<수산품별재고현황, Read수산품별재고현황DTO>();
            CreateMap<Create수산품별재고현황DTO, 수산품별재고현황>();
            CreateMap<Update수산품별재고현황DTO, 수산품별재고현황>();

            CreateMap<수산품, Read수산품DTO>();
            CreateMap<Create수산품DTO, 수산품>();
            CreateMap<Update수산품DTO, 수산품>();
        }
    }
}
