using Common.Model;
using Microsoft.Extensions.Caching.Memory;

namespace Common.Cache
{
    public interface IStorableInCenterMemory
    {
        string? GetCenterId();
    }
    public class CenterMemoryModule : CenterMemoryModuleBase
    {
        public CenterMemoryModule(IMemoryCache memoryCache) : base(memoryCache)
        {
        }

        public void SetCenter(Center center)
        {
            _memoryCache.Set(center.GetCenterId(), center);
        }

        public Center? GetCenter(string centerId)
        {
            return _memoryCache.Get<Center>(centerId);
        }

        public void RemoveCenter(string centerId)
        {
            _memoryCache.Remove(centerId);
        }

        public void SetCommodity(string centerId, Commodity commodity)
        {
            Center center = GetCenter(centerId);

            if (center != null)
            {
                Commodity existingCommodity = center.Commodities.Find(c => c.Id == commodity.Id);
                if (existingCommodity != null)
                {
                    // 이미 존재하는 Commodity를 대체
                    int index = center.Commodities.IndexOf(existingCommodity);
                    center.Commodities[index] = commodity;
                }
                else
                {
                    // 새로운 Commodity를 추가
                    center.Commodities.Add(commodity);
                }

                SetCenter(center);
            }
        }

        public Commodity? GetCommodity(string centerId, string commodityId)
        {
            Center center = GetCenter(centerId);

            if (center != null)
            {
                return center.Commodities.Find(c => c.Id == commodityId);
            }

            return null;
        }

        public void RemoveCommodity(string centerId, string commodityId)
        {
            Center center = GetCenter(centerId);

            if (center != null)
            {
                Commodity existingCommodity = center.Commodities.Find(c => c.Id == commodityId);
                if (existingCommodity != null)
                {
                    center.Commodities.Remove(existingCommodity);
                    SetCenter(center);
                }
            }
        }

        public void SetStatus(string centerId, Status status)
        {
            Center center = GetCenter(centerId);

            if (center != null)
            {
                Status existingStatus = center.Statuses.Find(s => s.Id == status.Id);
                if (existingStatus != null)
                {
                    // 이미 존재하는 Status를 대체
                    int index = center.Statuses.IndexOf(existingStatus);
                    center.Statuses[index] = status;
                }
                else
                {
                    // 새로운 Status를 추가
                    center.Statuses.Add(status);
                }

                SetCenter(center);
            }
        }

        public Status? GetStatus(string centerId, string statusId)
        {
            Center center = GetCenter(centerId);

            if (center != null)
            {
                return center.Statuses.Find(s => s.Id == statusId);
            }

            return null;
        }

        public void RemoveStatus(string centerId, string statusId)
        {
            Center center = GetCenter(centerId);

            if (center != null)
            {
                Status existingStatus = center.Statuses.Find(s => s.Id == statusId);
                if (existingStatus != null)
                {
                    center.Statuses.Remove(existingStatus);
                    SetCenter(center);
                }
            }
        }
    }

    public abstract class CenterMemoryModuleBase
    {
        protected readonly IMemoryCache _memoryCache;

        public CenterMemoryModuleBase(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
    }
}
