using Common.Model.Repository;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;

namespace 주문판매Common.Repository
{
    public interface I상품문의QueryRepository : IEntityQueryRepository<상품문의>
    {
        Task<List<상품문의>> GetToListBy판매자상품Id(string 판매자상품Id);
        Task<List<상품문의>> GetToListBy주문자Id(string 주문자Id);
    }
    public interface I상품문의CommandRepository : IEntityCommandRepository<상품문의>
    {

    }
    public class 상품문의Repository : EntityRepository<상품문의>, 
        I상품문의QueryRepository,
        I상품문의CommandRepository
    {
        public 상품문의Repository(주문DbContext context) : base(context)
        {
        }
        public async Task<List<상품문의>> GetToListBy판매자상품Id(string 판매자상품Id)
        {
            return await _dbContext.Set<상품문의>()
                .Where(e => e.판매자상품Id == 판매자상품Id)
                .ToListAsync();
        }

        public async Task<List<상품문의>> GetToListBy주문자Id(string 주문자Id)
        {
            return await _dbContext.Set<상품문의>()
                .Where(e => e.주문자Id == 주문자Id)
                .ToListAsync();
        }
    }
}
