using Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace KoreaCommon.Model.Repository
{
    public class 수산협동조합Repository : CenterRepository<수산협동조합>
    {
        public 수산협동조합Repository(수협DbContext context) : base(context)
        {
        }
        public async Task<수산협동조합?> GetByIdWith수산창고Async(string id)
        {
            return await _dbContext.Set<수산협동조합>().Where(e => e.Code != null && e.Code.Equals(id))
                .Include(수산협동조합 => 수산협동조합.창고들).FirstOrDefaultAsync();
        }
        public async Task<List<수산협동조합>> GetToListWith수산창고Async()
        {
            return await _dbContext.Set<수산협동조합>().Include(조합 => 조합.창고들).ToListAsync();
        }
    }
    
    public class 수산품별재고현황Repository : CommodityRepository<수산품별재고현황>
    {
        public 수산품별재고현황Repository(수협DbContext context) : base(context)
        {
        }
        public async Task<List<수산품별재고현황>> GetToListBy창고번호Async(string 창고id)
        {
            return await _dbContext.Set<수산품별재고현황>().Where(e => e.창고Id != null && 
                                                            e.창고Id.Equals(창고id)).ToListAsync();
        }
        public async Task<List<수산품별재고현황>> GetToListBy조합번호Async(string 조합id)
        {
            return await _dbContext.Set<수산품별재고현황>().Where(e => e.수협Id != null && e.수협Id.Equals(조합id)).ToListAsync();
        }
        public async Task<List<수산품별재고현황>> GetToListBy품목번호Async(string 수산품id)
        {
            return await _dbContext.Set<수산품별재고현황>().Where(e => e.수산품Id != null && e.수산품Id.Equals(수산품id)).ToListAsync();
        }
        public async Task<List<수산품별재고현황>> GetToListBy창고번호Async(string 창고id, int? quantityMin, int? quantityMax)
        {
            var query = _dbContext.Set<수산품별재고현황>().Where(e => e.창고Id != null && e.창고Id.Equals(창고id));

            if (quantityMin.HasValue)
                query = query.Where(e => int.Parse(e.Quantity) >= quantityMin.Value);

            if (quantityMax.HasValue)
                query = query.Where(e => int.Parse(e.Quantity) <= quantityMax.Value);

            return await query.ToListAsync();
        }

        public async Task<List<수산품별재고현황>> GetToListBy조합번호Async(string 조합id, int? quantityMin, int? quantityMax)
        {
            var query = _dbContext.Set<수산품별재고현황>().Where(e => e.수협Id != null && e.수협Id.Equals(조합id));

            if (quantityMin.HasValue)
                query = query.Where(e => int.Parse(e.Quantity) >= quantityMin.Value);

            if (quantityMax.HasValue)
                query = query.Where(e => int.Parse(e.Quantity) <= quantityMax.Value);

            return await query.ToListAsync();
        }

        public async Task<List<수산품별재고현황>> GetToListBy품목번호Async(string 수산품id, int? quantityMin, int? quantityMax)
        {
            var query = _dbContext.Set<수산품별재고현황>().Where(e => e.수산품Id != null && e.수산품Id.Equals(수산품id));

            if (quantityMin.HasValue)
                query = query.Where(e => int.Parse(e.Quantity) >= quantityMin.Value);

            if (quantityMax.HasValue)
                query = query.Where(e => int.Parse(e.Quantity) <= quantityMax.Value);

            return await query.ToListAsync();
        }
    }
    public class 수산창고Repository : CenterRepository<수산창고>
    {
        public 수산창고Repository(수협DbContext context) : base(context)
        {
        }
        public async Task<List<수산창고>?> GetToList수산창고With수산품목종류Async()
        {
            return await _dbContext.Set<수산창고>().Include(e => e.수산품들).ToListAsync();
        }
        public async Task<수산창고?> GetByIdWith수산품별재고현황Async(string 창고Id)
        {
            return await _dbContext.Set<수산창고>()
            .Where(수산창고 => 수산창고.Code == 창고Id)
            .Include(수산창고 => 수산창고.수산품별재고현황들)
            .FirstOrDefaultAsync();
        }
        public async Task<List<수산창고>> GetToListBy조합IdAsync(string 조합id)
        {
            return await _dbContext.Set<수산창고>().Where(e => e.수협Id != null && e.수협Id.Equals(조합id)).ToListAsync();
        }
    }
    public class 수산품Repository : EntityRepository<수산품>
    {
        public 수산품Repository(수협DbContext context) : base(context)
        {
        }
        public async Task<List<수산품>> GetToList수산품By수산창고IdAsync(string 수산창고Id)
        {
            return await _dbContext.Set<수산품>().Where(수산품 => 수산품.창고Id == 수산창고Id).ToListAsync();
        }
        public async Task<List<수산품>> GetToList수산품By조합IdAsync(string 조합Id)
        {
            return await _dbContext.Set<수산품>().Where(수산품 => 수산품.수협Id == 조합Id).ToListAsync();
        }
    }
}
