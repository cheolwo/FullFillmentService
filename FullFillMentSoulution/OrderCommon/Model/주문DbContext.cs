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
            modelBuilder.ApplyConfiguration(new ���ϸ��Configuration());
            modelBuilder.ApplyConfiguration(new ��ǰ����Configuration());
            modelBuilder.ApplyConfiguration(new ���Configuration());
            modelBuilder.ApplyConfiguration(new �Ǹ����Ǹ��������Configuration());
            modelBuilder.ApplyConfiguration(new �Ǹ��ڻ�ǰ�Ǹ��������Configuration());
            modelBuilder.ApplyConfiguration(new �ֹ��ڱ��ſ��Configuration());
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
    public class ���ϸ��Configuration : EntityConfiguration<���ϸ��>
    {
        public override void Configure(EntityTypeBuilder<���ϸ��> builder)
        {
            base.Configure(builder);

            // ���ϸ�� ��ƼƼ�� ���� ���̺� ����
            builder.ToTable("���ϸ��"); // ���̺� �̸� ����

            // �Ӽ� ����
            builder.Property(e => e.�켱����).HasMaxLength(50);
            builder.Property(e => e.����).HasMaxLength(50);

        }
    }

    public class ��ǰ����Configuration : EntityConfiguration<��ǰ����>
    {
        public override void Configure(EntityTypeBuilder<��ǰ����> builder)
        {
            base.Configure(builder);

            // ��ǰ���� ��ƼƼ�� ���� ���̺� ����
            builder.ToTable("��ǰ����"); // ���̺� �̸� ����

            // �Ӽ� ����
            builder.Property(e => e.Content).HasMaxLength(500);

        }
    }

    public class ���Configuration : EntityConfiguration<���>
    {
        public override void Configure(EntityTypeBuilder<���> builder)
        {
            base.Configure(builder);

            // ��� ��ƼƼ�� ���� ���̺� ����
            builder.ToTable("���"); // ���̺� �̸� ����

        }
    }

    public class �Ǹ����Ǹ��������Configuration : EntityConfiguration<�Ǹ����Ǹ��������>
    {
        public override void Configure(EntityTypeBuilder<�Ǹ����Ǹ��������> builder)
        {
            base.Configure(builder);

            // �Ǹ����Ǹ�������� ��ƼƼ�� ���� ���̺� ����
            builder.ToTable("�Ǹ����Ǹ��������"); // ���̺� �̸� ����
            builder.HasKey(e => new { e.�Ǹ���Id });
        }
    }

    public class �Ǹ��ڻ�ǰ�Ǹ��������Configuration : EntityConfiguration<�Ǹ��ڻ�ǰ�Ǹ��������>
    {
        public override void Configure(EntityTypeBuilder<�Ǹ��ڻ�ǰ�Ǹ��������> builder)
        {
            base.Configure(builder);

            // �Ǹ��ڻ�ǰ�Ǹ�������� ��ƼƼ�� ���� ���̺� ����
            builder.ToTable("�Ǹ��ڻ�ǰ�Ǹ��������"); // ���̺� �̸� ����
            builder.HasKey(e => new { e.�Ǹ��ڻ�ǰId, e.�Ǹ���Id });
        }
    }
    public class �ֹ��ڱ��ſ��Configuration : EntityConfiguration<�ֹ��ڱ��ſ��>
    {
        public override void Configure(EntityTypeBuilder<�ֹ��ڱ��ſ��> builder)
        {
            base.Configure(builder);

            // �ֹ��ڱ��ſ�� ��ƼƼ�� ���� ���̺� ����
            builder.ToTable("�ֹ��ڱ��ſ��"); // ���̺� �̸� ����

        }
    }
}

