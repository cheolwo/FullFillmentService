using Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using 주문Common.Model;

namespace OrderCommon.Model
{
    public class 주문DbContext : DbContext
    {
        public 주문DbContext(DbContextOptions<주문DbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 주문자Configuration());
            modelBuilder.ApplyConfiguration(new 판매자Configuration());
            modelBuilder.ApplyConfiguration(new 판매자상품Configuration());
            modelBuilder.ApplyConfiguration(new 주문Configuration());
        }
    }
    public class 주문자Configuration : CenterConfiguration<주문자>
    {
        public override void Configure(EntityTypeBuilder<주문자> builder)
        {
            base.Configure(builder);
        }
    }
    public class 판매자Configuration : CenterConfiguration<판매자>
    {
        public override void Configure(EntityTypeBuilder<판매자> builder)
        {
            base.Configure(builder);
        }
    }
    public class 판매자상품Configuration : CommodityConfiguration<판매자상품>
    {
        public override void Configure(EntityTypeBuilder<판매자상품> builder)
        {
            base.Configure(builder);
        }
    }
    public class 주문Configuration : EntityConfiguration<주문>
    {
        public override void Configure(EntityTypeBuilder<주문> builder)
        {
            base.Configure(builder);
        }
    }
}

