using AutoMapper;
using KoreaCommon.Model;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 매핑 구성
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<해양수산부.API.For산지조합창고.Item, 수산창고>()
                    .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.WrhousCode))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.WrhousNm))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.TelNo))
                    .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FxNum))
                    .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Zip))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.WrhousBassAdres} {src.WrhousDetailAdres}"))
                    .ForMember(dest => dest.수협Id, opt => opt.Ignore())
                    .ForMember(dest => dest.수협, opt => opt.Ignore())
                    .ForMember(dest => dest.수산품들, opt => opt.Ignore())
                    .ForMember(dest => dest.수산품별재고현황들, opt => opt.Ignore());
            });

            // 매핑 객체 생성
            IMapper mapper = config.CreateMapper();

            // 테스트 데이터 생성
            var source = new 해양수산부.API.For산지조합창고.Item
            {
                WrhousCode = "001",
                WrhousNm = "창고1",
                TelNo = "010-1234-5678",
                FxNum = null,
                Zip = "12345",
                WrhousBassAdres = "서울시 강남구",
                WrhousDetailAdres = "역삼동 123번지"
            };

            // 매핑 수행
            var destination = mapper.Map<해양수산부.API.For산지조합창고.Item, 수산창고>(source);

            // 매핑 결과 출력
            Console.WriteLine($"Code: {destination.Code}");
            Console.WriteLine($"Name: {destination.Name}");
            Console.WriteLine($"Phone Number: {destination.PhoneNumber}");
            Console.WriteLine($"Fax Number: {destination.FaxNumber}");
            Console.WriteLine($"Zip Code: {destination.ZipCode}");
            Console.WriteLine($"Address: {destination.Address}");

            Console.ReadLine();
        }
    }
}
