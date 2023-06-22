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
            modelBuilder.ApplyConfiguration(new 주문상품Configuration());
            modelBuilder.ApplyConfiguration(new 주문대기Configuration());
            modelBuilder.ApplyConfiguration(new 주문중Configuration());
            modelBuilder.ApplyConfiguration(new 주문완료Configuration());
        }
    }
    public class 주문자Configuration : CenterConfiguration<주문자>
    {
        public override void Configure(EntityTypeBuilder<주문자> builder)
        {
            base.Configure(builder);
        }
    }
    public class 주문상품Configuration : CommodityConfiguration<주문상품>
    {
        public override void Configure(EntityTypeBuilder<주문상품> builder)
        {
            base.Configure(builder);
        }
    }
    public class 주문대기Configuration : StatusConfiguration<주문대기>
    {
        public override void Configure(EntityTypeBuilder<주문대기> builder)
        {
            base.Configure(builder);
        }
    }
    public class 주문중Configuration : StatusConfiguration<주문중>
    {
        public override void Configure(EntityTypeBuilder<주문중> builder)
        {
            base.Configure(builder);
        }
    }
    public class 주문완료Configuration : StatusConfiguration<주문완료>
    {
        public override void Configure(EntityTypeBuilder<주문완료> builder)
        {
            base.Configure(builder);
        }
    }
}

