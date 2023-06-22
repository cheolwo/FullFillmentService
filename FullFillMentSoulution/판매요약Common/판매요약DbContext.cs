using Microsoft.EntityFrameworkCore;
using 판매요약Common.Model;

namespace 판매요약Common
{
    public class 판매요약DbContext : DbContext
    {
        public 판매요약DbContext(DbContextOptions<판매요약DbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 판매자판매정보요약Configuration());
            modelBuilder.ApplyConfiguration(new 판매자상품판매정보요약Configuration());
            modelBuilder.ApplyConfiguration(new 주문자구매요약Configuration());
        }
    }
}