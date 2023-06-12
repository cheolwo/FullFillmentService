using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public class 판매자상품판매정보요약Repository : EntityRepository<판매자상품판매정보요약>
    {
        public 판매자상품판매정보요약Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<판매자상품판매정보요약?> GetByIdWith판매자And주문자구매요약(string id)
        {
            return await _dbContext.Set<판매자상품판매정보요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자)
                .Include(e => e.주문자구매요약)
                .FirstOrDefaultAsync();
        }

        public async Task<List<판매자상품판매정보요약>> GetToListBy판매자Id(string 판매자Id)
        {
            return await _dbContext.Set<판매자상품판매정보요약>()
                .Where(e => e.판매자Id == 판매자Id)
                .ToListAsync();
        }
        public async Task<판매자상품판매정보요약?> GetByIdWith판매자상품(string id)
        {
            return await _dbContext.Set<판매자상품판매정보요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자)
                .Include(e => e.주문자구매요약)
                .FirstOrDefaultAsync();
        }

        public async Task<판매자상품판매정보요약?> GetByIdWith판매자상품And주문자구매요약(string id)
        {
            return await _dbContext.Set<판매자상품판매정보요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자)
                .Include(e => e.주문자구매요약)
                .FirstOrDefaultAsync();
        }

        public async Task<List<판매자상품판매정보요약>> GetToListBy판매자상품Id(string 판매자상품Id)
        {
            return await _dbContext.Set<판매자상품판매정보요약>()
                .Where(e => e.판매자상품Id == 판매자상품Id)
                .Include(e => e.주문자구매요약)
                .ToListAsync();
        }
    }
}
