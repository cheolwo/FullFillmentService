using AutoMapper;
using Common.Cache;
using Common.DTO;
using Common.Model;
using Common.Model.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace Common.Cache_Repository
{
    /// <summary>
    /// QueryServer에서 Redis, InMemory, DB 저장장치 Query를 담당할 모듈
    /// </summary>
    /// <typeparam name="TCenterDTO"></typeparam>
    /// <typeparam name="TCenter"></typeparam>
    public abstract class CenterQueryManager<TCenterDTO, TCenter> where TCenterDTO : ReadCenterDTO where TCenter : Center
    {
        protected readonly ICenterQueryRepository<TCenter> _centerQueryRepository;
        protected readonly IDistributedCache _distributedCache;
        protected readonly IMapper _mapper;
        protected readonly CenterMemoryModule _entityMemoryModule;
        public CenterQueryManager(ICenterQueryRepository<TCenter> entityQueryRepository, IDistributedCache distributedCache, IMapper mapper, 
            CenterMemoryModule centerMemoryModule)
        {
            _centerQueryRepository = entityQueryRepository;
            _entityMemoryModule = centerMemoryModule;
            _distributedCache = distributedCache;
            _mapper = mapper;
        }
        public abstract Task<TCenterDTO> GetCenterByUserIdWithRelatedData(string cacheKey);
        public abstract Task<TCenterDTO> GetCenterWithCommodity(string cacheKey);
        public abstract Task<TCenterDTO> GetCenterWithStatus(string cacheKey, string state);
    }
}
