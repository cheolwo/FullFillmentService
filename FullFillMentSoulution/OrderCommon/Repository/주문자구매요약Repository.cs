using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public interface I주문자구매요약QueryRepository : IEntityQueryRepository<주문자구매요약>
    {
        Task<주문자구매요약?> GetByIdWith판매자상품판매정보요약(string id);
        Task<주문자구매요약?> GetByIdWith판매자(string id);
        Task<주문자구매요약?> GetByIdWith판매자상품(string id);
        Task<주문자구매요약?> GetByIdWith주문자(string id);
        Task<주문자구매요약?> GetByIdWithRelatedData(string id);
        Task<List<주문자구매요약>> GetToListBy판매자Id(string 판매자Id);
        Task<List<주문자구매요약>> GetToListBy구매일시(DateTime 구매일시);
    }

    public class 주문자구매요약Repository : EntityRepository<주문자구매요약>, I주문자구매요약QueryRepository
    {
        public 주문자구매요약Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<주문자구매요약?> GetByIdWith판매자상품판매정보요약(string id)
        {
            return await _dbContext.Set<주문자구매요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품판매정보요약)
                .FirstOrDefaultAsync();
        }

        public async Task<주문자구매요약?> GetByIdWith판매자(string id)
        {
            return await _dbContext.Set<주문자구매요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자)
                .FirstOrDefaultAsync();
        }

        public async Task<주문자구매요약?> GetByIdWith판매자상품(string id)
        {
            return await _dbContext.Set<주문자구매요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품)
                .FirstOrDefaultAsync();
        }

        public async Task<주문자구매요약?> GetByIdWith주문자(string id)
        {
            return await _dbContext.Set<주문자구매요약>()
                .Where(e => e.Id == id)
                .Include(e => e.주문자)
                .FirstOrDefaultAsync();
        }

        public async Task<주문자구매요약?> GetByIdWithRelatedData(string id)
        {
            return await _dbContext.Set<주문자구매요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품판매정보요약)
                .Include(e => e.판매자)
                .Include(e => e.판매자상품)
                .Include(e => e.주문자)
                .FirstOrDefaultAsync();
        }

        public async Task<List<주문자구매요약>> GetToListBy판매자Id(string 판매자Id)
        {
            return await _dbContext.Set<주문자구매요약>()
                .Where(e => e.판매자Id == 판매자Id)
                .ToListAsync();
        }

        public async Task<List<주문자구매요약>> GetToListBy구매일시(DateTime 구매일시)
        {
            return await _dbContext.Set<주문자구매요약>()
                .Where(e => e.구매일시 == 구매일시)
                .ToListAsync();
        }
    }
}
