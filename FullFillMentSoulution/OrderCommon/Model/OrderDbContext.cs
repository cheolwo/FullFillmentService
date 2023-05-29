using Microsoft.EntityFrameworkCore;

namespace OrderCommon.Model
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {

        }
        public DbSet<Orderer> Orderers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerCommodity> SellerCommodites { get; set; }
    }
}

