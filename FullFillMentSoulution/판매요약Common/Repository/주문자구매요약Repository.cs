using Common.Model.Repository;
using Microsoft.EntityFrameworkCore;
using 판매요약Common.Model;

namespace 판매요약Common.Repository
{
    public interface I주문자구매요약QueryRepository : IEntityQueryRepository<주문자구매요약>
    {
        Task<주문자구매요약?> GetByIdWith판매자상품판매정보요약(string id);
        Task<List<주문자구매요약>> GetToListBy판매자Id(string 판매자Id);
        Task<List<주문자구매요약>> GetToListBy구매일시(DateTime 구매일시);
    }

    public class 주문자구매요약Repository : EntityRepository<주문자구매요약>, I주문자구매요약QueryRepository
    {
        public 주문자구매요약Repository(판매요약DbContext context) : base(context)
        {
        }
        public async Task<주문자구매요약?> GetByIdWith판매자상품판매정보요약(string id)
        {
            return await _dbContext.Set<주문자구매요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품판매정보요약)
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
