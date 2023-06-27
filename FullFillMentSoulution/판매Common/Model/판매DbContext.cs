using Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace 판매Common.Model
{
    public class 판매DbContext : DbContext
    {
        public 판매DbContext(DbContextOptions<판매DbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 판매자Configuration());
            modelBuilder.ApplyConfiguration(new 판매자상품Configuration());
            modelBuilder.ApplyConfiguration(new 판매대기Configuration());
            modelBuilder.ApplyConfiguration(new 판매중Configuration());
            modelBuilder.ApplyConfiguration(new 판매완료Configuration());
        }
    }
    public class 판매자Configuration : CenterConfiguration<판매자>
    {
        public override void Configure(EntityTypeBuilder<판매자> builder)
        {
            base.Configure(builder);
        }
    }
    public class 판매자상품Configuration : EntityConfiguration<판매자상품>
    {
        public override void Configure(EntityTypeBuilder<판매자상품> builder)
        {
            base.Configure(builder);
        }
    }
    public class 판매대기Configuration : EntityConfiguration<판매대기>
    {
        public override void Configure(EntityTypeBuilder<판매대기> builder)
        {
            base.Configure(builder);
        }
    }
    public class 판매중Configuration : EntityConfiguration<판매중>
    {
        public override void Configure(EntityTypeBuilder<판매중> builder)
        {
            base.Configure(builder);
        }
    }
    public class 판매완료Configuration : EntityConfiguration<판매완료>
    {
        public override void Configure(EntityTypeBuilder<판매완료> builder)
        {
            base.Configure(builder);
        }
    }

}