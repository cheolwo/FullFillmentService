using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using System.Globalization;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public class 주문자Repository : CenterRepository<주문자>
    {
        public 주문자Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<주문자?> GetByIdWith주문(string id)
        {
            return await _dbContext.Set<주문자>().Where(e => e.Id == id).Include(e => e.주문들).FirstOrDefaultAsync();
        }
    }
    public class 판매자Repository : CenterRepository<판매자>
    {
        public 판매자Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<판매자?> GetByIdWith판매자상품(string id)
        {
            return await _dbContext.Set<판매자>().Where(e => e.Id == id).Include(e => e.판매자상품들).FirstOrDefaultAsync();
        }
        public async Task<판매자?> GetByIdWith주문(string id)
        {
            return await _dbContext.Set<판매자>().Where(e => e.Id == id).Include(e => e.주문된것들).FirstOrDefaultAsync();
        }
    }
    public class 판매자상품Repository : CommodityRepository<판매자상품>
    {
        public 판매자상품Repository(주문DbContext context) : base(context)
        {
        }

        public async Task<판매자상품?> GetByIdWith주문(string id)
        {
            return await _dbContext.Set<판매자상품>().Where(e => e.Id == id).Include(e => e.주문들).FirstOrDefaultAsync();
        }

        public async Task<판매자상품?> GetByIdWith판매자(string id)
        {
            return await _dbContext.Set<판매자상품>().Where(e => e.Id == id).Include(e => e.판매자).FirstOrDefaultAsync();
        }

        public async Task<판매자상품?> GetByIdWith판매자And주문(string id)
        {
            return await _dbContext.Set<판매자상품>().Where(e => e.Id == id).Include(e => e.판매자).Include(e => e.주문들).FirstOrDefaultAsync();
        }
        public async Task<List<판매자상품>> GetByPriceAbove(double price)
        {
            return await _dbContext.Set<판매자상품>()
                .Where(e => e.Price > price)
                .ToListAsync();
        }

        public async Task<List<판매자상품>> GetByPriceBelow(double price)
        {
            return await _dbContext.Set<판매자상품>()
                .Where(e => e.Price < price)
                .ToListAsync();
        }

        public async Task<List<판매자상품>> GetByPriceInRange(double minPrice, double maxPrice)
        {
            return await _dbContext.Set<판매자상품>()
                .Where(e => e.Price >= minPrice && e.Price <= maxPrice)
                .ToListAsync();
        }
        public async Task<List<판매자상품>> GetBySaleDateBefore(string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);

            return await _dbContext.Set<판매자상품>()
                .Where(e => e.판매개시일자 < targetDate)
                .ToListAsync();
        }

        public async Task<List<판매자상품>> GetBySaleDateAfter(string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);

            return await _dbContext.Set<판매자상품>()
                .Where(e => e.판매개시일자 > targetDate)
                .ToListAsync();
        }
        public async Task<List<판매자상품>> GetBySaleDate(string startDate, string endDate)
        {
            DateTime startDateTime = DateTime.ParseExact(startDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime endDateTime = DateTime.ParseExact(endDate, "yyyyMMdd", CultureInfo.InvariantCulture);

            return await _dbContext.Set<판매자상품>()
                .Where(e => e.판매개시일자 >= startDateTime && e.판매개시일자 <= endDateTime)
                .ToListAsync();
        }
        public async Task<List<판매자상품>> GetBySaleDateBefore(DateTime saleDate)
        {
            return await _dbContext.Set<판매자상품>().Where(e => e.판매개시일자 < saleDate).ToListAsync();
        }

        public async Task<List<판매자상품>> GetBySaleDateAfter(DateTime saleDate)
        {
            return await _dbContext.Set<판매자상품>().Where(e => e.판매개시일자 > saleDate).ToListAsync();
        }

        public async Task<List<판매자상품>> GetBySaleDateRange(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Set<판매자상품>().Where(e => e.판매개시일자 >= startDate && e.판매개시일자 <= endDate).ToListAsync();
        }
    }
    public class 주문Repository : CommodityRepository<주문>
    {
        public 주문Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<주문?> GetByIdWith판매자상품(string id)
        {
            return await _dbContext.Set<주문>().Where(e => e.Id == id).Include(e => e.판매자상품).FirstOrDefaultAsync();
        }
        public async Task<주문?> GetByIdWith주문자(string id)
        {
            return await _dbContext.Set<주문>().Where(e => e.Id == id).Include(e => e.주문자).FirstOrDefaultAsync();
        }
        public async Task<주문?> GetByIdWith판매자(string id)
        {
            return await _dbContext.Set<주문>().Where(e => e.Id == id).Include(e => e.판매자).FirstOrDefaultAsync();
        }
        public async Task<주문?> GetByIdWith판매자And판매자상품(string id)
        {
            return await _dbContext.Set<주문>().Where(e => e.Id == id).Include(e => e.판매자).Include(e => e.판매자상품).FirstOrDefaultAsync();
        }
        public async Task<주문?> GetByIdWith판매자And판매자상품And주문자(string id)
        {
            return await _dbContext.Set<주문>().Where(e => e.Id == id).Include(e => e.판매자).
                                                                            Include(e => e.판매자상품).
                                                                               Include(e => e.주문자).
                                                                                 FirstOrDefaultAsync();
        }
        public async Task<List<주문>> GetByPriceAbove(double price)
        {
            return await _dbContext.Set<주문>().Where(e => e.Price > price).ToListAsync();
        }

        public async Task<List<주문>> GetByPriceBelow(double price)
        {
            return await _dbContext.Set<주문>().Where(e => e.Price < price).ToListAsync();
        }

        public async Task<List<주문>> GetByPriceInRange(double minPrice, double maxPrice)
        {
            return await _dbContext.Set<주문>().Where(e => e.Price >= minPrice && e.Price <= maxPrice).ToListAsync();
        }
    }
}
