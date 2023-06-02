﻿using Common.Configuration;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KoreaCommon.Model
{
    public class 수협DbContext : DbContext
    {
        public 수협DbContext(DbContextOptions<수협DbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 수산협동조합Configuration());
            modelBuilder.ApplyConfiguration(new 수산창고Configuration());
            modelBuilder.ApplyConfiguration(new 수산품Configuration());
        }

    }
    public class 수산협동조합 : Center
    {
        public List<수산창고> 창고들 { get; set; }
    }
    public class 수산창고 : Center
    {
        public string 수협Id { get; set; }
        public 수산협동조합 수협 { get; set; }
        public List<수산품> 수산품들 { get; set; }
    }
    public class 수산품 : Commodity
    {
        public string 수협Id { get; set; }
        public string 창고Id { get; set; }
        public 수산협동조합 수협 { get; set; }
        public 수산창고 창고 { get; set; }
    }
    public class 수산협동조합Configuration : CenterConfiguration<수산협동조합>
    {
        public override void Configure(EntityTypeBuilder<수산협동조합> builder)
        {
            base.Configure(builder);
        }
    }
    public class 수산창고Configuration : CenterConfiguration<수산창고>
    {
        public override void Configure(EntityTypeBuilder<수산창고> builder)
        {
            base.Configure(builder);
        }
    }
    public class 수산품Configuration : CommodityConfiguration<수산품>
    {
        public override void Configure(EntityTypeBuilder<수산품> builder)
        {
            base.Configure(builder);
        }
    }
}
