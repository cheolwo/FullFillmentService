using AutoMapper;
using Common.Cache;
using Common.Cache_Repository;
using Common.Model.Repository;
using Microsoft.Extensions.Caching.Distributed;
using 판매Common.DTO;
using 판매Common.Model;

namespace 판매Common.Cache
{
    public class 판매자QueryManager : CenterQueryManager<Read판매자DTO, 판매자>
    {
        public 판매자QueryManager(
            ICenterQueryRepository<판매자> entityQueryRepository, 
            IDistributedCache distributedCache, IMapper mapper, 
            CenterMemoryModule centerMemoryModule) : 
            base(entityQueryRepository, distributedCache, mapper, centerMemoryModule)
        {
        }

        public override Task<Read판매자DTO> GetCenterByUserIdWithRelatedData(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public override Task<Read판매자DTO> GetCenterWithCommodity(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public override Task<Read판매자DTO> GetCenterWithStatus(string cacheKey, string state)
        {
            throw new NotImplementedException();
        }
    }
}