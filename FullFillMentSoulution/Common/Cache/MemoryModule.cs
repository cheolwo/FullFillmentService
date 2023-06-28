using Common.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace Common.Cache
{
    public class MemoryModule
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryModule(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public void SetEntities<T>(List<T> entities) where T : ReadDto
        {
            foreach (var Dto in entities)
            {
                string cacheKey = $"{typeof(T).Name}_{Dto.Id}";
                //jwtToken.GetUserIdFromToken();
                //$"{}_{typeof(T).Name}_{Dto.Id}"
                _memoryCache.Set(cacheKey, Dto);
            }
        }
        public T? GetDto<T>(string DtoId) where T : ReadDto 
        {
            string cacheKey = $"{typeof(T).Name}_{DtoId}";
            return _memoryCache.Get<T>(cacheKey);
        }
        public void SetDto<T>(string DtoId, T Dto) where T : ReadDto
        {
            string cacheKey = $"{typeof(T).Name}_{DtoId}";
            _memoryCache.Set(cacheKey, Dto);
        }
        public void RemoveDto<T>(string DtoId) where T : ReadDto
        {
            string cacheKey = $"{typeof(T).Name}_{DtoId}";
            _memoryCache.Remove(cacheKey);
        }
        public List<T> LoadEntities<T>() where T : ReadDto
        {
            List<T> entities = new List<T>();

            List<string> DtoKeys = GetDtoKeys<T>();

            foreach (string cacheKey in DtoKeys)
            {
                T? Dto = _memoryCache.Get<T>(cacheKey);
                if (Dto != null)
                {
                    entities.Add(Dto);
                }
            }

            return entities;
        }
        public List<T> GetEntities<T>() where T : ReadDto
        {
            List<T> entities = new List<T>();

            List<string> DtoKeys = GetDtoKeys<T>();

            foreach (string cacheKey in DtoKeys)
            {
                T? Dto = _memoryCache.Get<T>(cacheKey);
                if (Dto != null)
                {
                    entities.Add(Dto);
                }
            }

            return entities;
        }
        private List<string> GetDtoKeys<T>() where T : ReadDto
        {
            List<string> DtoKeys = new();

            var cacheEntriesCollection = _memoryCache as IDictionary<object, object>;
            if (cacheEntriesCollection != null)
            {
                foreach (var entry in cacheEntriesCollection)
                {
                    string? cacheKey = entry.Key.ToString();
                    if (cacheKey.StartsWith($"{typeof(T).Name}"))
                    {
                        DtoKeys.Add(cacheKey);
                    }
                }
            }

            return DtoKeys;
        }
    }

}
