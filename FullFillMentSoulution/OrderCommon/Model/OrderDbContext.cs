using Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using �ֹ�Common.Model;

namespace OrderCommon.Model
{
    public class �ֹ�DbContext : DbContext
    {
        public �ֹ�DbContext(DbContextOptions<�ֹ�DbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new �ֹ���Configuration());
            modelBuilder.ApplyConfiguration(new �Ǹ���Configuration());
            modelBuilder.ApplyConfiguration(new �Ǹ��ڻ�ǰConfiguration());
            modelBuilder.ApplyConfiguration(new �ֹ�Configuration());
        }
    }
    public class �ֹ���Configuration : CenterConfiguration<�ֹ���>
    {
        public override void Configure(EntityTypeBuilder<�ֹ���> builder)
        {
            base.Configure(builder);
        }
    }
    public class �Ǹ���Configuration : CenterConfiguration<�Ǹ���>
    {
        public override void Configure(EntityTypeBuilder<�Ǹ���> builder)
        {
            base.Configure(builder);
        }
    }
    public class �Ǹ��ڻ�ǰConfiguration : CommodityConfiguration<�Ǹ��ڻ�ǰ>
    {
        public override void Configure(EntityTypeBuilder<�Ǹ��ڻ�ǰ> builder)
        {
            base.Configure(builder);
        }
    }
    public class �ֹ�Configuration : EntityConfiguration<�ֹ�>
    {
        public override void Configure(EntityTypeBuilder<�ֹ�> builder)
        {
            base.Configure(builder);
        }
    }
}

