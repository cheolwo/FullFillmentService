using Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using 판매Common;

namespace 주문판매Common
{
    public class 주문판매DbContext : DbContext
    {
        public 주문판매DbContext(DbContextOptions<주문판매DbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 주문Configuration());
            modelBuilder.ApplyConfiguration(new 상품문의Configuration());
            modelBuilder.ApplyConfiguration(new 댓글Configuration());
        }
    }
    public class 상품문의Configuration : EntityConfiguration<상품문의>
    {
        public override void Configure(EntityTypeBuilder<상품문의> builder)
        {
            base.Configure(builder);

            builder.ToTable("상품문의"); 
            builder.Property(e => e.Content).HasMaxLength(500);

        }
    }
    public class 댓글Configuration : EntityConfiguration<댓글>
    {
        public override void Configure(EntityTypeBuilder<댓글> builder)
        {
            base.Configure(builder);
            builder.ToTable("댓글"); 

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