using Common.Model;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Common.Cache
{
    public interface IStorableInCenterMemory
    {
        string? GetCenterId();
    }
    public class CenterMemoryModule : EntityMemoryModuleBase
    {
        public CenterMemoryModule(IMemoryCache memoryCache) : base(memoryCache)
        {
        }
        public void SetCenter<T>(string centerId, string userId, T center) where T : Center
        {
            if (center == null)
            {
                throw new ArgumentNullException(nameof(center));
            }
            string cacheKey = $"{userId}_{typeof(T).Name}_{centerId}";
            _memoryCache.Set(cacheKey, center);
        }
        public void SetCenter<T>(string cacheKey, T center) where T : Center
        {
            _memoryCache.Set(cacheKey, center);
        }

        public TCenter? GetCenter<TCenter>(string cacheKey) where TCenter : Center
        {
            return _memoryCache.Get<TCenter>(cacheKey);
        }

        public void RemoveCenter(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }

        public void SetCommodity<TCommodity, TCenter>(string cacheKey, TCommodity commodity)
            where TCommodity : Commodity
            where TCenter : Center
        {
            TCenter? center = GetCenter<TCenter>(cacheKey);

            if (center != null)
            {
                if (center.Commodities == null)
                {
                    center.Commodities = new Dictionary<string, string>();
                }

                string json = JsonConvert.SerializeObject(commodity);
                if (center.Commodities.ContainsKey(commodity.Id))
                {
                    // 이미 존재하는 Commodity를 대체
                    center.Commodities[commodity.Id] = json;
                }
                else
                {
                    // 새로운 Commodity를 추가
                    center.Commodities.Add(commodity.Id, json);
                }

                SetCenter(cacheKey, center);
            }
        }
        public void SetCommodities<TCommodity, TCenter>(string cacheKey, List<TCommodity> commodities)
            where TCommodity : Commodity
            where TCenter : Center
        {
            TCenter? center = GetCenter<TCenter>(cacheKey);

            if (center != null)
            {
                if (center.Commodities == null)
                {
                    center.Commodities = new Dictionary<string, string>();
                }

                foreach (var commodity in commodities)
                {
                    string json = JsonConvert.SerializeObject(commodity);
                    if (center.Commodities.ContainsKey(commodity.Id))
                    {
                        // 이미 존재하는 Commodity를 대체
                        center.Commodities[commodity.Id] = json;
                    }
                    else
                    {
                        // 새로운 Commodity를 추가
                        center.Commodities.Add(commodity.Id, json);
                    }
                }

                SetCenter(cacheKey, center);
            }
        }

        public TCommodity? GetCommodity<TCommodity, TCenter>(string cacheKey, string commodityId)
                                                            where TCommodity : Commodity
                                                            where TCenter : Center
        {
            TCenter center = GetCenter<TCenter>(cacheKey);

            if (center != null && center.Commodities != null && center.Commodities.ContainsKey(commodityId))
            {
                string json = center.Commodities[commodityId];
                return JsonConvert.DeserializeObject<TCommodity>(json);
            }

            return null;
        }

        public void RemoveCommodity<TCenter>(string cacheKey, string commodityId)
            where TCenter : Center
        {
            TCenter center = GetCenter<TCenter>(cacheKey);

            if (center != null && center.Commodities != null && center.Commodities.ContainsKey(commodityId))
            {
                center.Commodities.Remove(commodityId);
                SetCenter(cacheKey, center);
            }
        }

        public void SetStatus<TStatus, TCenter>(string cacheKey, TStatus status)
                                                    where TStatus : Status
                                                    where TCenter : Center
        {
            TCenter center = GetCenter<TCenter>(cacheKey);

            if (center != null)
            {
                if (center.Statuses == null)
                {
                    center.Statuses = new Dictionary<string, string>();
                }

                string key = status.Id + status.State;
                string json = JsonConvert.SerializeObject(status);
                if (center.Statuses.ContainsKey(key))
                {
                    // 이미 존재하는 Status를 대체
                    center.Statuses[key] = json;
                }
                else
                {
                    // 새로운 Status를 추가
                    center.Statuses.Add(key, json);
                }

                SetCenter(cacheKey, center);
            }
        }

        public void SetStatuses<TStatus, TCenter>(string cacheKey, List<TStatus> statuses)
            where TStatus : Status
            where TCenter : Center
        {
            TCenter center = GetCenter<TCenter>(cacheKey);

            if (center != null)
            {
                if (center.Statuses == null)
                {
                    center.Statuses = new Dictionary<string, string>();
                }

                foreach (var status in statuses)
                {
                    string key = status.Id + status.State;
                    string json = JsonConvert.SerializeObject(status);
                    if (center.Statuses.ContainsKey(key))
                    {
                        // 이미 존재하는 Status를 대체
                        center.Statuses[key] = json;
                    }
                    else
                    {
                        // 새로운 Status를 추가
                        center.Statuses.Add(key, json);
                    }
                }

                SetCenter(cacheKey, center);
            }
        }

        public List<TStatus> GetStatuses<TStatus, TCenter>(string cacheKey)
            where TStatus : Status
            where TCenter : Center
        {
            TCenter center = GetCenter<TCenter>(cacheKey);

            if (center != null && center.Statuses != null)
            {
                List<TStatus> statuses = new List<TStatus>();

                foreach (var json in center.Statuses.Values)
                {
                    TStatus status = JsonConvert.DeserializeObject<TStatus>(json);
                    statuses.Add(status);
                }

                return statuses;
            }

            return new List<TStatus>();
        }
        public List<TCommodity> GetCommodities<TCommodity, TCenter>(string cacheKey)
                    where TCommodity : Commodity
                        where TCenter : Center
        {
            TCenter center = GetCenter<TCenter>(cacheKey);

            if (center != null && center.Commodities != null)
            {
                List<TCommodity> commodities = new List<TCommodity>();

                foreach (var json in center.Commodities.Values)
                {
                    TCommodity commodity = JsonConvert.DeserializeObject<TCommodity>(json);
                    if (commodity != null)
                    {
                        commodities.Add(commodity);
                    }
                }

                return commodities;
            }

            return new List<TCommodity>();
        }

        public List<TStatus> GetStatuses<TStatus, TCenter>(string cacheKey, string state)
            where TStatus : Status
            where TCenter : Center
        {
            TCenter center = GetCenter<TCenter>(cacheKey);

            if (center != null && center.Statuses != null)
            {
                List<TStatus> statuses = new List<TStatus>();

                foreach (var json in center.Statuses.Values)
                {
                    TStatus status = JsonConvert.DeserializeObject<TStatus>(json);
                    if (status != null && status.State == state)
                    {
                        statuses.Add(status);
                    }
                }

                return statuses;
            }

            return new List<TStatus>();
        }
    }

    public abstract class EntityMemoryModuleBase
    {
        protected readonly IMemoryCache _memoryCache;

        public EntityMemoryModuleBase(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
    }
}
