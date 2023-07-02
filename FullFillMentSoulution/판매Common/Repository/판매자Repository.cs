using Common.Model.Repository;
using Microsoft.EntityFrameworkCore;
using 판매Common.Model;

namespace 판매Common.Repository
{
    public interface I판매자QueryRepository : ICenterQueryRepository<판매자>
    {
        Task<판매자?> GetByIdWith판매자상품(string id);
        Task<List<판매자>> GetAllWith판매자상품();
        Task<List<판매자>> GetToListWithRelatedData();
    }
    public interface I판매자상품QueryRepository : IEntityQueryRepository<판매자상품>
    {
    }
    public interface I판매대기QueryRepository : IStatusQueryRepository<판매대기>
    {

    }
    public interface I판매중QueryRepository : IStatusQueryRepository<판매중>
    {

    }
    public interface I판매완료QueryRepository : IStatusQueryRepository<판매완료>
    {

    }
    public class 판매자Repository : CenterRepository<판매자>, I판매자QueryRepository
    {
        public 판매자Repository(판매DbContext context) : base(context)
        {
        }
        public async Task<판매자?> GetByIdWith판매자상품(string id)
        {
            return await _dbContext.Set<판매자>()
                .Where(e => e.Id == id)
                .Include(e => e.판매자상품들)
                .FirstOrDefaultAsync();
        }
        public async Task<List<판매자>> GetAllWith판매자상품()
        {
            return await _dbContext.Set<판매자>()
                .Include(e => e.판매자상품들)
                .ToListAsync();
        }

        public async Task<List<판매자>> GetToListWithRelatedData()
        {
            return await _dbContext.Set<판매자>().
                 Include(e => e.판매자상품들)
                .Include(e => e.판매대기들)
                .Include(e => e.판매중들)
                .Include(e => e.판매완료들).ToListAsync();
        }
    }
    public class 판매자상품Repository : CommodityRepository<판매자상품>, I판매자상품QueryRepository
    {
        public 판매자상품Repository(판매DbContext context) : base(context)
        {
        }
    }
    public class 판매대기Repository : StatusRepository<판매대기>, I판매대기QueryRepository
    {
        public 판매대기Repository(판매DbContext context) : base(context)
        {
        }
    }
    public class 판매중Repository : StatusRepository<판매중>, I판매중QueryRepository
    {
        public 판매중Repository(판매DbContext context) : base(context)
        {
        }
    }
    public class 판매완료Repository : StatusRepository<판매완료>, I판매완료QueryRepository
    {
        public 판매완료Repository(판매DbContext context) : base(context)
        {
        }
    }
}
