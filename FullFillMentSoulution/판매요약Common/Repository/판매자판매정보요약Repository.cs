using Common.Model.Repository;
using Microsoft.EntityFrameworkCore;
using 판매요약Common.Model;

namespace 판매요약Common.Repository
{
    public interface I판매자판매정보요약QueryRepository : IEntityQueryRepository<판매자판매정보요약>
    {
        Task<판매자판매정보요약?> GetByIdWith판매자(string id);
        Task<List<판매자판매정보요약>> GetToListBy판매자Id(string 판매자Id);
    }
    public class 판매자판매정보요약Repository : EntityRepository<판매자판매정보요약>,
        I판매자판매정보요약QueryRepository
    {
        public 판매자판매정보요약Repository(판매요약DbContext context) : base(context)
        {
        }
        public async Task<판매자판매정보요약?> GetByIdWith판매자(string id)
        {
            return await _dbContext.Set<판매자판매정보요약>()
                .Where(e => e.Id == id)
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
