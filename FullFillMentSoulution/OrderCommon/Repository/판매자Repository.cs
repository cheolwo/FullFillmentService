using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public class 판매자Repository : CenterRepository<판매자>
    {
        public 판매자Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<판매자?> GetByIdWith판매자상품(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품들)
                .FirstOrDefaultAsync();
        }

        public async Task<판매자?> GetByIdWith주문(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.주문들)
                .FirstOrDefaultAsync();
        }

        public async Task<판매자?> GetByIdWithRelatedData(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품들)
                .Include(e => e.주문들)
                .Include(e => e.상품문의들)
                .Include(e => e.댓글들)
                .Include(e => e.할일목록들)
                .Include(e => e.주문자구매요약들)
                .Include(e => e.판매자상품판매정보요약들)
                .Include(e => e.판매자판매정보요약)
                .FirstOrDefaultAsync();
        }
        public async Task<List<판매자>> GetAllWith판매자상품()
        {
            return await _dbContext.Set<판매자>()
                .Include(e => e.판매자상품들)
                .ToListAsync();
        }

        public async Task<List<판매자>> GetAllWith주문()
        {
            return await _dbContext.Set<판매자>()
                .Include(e => e.주문들)
                .ToListAsync();
        }
        public async Task<판매자?> GetByIdWith상품문의(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.상품문의들)
                .FirstOrDefaultAsync();
        }

        public async Task<판매자?> GetByIdWith댓글(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.댓글들)
                .FirstOrDefaultAsync();
        }

        public async Task<판매자?> GetByIdWith할일목록(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.할일목록들)
                .FirstOrDefaultAsync();
        }

        public async Task<판매자?> GetByIdWith주문자구매요약(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.주문자구매요약들)
                .FirstOrDefaultAsync();
        }

        public async Task<판매자?> GetByIdWith판매자상품판매정보요약(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품판매정보요약들)
                .FirstOrDefaultAsync();
        }

        public async Task<판매자?> GetByIdWith판매자판매정보요약(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자판매정보요약)
                .FirstOrDefaultAsync();
        }
    }
}
