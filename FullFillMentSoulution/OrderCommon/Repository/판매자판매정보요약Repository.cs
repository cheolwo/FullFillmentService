using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public class 판매자판매정보요약Repository : EntityRepository<판매자판매정보요약>
    {
        public 판매자판매정보요약Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<판매자판매정보요약?> GetByIdWith판매자(string id)
        {
            return await _dbContext.Set<판매자판매정보요약>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자)
                .FirstOrDefaultAsync();
        }

        public async Task<List<판매자판매정보요약>> GetToListBy판매자Id(string 판매자Id)
        {
            return await _dbContext.Set<판매자판매정보요약>()
                .Where(e => e.판매자Id == 판매자Id)
                .ToListAsync();
        }
    }
}
