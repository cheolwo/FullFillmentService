using Common.Model.Repository;
using Microsoft.EntityFrameworkCore;

namespace 창고Common.Repository
{
    public class 창고Repository : CenterRepository<창고>
    {
        public 창고Repository(창고DbContext context) : base(context)
        {
        }
        public async Task<창고?> GetByIdWith창고상품(string id)
        {
            return await _dbContext.Set<창고>().Where(x => x.Id == id).Include(e => e.창고상품들).FirstOrDefaultAsync();
        }
        public async Task<창고?> GetByIdWith입고상품(string id)
        {
            return await _dbContext.Set<창고>().Where(x => x.Id == id).Include(e => e.입고상품들).FirstOrDefaultAsync();
        }
        public async Task<창고?> GetByIdWith적재상품(string id)
        {
            return await _dbContext.Set<창고>().Where(x => x.Id == id).Include(e => e.적재상품들).FirstOrDefaultAsync();
        }
        public async Task<창고?> GetByIdWith출고상품(string id)
        {
            return await _dbContext.Set<창고>().Where(x => x.Id == id).Include(e => e.출고상품들).FirstOrDefaultAsync();
        }
    }
    public class 창고상품Repository : EntityRepository<창고상품>
    {
        public 창고상품Repository(창고DbContext context) : base(context)
        {
        }
        public async Task<창고상품?> GetByIdWith입고상품(string id)
        {
            return await _dbContext.Set<창고상품>().Where(x => x.Id == id).Include(e => e.입고상품들).FirstOrDefaultAsync();
        }
        public async Task<창고상품?> GetByIdWith적재상품(string id)
        {
            return await _dbContext.Set<창고상품>().Where(x => x.Id == id).Include(e => e.적재상품들).FirstOrDefaultAsync();
        }
        public async Task<창고상품?> GetByIdWith출고상품(string id)
        {
            return await _dbContext.Set<창고상품>().Where(x => x.Id == id).Include(e => e.출고상품들).FirstOrDefaultAsync();
        }
        public async Task<List<창고상품>> GetToListBy창고Id(string 창고Id)
        {
            return await _dbContext.Set<창고상품>().Where(e => e.창고Id == 창고Id).ToListAsync();
        }
    }
    public class 입고상품Repository : StatusRepository<입고상품>
    {
        public 입고상품Repository(창고DbContext context) : base(context)
        {
        }
        public async Task<입고상품?> GetByIdWith적재상품(string id)
        {
            return await _dbContext.Set<입고상품>().Where(x => x.Id == id).Include(e => e.적재상품들).FirstOrDefaultAsync();
        }
        public async Task<입고상품?> GetByIdWith출고상품(string id)
        {
            return await _dbContext.Set<입고상품>().Where(x => x.Id == id).Include(e => e.출고상품들).FirstOrDefaultAsync();
        }
        public async Task<List<입고상품>> GetToListBy창고Id(string 창고Id)
        {
            return await _dbContext.Set<입고상품>().Where(e => e.창고Id == 창고Id).ToListAsync();
        }
        public async Task<List<입고상품>> GetToListBy창고상품Id(string 창고상품Id)
        {
            return await _dbContext.Set<입고상품>().Where(e => e.창고상품Id == 창고상품Id).ToListAsync();
        }
    }
    public class 적재상품Repository : StatusRepository<적재상품>
    {
        public 적재상품Repository(창고DbContext context) : base(context)
        {
        }
        public async Task<적재상품?> GetByIdWith출고상품(string id)
        {
            return await _dbContext.Set<적재상품>().Where(x => x.Id == id).Include(e => e.출고상품들).FirstOrDefaultAsync();
        }
        public async Task<List<적재상품>> GetToListBy창고Id(string 창고Id)
        {
            return await _dbContext.Set<적재상품>().Where(e => e.창고Id == 창고Id).ToListAsync();
        }
        public async Task<List<적재상품>> GetToListBy창고상품Id(string 창고상품Id)
        {
            return await _dbContext.Set<적재상품>().Where(e => e.창고상품Id == 창고상품Id).ToListAsync();
        }
        public async Task<List<적재상품>> GetToListBy입고상품Id(string 입고상품Id)
        {
            return await _dbContext.Set<적재상품>().Where(e => e.입고상품Id == 입고상품Id).ToListAsync();
        }
    }
    public class 출고상품Repository : StatusRepository<출고상품>
    {
        public 출고상품Repository(창고DbContext context) : base(context)
        {
        }
        public async Task<List<출고상품>> GetToListBy창고Id(string 창고Id)
        {
            return await _dbContext.Set<출고상품>().Where(e => e.창고Id == 창고Id).ToListAsync();
        }
        public async Task<List<출고상품>> GetToListBy창고상품Id(string 창고상품Id)
        {
            return await _dbContext.Set<출고상품>().Where(e => e.창고상품Id == 창고상품Id).ToListAsync();
        }
        public async Task<List<출고상품>> GetToListBy입고상품Id(string 입고상품Id)
        {
            return await _dbContext.Set<출고상품>().Where(e => e.입고상품Id == 입고상품Id).ToListAsync();
        }
        public async Task<List<출고상품>> GetToListBy적재상품Id(string 적재상품Id)
        {
            return await _dbContext.Set<출고상품>().Where(e => e.적재상품Id == 적재상품Id).ToListAsync();
        }
    }
}
