using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public interface I주문자QueryRepository : ICenterQueryRepository<주문자>
    {
        Task<주문자?> GetByIdWith주문(string id);
        Task<주문자?> GetByIdWith댓글(string id);
        Task<주문자?> GetByIdWith상품문의(string id);
        Task<주문자?> GetByIdWithRelatedData(string id);
    }
    public class 주문자Repository : CenterRepository<주문자>, I주문자QueryRepository
    {
        public 주문자Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<주문자?> GetByIdWith주문(string id)
        {
            return await _dbContext.Set<주문자>()
                .Where(e => e.Id == id)
                .Include(e => e.주문들)
                .FirstOrDefaultAsync();
        }

        public async Task<주문자?> GetByIdWith댓글(string id)
        {
            return await _dbContext.Set<주문자>()
                .Where(e => e.Id == id)
                .Include(e => e.댓글들)
                .FirstOrDefaultAsync();
        }

        public async Task<주문자?> GetByIdWith상품문의(string id)
        {
            return await _dbContext.Set<주문자>()
                .Where(e => e.Id == id)
                .Include(e => e.상품문의들)
                .FirstOrDefaultAsync();
        }

        public async Task<주문자?> GetByIdWithRelatedData(string id)
        {
            return await _dbContext.Set<주문자>()
                .Where(e => e.Id == id)
                .Include(e => e.주문들)
                .Include(e => e.댓글들)
                .Include(e => e.상품문의들)
                .FirstOrDefaultAsync();
        }
    }
}
