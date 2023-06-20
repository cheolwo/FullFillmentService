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
            modelBuilder.ApplyConfiguration(new 할일목록Configuration());
            modelBuilder.ApplyConfiguration(new 상품문의Configuration());
            modelBuilder.ApplyConfiguration(new 댓글Configuration());
            modelBuilder.ApplyConfiguration(new 판매자판매정보요약Configuration());
            modelBuilder.ApplyConfiguration(new 판매자상품판매정보요약Configuration());
            modelBuilder.ApplyConfiguration(new 주문자구매요약Configuration());
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
    public class 할일목록Configuration : EntityConfiguration<할일목록>
    {
        public override void Configure(EntityTypeBuilder<할일목록> builder)
        {
            base.Configure(builder);

            // 할일목록 엔티티에 대한 테이블 구성
            builder.ToTable("할일목록"); // 테이블 이름 설정

            // 속성 구성
            builder.Property(e => e.우선순위).HasMaxLength(50);
            builder.Property(e => e.상태).HasMaxLength(50);

        }
    }

    public class 상품문의Configuration : EntityConfiguration<상품문의>
    {
        public override void Configure(EntityTypeBuilder<상품문의> builder)
        {
            base.Configure(builder);

            // 상품문의 엔티티에 대한 테이블 구성
            builder.ToTable("상품문의"); // 테이블 이름 설정

            // 속성 구성
            builder.Property(e => e.Content).HasMaxLength(500);

        }
    }

    public class 댓글Configuration : EntityConfiguration<댓글>
    {
        public override void Configure(EntityTypeBuilder<댓글> builder)
        {
            base.Configure(builder);

            // 댓글 엔티티에 대한 테이블 구성
            builder.ToTable("댓글"); // 테이블 이름 설정

        }
    }

    public class 판매자판매정보요약Configuration : EntityConfiguration<판매자판매정보요약>
    {
        public override void Configure(EntityTypeBuilder<판매자판매정보요약> builder)
        {
            base.Configure(builder);

            // 판매자판매정보요약 엔티티에 대한 테이블 구성
            builder.ToTable("판매자판매정보요약"); // 테이블 이름 설정
            builder.HasKey(e => new { e.판매자Id });
        }
    }

    public class 판매자상품판매정보요약Configuration : EntityConfiguration<판매자상품판매정보요약>
    {
        public override void Configure(EntityTypeBuilder<판매자상품판매정보요약> builder)
        {
            base.Configure(builder);

            // 판매자상품판매정보요약 엔티티에 대한 테이블 구성
            builder.ToTable("판매자상품판매정보요약"); // 테이블 이름 설정
            builder.HasKey(e => new { e.판매자상품Id, e.판매자Id });
        }
    }
    public class 주문자구매요약Configuration : EntityConfiguration<주문자구매요약>
    {
        public override void Configure(EntityTypeBuilder<주문자구매요약> builder)
        {
            base.Configure(builder);

            // 주문자구매요약 엔티티에 대한 테이블 구성
            builder.ToTable("주문자구매요약"); // 테이블 이름 설정

        }
    }
}

