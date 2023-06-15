using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public interface I할일목록QueryRepository : IEntityQueryRepository<할일목록>
    {
        Task<List<할일목록>> GetToListBy판매자IdAnd주문Id(string 판매자Id, string 주문Id);
        Task<List<할일목록>> GetToListBy판매자IdWithPriorityDescending(string 판매자Id);
        Task<List<할일목록>> GetToListBy주문IdAndStatus(string 주문Id, string 상태);
        Task<List<할일목록>> GetToListBy판매자IdAndStatus(string 판매자Id, string 상태);
    }
    public class 할일목록Repository : EntityRepository<할일목록>, I할일목록QueryRepository
    {
        public 할일목록Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<List<할일목록>> GetToListBy판매자IdAnd주문Id(string 판매자Id, string 주문Id)
        {
            return await _dbContext.Set<할일목록>()
                .Where(e => e.판매자Id == 판매자Id && e.주문Id == 주문Id)
                .ToListAsync();
        }

        public async Task<List<할일목록>> GetToListBy판매자IdWithPriorityDescending(string 판매자Id)
        {
            return await _dbContext.Set<할일목록>()
                .Where(e => e.판매자Id == 판매자Id)
                .OrderByDescending(e => e.우선순위)
                .ToListAsync();
        }

        public async Task<List<할일목록>> GetToListBy주문IdAndStatus(string 주문Id, string 상태)
        {
            return await _dbContext.Set<할일목록>()
                .Where(e => e.주문Id == 주문Id && e.상태 == 상태)
                .ToListAsync();
        }

        public async Task<List<할일목록>> GetToListBy판매자IdAndStatus(string 판매자Id, string 상태)
        {
            return await _dbContext.Set<할일목록>()
                .Where(e => e.판매자Id == 판매자Id && (e.상태 == 상태))
                .ToListAsync();
        }
    }
}
