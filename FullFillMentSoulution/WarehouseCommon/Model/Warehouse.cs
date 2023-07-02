using Common.Configuration;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace 창고Common
{
    public class 창고DbContext : DbContext
    {
        public 창고DbContext(DbContextOptions<창고DbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 창고Configuration());
            modelBuilder.ApplyConfiguration(new 창고상품Configuration());
            modelBuilder.ApplyConfiguration(new 입고상품Configuration());
            modelBuilder.ApplyConfiguration(new 적재상품Configuration());
            modelBuilder.ApplyConfiguration(new 출고상품Configuration());
        }
    }
    public class 창고Configuration : CenterConfiguration<창고>
    {
        public override void Configure(EntityTypeBuilder<창고> builder)
        {
            base.Configure(builder);
        }
    }
    public class 창고상품Configuration : CommodityConfiguration<창고상품>
    {
        public override void Configure(EntityTypeBuilder<창고상품> builder)
        {
            base.Configure(builder);
        }
    }
    public class 입고상품Configuration : StatusConfiguration<입고상품>
    {
        public override void Configure(EntityTypeBuilder<입고상품> builder)
        {
            base.Configure(builder);
        }
    }
    public class 적재상품Configuration : StatusConfiguration<적재상품>
    {
        public override void Configure(EntityTypeBuilder<적재상품> builder)
        {
            base.Configure(builder);
        }
    }
    public class 출고상품Configuration : StatusConfiguration<출고상품>
    {
        public override void Configure(EntityTypeBuilder<출고상품> builder)
        {
            base.Configure(builder);
        }
    }
    public class 창고 : Center
    {
        public List<창고상품>? 창고상품들 { get; set; }
        public List<입고상품>? 입고상품들 { get; set; }
        public List<적재상품>? 적재상품들 { get; set; }
        public List<출고상품>? 출고상품들 { get; set; }
    }
    public class 창고상품 : Commodity
    {
        public string? 창고Id { get; set; }
        public 창고? 창고 { get; set; }
        public List<입고상품>? 입고상품들 { get; set; }
        public List<적재상품>? 적재상품들 { get; set; }
        public List<출고상품>? 출고상품들 { get; set; }
    }
    public class 입고상품 : Status
    {
        public string? 협상완료Id { get; set; }
        public string? 창고Id { get; set; }
        public string? 창고상품Id { get; set; }
        public 창고? 창고 { get; set; }
        public 창고상품? 창고상품 { get; set; }
        public List<적재상품>? 적재상품들 { get; set; }
        public List<출고상품>? 출고상품들 { get; set; }
    }
    public class 적재상품 : Status
    {
        public string? 창고Id { get; set; }
        public string? 창고상품Id { get; set; }
        public string? 입고상품Id { get; set; }
        public 창고? 창고 { get; set; }
        public 창고상품? 창고상품 { get; set; }
        public 입고상품? 입고상품 { get; set; }
        public List<출고상품>? 출고상품들 { get; set; }
    }
    public class 출고상품 : Status
    {
        public string? 주문Id { get; set; }
        public string? 창고Id { get; set; }
        public string? 창고상품Id { get; set; }
        public string? 입고상품Id { get; set; }
        public string? 적재상품Id { get; set; }
        public 창고? 창고 { get; set; }
        public 창고상품? 창고상품 { get; set; }
        public 입고상품? 입고상품 { get; set; }
        public 적재상품? 적재상품 { get; set; }
    }
}