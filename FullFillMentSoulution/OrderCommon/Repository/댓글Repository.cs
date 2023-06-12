using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using 주문Common.Model;

namespace OrderCommon.Repository
{
    public class 댓글Repository : EntityRepository<댓글>
    {
        public 댓글Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<List<댓글>> GetToListBy판매자상품Id(string 판매자상품Id)
        {
            return await _dbContext.Set<댓글>()
                .Where(e => e.판매자상품Id == 판매자상품Id)
                .ToListAsync();
        }

        public async Task<List<댓글>> GetToListBy주문자Id(string 주문자Id)
        {
            return await _dbContext.Set<댓글>()
                .Where(e => e.주문자Id == 주문자Id)
                .ToListAsync();
        }
        public async Task<List<댓글>> GetToListBy판매자상품IdWith주문자(string 판매자상품Id)
        {
            return await _dbContext.Set<댓글>()
                .Where(e => e.판매자상품Id == 판매자상품Id)
                .Include(e => e.주문자)
                .ToListAsync();
        }

        public async Task<List<댓글>> GetToListBy주문자IdWith판매자상품(string 주문자Id)
        {
            return await _dbContext.Set<댓글>()
                .Where(e => e.주문자Id == 주문자Id)
                .Include(e => e.판매자상품)
                .ToListAsync();
        }

        public async Task<List<댓글>> GetToListBy판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            return await _dbContext.Set<댓글>()
                .Where(e => e.판매자상품Id == 판매자상품Id)
                .Include(e => e.주문자)
                .Include(e => e.판매자상품)
                .ToListAsync();
        }

        public async Task<List<댓글>> GetToListBy주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            return await _dbContext.Set<댓글>()
                .Where(e => e.주문자Id == 주문자Id)
                .Include(e => e.판매자상품)
                .Include(e => e.주문자)
                .ToListAsync();
        }
    }
}
