using Common.Model;
using Microsoft.Extensions.Caching.Memory;

namespace Common.Cache
{
    public class MemoryModule<TEntity> where TEntity : Entity
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryModule(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public void SetEntities(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                string cacheKey = $"{typeof(TEntity).Name}_{entity.Id}";
                _memoryCache.Set(cacheKey, entity);
            }
        }
        public TEntity GetEntity(string entityId) 
        {
            string cacheKey = $"{typeof(TEntity).Name}_{entityId}";
            return _memoryCache.Get<TEntity>(cacheKey);
        }
        public void SetEntity(string entityId, TEntity entity)
        {
            string cacheKey = $"{typeof(TEntity).Name}_{entityId}";
            _memoryCache.Set(cacheKey, entity);
        }
        public void RemoveEntity(string entityId)
        {
            string cacheKey = $"{typeof(TEntity).Name}_{entityId}";
            _memoryCache.Remove(cacheKey);
        }
        public List<TEntity> LoadEntities()
        {
            List<TEntity> entities = new List<TEntity>();

            List<string> entityKeys = GetEntityKeys();

            foreach (string cacheKey in entityKeys)
            {
                TEntity entity = _memoryCache.Get<TEntity>(cacheKey);
                if (entity != null)
                {
                    entities.Add(entity);
                }
            }

            return entities;
        }
        public List<TEntity> GetEntities()
        {
            List<TEntity> entities = new List<TEntity>();

            List<string> entityKeys = GetEntityKeys();

            foreach (string cacheKey in entityKeys)
            {
                TEntity entity = _memoryCache.Get<TEntity>(cacheKey);
                if (entity != null)
                {
                    entities.Add(entity);
                }
            }

            return entities;
        }


        private List<string> GetEntityKeys()
        {
            List<string> entityKeys = new List<string>();

            var cacheEntriesCollection = _memoryCache as IDictionary<object, object>;
            if (cacheEntriesCollection != null)
            {
                foreach (var entry in cacheEntriesCollection)
                {
                    string cacheKey = entry.Key.ToString();
                    if (cacheKey.StartsWith($"{typeof(TEntity).Name}"))
                    {
                        entityKeys.Add(cacheKey);
                    }
                }
            }

            return entityKeys;
        }
    }

}
