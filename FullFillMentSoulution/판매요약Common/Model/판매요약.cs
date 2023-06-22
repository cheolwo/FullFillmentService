using Common.Configuration;
using Common.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace 판매요약Common.Model
{
    public class 판매자판매정보요약 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string 판매자Id { get; set; }
        public List<판매자상품판매정보요약>? 판매자상품판매정보요약들 { get; set; }
    }
    public class 판매자상품판매정보요약 : Entity
    {
        [Key]
        public string Id { get; set; }
        public string 판매자상품Id { get; set; }
        public string 판매자Id { get; set; }
        public List<주문자구매요약> 주문자구매요약 { get; set; }
    }
    public class 주문자구매요약 : Entity
    {
        [Key]
        public string Id { get; set; }
        public DateTime 구매일시 { get; set; }
        public string 총구매가격 { get; set; }
        public string 총수량 { get; set; }
        public 판매자상품판매정보요약 판매자상품판매정보요약 { get; set; }
        public string 판매자상품판매정보요약Id { get; set; }
        public string 판매자Id { get; set; }
        public string 판매자상품Id { get; set; }
        public string 주문자Id { get; set; }
    }
    public class 판매자판매정보요약Configuration : EntityConfiguration<판매자판매정보요약>
    {
        public override void Configure(EntityTypeBuilder<판매자판매정보요약> builder)
        {
            base.Configure(builder);
        }
    }

    public class 판매자상품판매정보요약Configuration : EntityConfiguration<판매자상품판매정보요약>
    {
        public override void Configure(EntityTypeBuilder<판매자상품판매정보요약> builder)
        {
            base.Configure(builder);
        }
    }
    public class 주문자구매요약Configuration : EntityConfiguration<주문자구매요약>
    {
        public override void Configure(EntityTypeBuilder<주문자구매요약> builder)
        {
            base.Configure(builder);
        }
    }
}