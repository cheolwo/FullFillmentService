using AutoMapper;
using Common.Configuration;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace 수협Common.Model
{
    public class 수협DbContext : DbContext
    {
        public 수협DbContext(DbContextOptions<수협DbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 수산협동조합Configuration());
            modelBuilder.ApplyConfiguration(new 수산창고Configuration());
            modelBuilder.ApplyConfiguration(new 수산품Configuration());
            modelBuilder.ApplyConfiguration(new 수산품별재고현황Configuration());
        }

    }
    public class 수산협동조합 : Center
    {
        public List<수산창고> 창고들 { get; set; }
        public List<수산품> 수산품들 { get; set; }
        public List<수산품별재고현황> 수산품별재고현황들 { get; set; }
    }
    public class 수산창고 : Center
    {
        public string? 수협Id { get; set; }
        public 수산협동조합 수협 { get; set; }
        public List<수산품> 수산품들 { get; set; }
        public List<수산품별재고현황> 수산품별재고현황들 { get; set; }
    }
    public class 수산품 : Entity
    {
        public string? 수협Id { get; set; }
        public string? 창고Id { get; set; }
        public 수산협동조합 수협 { get; set; }
        public 수산창고 창고 { get; set; }
        public List<수산품별재고현황> 수산품별재고현황들 { get; set; }
    }
    public class 수산품별재고현황 : Commodity
    {
        public string? 수협Id { get; set; }
        public string? 창고Id { get; set; }
        public string? 수산품Id { get; set; }
        public string? date { get; set; }
        public 수산협동조합 수협 { get; set; }
        public 수산창고 창고 { get; set; }
        public 수산품 수산품 { get; set; }
    }
    public class 수산협동조합Configuration : CenterConfiguration<수산협동조합>
    {
        public override void Configure(EntityTypeBuilder<수산협동조합> builder)
        {
            builder.HasKey(e => e.Code);
            base.Configure(builder);
        }
    }
    public class 수산창고Configuration : CenterConfiguration<수산창고>
    {
        public override void Configure(EntityTypeBuilder<수산창고> builder)
        {
            builder.HasKey(e => e.Code);
            base.Configure(builder);
        }
    }
    public class 수산품Configuration : EntityConfiguration<수산품>
    {
        public override void Configure(EntityTypeBuilder<수산품> builder)
        {
            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(e => e.Id);
            base.Configure(builder);
        }
    }
    public class 수산품별재고현황Configuration : CommodityConfiguration<수산품별재고현황> 
    {
        public override void Configure(EntityTypeBuilder<수산품별재고현황> builder)
        {

            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(e => e.Id);
            base.Configure(builder);
        }
    }
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {

            CreateMap<해양수산부.API.For조합창고품목별재고현황.Item, 수산품별재고현황>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.MprcStdCode))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MprcStdCodeNm))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.InvntryQy))
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Set as needed
            .ForMember(dest => dest.수협Id, opt => opt.Ignore()) // Set as needed
            .ForMember(dest => dest.창고Id, opt => opt.Ignore()) // Set as needed
            .ForMember(dest => dest.date, opt => opt.Ignore()) // Set as needed
            .ForMember(dest => dest.수협, opt => opt.Ignore()) // Set as needed
            .ForMember(dest => dest.창고, opt => opt.Ignore()) // Set as needed
            .ForMember(dest => dest.수산품, opt => opt.Ignore()) // Set as needed
            .ForAllMembers(opt => opt.NullSubstitute(string.Empty)); // 대체 값을 지정

            CreateMap<해양수산부.API.For산지조합.Item, 수산협동조합>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MxtrNm))
           .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.MxtrCode))
           .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FxNum))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.TelNo))
           .ForMember(dest => dest.Email, opt => opt.Ignore()) // Set as needed
           .ForMember(dest => dest.Address, opt => opt.Ignore()) // Set as needed
           .ForMember(dest => dest.ZipCode, opt => opt.Ignore()) // Set as needed
            .ForAllMembers(opt => opt.NullSubstitute(string.Empty)); // 대체 값을 지정

            CreateMap<해양수산부.API.For산지조합창고.Item, 수산창고>()
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

        }
    }
    public class MappingProfile2 : Profile
    {
        public MappingProfile2()
        {
            CreateMap<해양수산부.API.For산지조합창고.Item, 수산창고>()
                .ForMember(dest => dest.Email, opt => opt.Ignore())
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.WrhousCode))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.WrhousNm))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.TelNo))
            .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FxNum))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Zip))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.WrhousBassAdres} {src.WrhousDetailAdres}"))
            .ForMember(dest => dest.수협Id, opt => opt.MapFrom(src => src.MxtrCode))
            .ForMember(dest => dest.수협, opt => opt.Ignore())
            .ForMember(dest => dest.수산품들, opt => opt.Ignore())
            .ForMember(dest => dest.수산품별재고현황들, opt => opt.Ignore())
            .ForMember(dest => dest, opt => opt.MapFrom(src => src.Bldar))
            //Bldar
            .ForAllMembers(opt => opt.NullSubstitute(string.Empty)); // 대체 값을 지정
        }

    }

}
