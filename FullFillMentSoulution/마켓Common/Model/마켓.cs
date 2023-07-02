using Common.Configuration;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace 마켓Common.Model
{
    public class 마켓 : Center
    {
        public List<마켓상품> 마켓상품들 { get; set; }
        public List<협상주문> 협상주문들 { get; set; }
        public List<협상중> 협상중들 { get; set; }
        public List<협상완료> 협상완료들 { get; set; }
    }
    public class 마켓상품 : Commodity
    {
        public string? UserId { get; set; }
    }
    public class 협상주문
    {
        public string? 주문자Id { get; set; }
        public string? 수량 { get; set; }
        public string? Priced { get; set; }
    }
    public class 협상대기 : Status
    {
        public string? 판매자상품Id { get; set; }
        public double Price { get; set; }
        public List<협상주문>? 협상주문들 { get; set; } 
    }
    public class 협상중 : Status
    {
        [Key]
        public string Id { get; set; }
        public double Price { get; set; }
        public List<협상주문>? 협상주문들 { get; set; }
    }
    public class 협상완료 : Status
    {
        [Key]
        public string Id { get; set; }
        public double Price { get; set; }
        public List<협상주문>? 협상주문들 { get; set; }
        public 마켓 마켓 { get; set; }
        public 마켓상품 마켓상품 { get; set; }
        public 협상대기 협상대기 { get; set; }
        public 협상중 협상중 { get; set; }
        public 협상완료 협상완료 { get; set; }
    }
    public class 마켓DbContext : DbContext
    {
        public 마켓DbContext(DbContextOptions<마켓DbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 마켓Configuration());
            modelBuilder.ApplyConfiguration(new 마켓상품Configuration());
            modelBuilder.ApplyConfiguration(new 협상대기Configuration());
            modelBuilder.ApplyConfiguration(new 협상중Configuration());
            modelBuilder.ApplyConfiguration(new 협상완료Configuration());
        }
    }
    public class 마켓Configuration : CenterConfiguration<마켓>
    {
        public override void Configure(EntityTypeBuilder<마켓> builder)
        {
            base.Configure(builder);
        }
    }
    public class 마켓상품Configuration : CommodityConfiguration<마켓상품>
    {
        public override void Configure(EntityTypeBuilder<마켓상품> builder)
        {
            base.Configure(builder);
        }
    }
    public class 협상대기Configuration : StatusConfiguration<협상대기>
    {
        public override void Configure(EntityTypeBuilder<협상대기> builder)
        {
            base.Configure(builder);
        }
    }
    public class 협상중Configuration : StatusConfiguration<협상중>
    {
        public override void Configure(EntityTypeBuilder<협상중> builder)
        {
            base.Configure(builder);
        }
    }
    public class 협상완료Configuration : StatusConfiguration<협상완료>
    {
        public override void Configure(EntityTypeBuilder<협상완료> builder)
        {
            base.Configure(builder);
        }
    }
}