using Common.DTO;
using Microsoft.Extensions.Caching.Memory;
using 계정Common.Extensions;

namespace Common.Cache
{
    public class ActorMemoryModule
    {
        private readonly IMemoryCache _memoryCache;

        public ActorMemoryModule(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SetEntities<T>(List<T> entities, string token) where T : IStoreableInMemory
        {
            var id = token.GetUserIdFromToken();

            foreach (var dto in entities)
            {
                string cacheKey = $"{id}_{typeof(T).Name}_{dto.GetId()}";
                _memoryCache.Set(cacheKey, dto);
            }
        }

        public T? GetDto<T>(string DtoId, string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            string cacheKey = $"{id}_{typeof(T).Name}_{DtoId}";
            return _memoryCache.Get<T>(cacheKey);
        }

        public void SetDto<T>(string DtoId, T Dto, string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            string cacheKey = $"{id}_{typeof(T).Name}_{DtoId}";
            _memoryCache.Set(cacheKey, Dto);
        }

        public void RemoveDto<T>(string DtoId, string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            string cacheKey = $"{id}_{typeof(T).Name}_{DtoId}";
            _memoryCache.Remove(cacheKey);
        }

        public List<T> LoadEntities<T>(string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            List<T> entities = new List<T>();

            List<string> DtoKeys = GetDtoKeys<T>(id);

            foreach (string cacheKey in DtoKeys)
            {
                T? dto = _memoryCache.Get<T>(cacheKey);
                if (dto != null)
                {
                    entities.Add(dto);
                }
            }

            return entities;
        }

        public List<T> GetEntities<T>(string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            List<T> entities = new List<T>();

            List<string> DtoKeys = GetDtoKeys<T>(id);

            foreach (string cacheKey in DtoKeys)
            {
                T? dto = _memoryCache.Get<T>(cacheKey);
                if (dto != null)
                {
                    entities.Add(dto);
                }
            }

            return entities;
        }

        private List<string> GetDtoKeys<T>(string id) where T : class
        {
            List<string> DtoKeys = new();

            var cacheEntriesCollection = _memoryCache as IDictionary<object, object>;
            if (cacheEntriesCollection != null)
            {
                foreach (var entry in cacheEntriesCollection)
                {
                    string? cacheKey = entry.Key.ToString();
                    if (cacheKey.StartsWith($"{id}_{typeof(T).Name}"))
                    {
                        DtoKeys.Add(cacheKey);
                    }
                }
            }

            return DtoKeys;
        }
    }

}
