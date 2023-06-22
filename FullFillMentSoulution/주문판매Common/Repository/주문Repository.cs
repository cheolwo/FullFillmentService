using Common.Model.Repository;
using Microsoft.EntityFrameworkCore;

namespace 주문판매Common.Repository
{
    public interface I주문QueryRepository : ICommodityQueryRepository<주문>
    {
        Task<List<주문>> GetToListBy판매자상품Id(string id);
        Task<List<주문>> GetToListBy주문자Id(string id);
        Task<List<주문>> GetToListBy판매자Id(string id);
        Task<List<주문>> GetByPriceAbove(double price);
        Task<List<주문>> GetByPriceBelow(double price);
        Task<List<주문>> GetByPriceInRange(double minPrice, double maxPrice);
    }
    public class 주문Repository : CommodityRepository<주문>, I주문QueryRepository
    {
        public 주문Repository(주문판매DbContext context) : base(context)
        {
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

        public async Task<List<주문>> GetToListBy판매자상품Id(string id)
        {
            return await _dbContext.Set<주문>()
                 .Where(e => e.판매자상품Id.Equals(id))
                 .ToListAsync();
        }

        public async Task<List<주문>> GetToListBy주문자Id(string id)
        {
            return await _dbContext.Set<주문>()
                 .Where(e => e.주문자Id.Equals(id))
                 .ToListAsync();
        }

        public async Task<List<주문>> GetToListBy판매자Id(string id)
        {
            return await _dbContext.Set<주문>().Where(e => e.판매자Id.Equals(id)).ToListAsync();
        }
    }
}
