using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Configuration
{
    public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
            where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e=>e.Name).HasMaxLength(128);
            builder.Property(e=>e.Code).HasMaxLength(128);
            builder.Property(e => e.CreatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
    public class CommodityConfiguration<TEntity> : EntityConfiguration<TEntity> 
        where TEntity : Commodity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
        }
    }
    public class StatusConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : Status
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
        }
    }
    public class CenterConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : Center
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e=>e.PhoneNumber).HasMaxLength(128);
            builder.Property(e=>e.FaxNumber).HasMaxLength(128);
            builder.Property(e=>e.Email).HasMaxLength(128);
            builder.Property(e=>e.Address).HasMaxLength(128);

            base.Configure(builder);
        }
    }
}
