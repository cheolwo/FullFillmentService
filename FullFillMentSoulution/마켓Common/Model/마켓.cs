using Common.Configuration;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace 마켓Common.Model
{
    public class 마켓 : Center
    {
        [Key]
        public string Id { get; set; }
    }
    public class 마켓상품 : Commodity
    {
        [Key]
        public string Id { get; set; }
        public string? UserId { get; set; }

    }
    public class 협상대기 : Status
    {
        [Key]
        public string Id { get; set; }
    }
    public class 협상중 : Status
    {
        [Key]
        public string Id { get; set; }
    }
    public class 협상완료 : Status
    {
        [Key]
        public string Id { get; set; }
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