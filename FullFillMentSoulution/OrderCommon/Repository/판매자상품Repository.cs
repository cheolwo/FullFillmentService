using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using System.Globalization;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public interface I판매자상품QueryRepository : ICommodityQueryRepository<판매자상품>
    {
        Task<판매자상품?> GetByIdWith상품문의(string id);
        Task<판매자상품?> GetByIdWith주문(string id);
        Task<판매자상품?> GetByIdWith판매자(string id);
        Task<판매자상품?> GetByIdWith판매자And주문(string id);
        Task<List<판매자상품>> GetByPriceAbove(double price);
        Task<List<판매자상품>> GetByPriceBelow(double price);
        Task<List<판매자상품>> GetByPriceInRange(double minPrice, double maxPrice);
        Task<List<판매자상품>> GetBySaleDateBefore(string date);
        Task<List<판매자상품>> GetBySaleDateAfter(string date);
        Task<List<판매자상품>> GetBySaleDate(string startDate, string endDate);
        Task<List<판매자상품>> GetBySaleDateBefore(DateTime saleDate);
        Task<List<판매자상품>> GetBySaleDateAfter(DateTime saleDate);
        Task<List<판매자상품>> GetBySaleDateRange(DateTime startDate, DateTime endDate);

    }
    public class 판매자상품Repository : CommodityRepository<판매자상품>, I판매자상품QueryRepository
    {
        public 판매자상품Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<판매자상품?> GetByIdWith상품문의(string id)
        {
            return await _dbContext.Set<판매자상품>()
                .Where(e => e.Id == id)
                .Include(e => e.상품문의들)
                .FirstOrDefaultAsync();
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
}
