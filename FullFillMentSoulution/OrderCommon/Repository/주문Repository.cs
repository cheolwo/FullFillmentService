using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public class 주문Repository : CommodityRepository<주문>
    {
        public 주문Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<주문?> GetByIdWith판매자상품(string id)
        {
            return await _dbContext.Set<주문>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품)
                .FirstOrDefaultAsync();
        }

        public async Task<주문?> GetByIdWith주문자(string id)
        {
            return await _dbContext.Set<주문>()
                .Where(e => e.Id == id)
                .Include(e => e.주문자)
                .FirstOrDefaultAsync();
        }

        public async Task<주문?> GetByIdWith판매자(string id)
        {
            return await _dbContext.Set<주문>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자)
                .FirstOrDefaultAsync();
        }

        public async Task<주문?> GetByIdWith판매자And판매자상품(string id)
        {
            return await _dbContext.Set<주문>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자)
                .Include(e => e.판매자상품)
                .FirstOrDefaultAsync();
        }

        public async Task<주문?> GetByIdWith판매자And판매자상품And주문자(string id)
        {
            return await _dbContext.Set<주문>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자)
                .Include(e => e.판매자상품)
                .Include(e => e.주문자)
                .FirstOrDefaultAsync();
        }

        public async Task<List<주문>> GetByPriceAbove(double price)
        {
            return await _dbContext.Set<주문>()
                .Where(e => e.Price > price)
                .ToListAsync();
        }

        public async Task<List<주문>> GetByPriceBelow(double price)
        {
            return await _dbContext.Set<주문>()
                .Where(e => e.Price < price)
                .ToListAsync();
        }

        public async Task<List<주문>> GetByPriceInRange(double minPrice, double maxPrice)
        {
            return await _dbContext.Set<주문>()
                .Where(e => e.Price >= minPrice && e.Price <= maxPrice)
                .ToListAsync();
        }
    }
}
