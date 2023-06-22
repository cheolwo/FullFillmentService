using Common.Model.Repository;
using Microsoft.EntityFrameworkCore;

namespace 주문판매Common.Repository
{
    public interface I댓글QueryRepository : IEntityQueryRepository<댓글>
    {
        Task<List<댓글>> GetToListBy판매자상품Id(string 판매자상품Id);
        Task<List<댓글>> GetToListBy주문자Id(string 주문자Id);
    }
    public interface I댓글CommandRespoitory : IEntityCommandRepository<댓글>
    {

    }
    public class 댓글Repository : EntityRepository<댓글>, 
        I댓글CommandRespoitory,
        I댓글QueryRepository
    {
        public 댓글Repository(주문판매DbContext context) : base(context)
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
    }
}
