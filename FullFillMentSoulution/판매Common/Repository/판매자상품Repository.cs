using Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace 판매Common.Repository
{
        //public async Task<List<판매자상품>> GetByPriceAbove(double price)
        //{
        //    return await _dbContext.Set<판매자상품>()
        //        .Where(e => e.Price > price)
        //        .ToListAsync();
        //}

        //public async Task<List<판매자상품>> GetByPriceBelow(double price)
        //{
        //    return await _dbContext.Set<판매자상품>()
        //        .Where(e => e.Price < price)
        //        .ToListAsync();
        //}

        //public async Task<List<판매자상품>> GetByPriceInRange(double minPrice, double maxPrice)
        //{
        //    return await _dbContext.Set<판매자상품>()
        //        .Where(e => e.Price >= minPrice && e.Price <= maxPrice)
        //        .ToListAsync();
        //}
        //public async Task<List<판매자상품>> GetBySaleDateBefore(string date)
        //{
        //    DateTime targetDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);

        //    return await _dbContext.Set<판매자상품>()
        //        .Where(e => e.판매개시일자 < targetDate)
        //        .ToListAsync();
        //}

        //public async Task<List<판매자상품>> GetBySaleDateAfter(string date)
        //{
        //    DateTime targetDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);

        //    return await _dbContext.Set<판매자상품>()
        //        .Where(e => e.판매개시일자 > targetDate)
        //        .ToListAsync();
        //}
        //public async Task<List<판매자상품>> GetBySaleDate(string startDate, string endDate)
        //{
        //    DateTime startDateTime = DateTime.ParseExact(startDate, "yyyyMMdd", CultureInfo.InvariantCulture);
        //    DateTime endDateTime = DateTime.ParseExact(endDate, "yyyyMMdd", CultureInfo.InvariantCulture);

        //    return await _dbContext.Set<판매자상품>()
        //        .Where(e => e.판매개시일자 >= startDateTime && e.판매개시일자 <= endDateTime)
        //        .ToListAsync();
        //}
        //public async Task<List<판매자상품>> GetBySaleDateBefore(DateTime saleDate)
        //{
        //    return await _dbContext.Set<판매자상품>().Where(e => e.판매개시일자 < saleDate).ToListAsync();
        //}

        //public async Task<List<판매자상품>> GetBySaleDateAfter(DateTime saleDate)
        //{
        //    return await _dbContext.Set<판매자상품>().Where(e => e.판매개시일자 > saleDate).ToListAsync();
        //}

        //public async Task<List<판매자상품>> GetBySaleDateRange(DateTime startDate, DateTime endDate)
        //{
        //    return await _dbContext.Set<판매자상품>().Where(e => e.판매개시일자 >= startDate && e.판매개시일자 <= endDate).ToListAsync();
        //}
}
