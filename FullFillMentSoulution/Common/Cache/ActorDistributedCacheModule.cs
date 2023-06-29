using Common.DTO;
using Newtonsoft.Json;
using StackExchange.Redis;
using 계정Common.Extensions;

namespace Common.Cache
{
    public class ActorDistributedCacheModule
    {
        private readonly IDatabase _database;

        public ActorDistributedCacheModule(ConnectionMultiplexer connectionMultiplexer)
        {
            _database = connectionMultiplexer.GetDatabase();
        }

        public void SetEntities<T>(List<T> entities, string token) where T : IStoreableInMemory
        {
            var id = token.GetUserIdFromToken();

            foreach (var dto in entities)
            {
                string cacheKey = $"{id}_{typeof(T).Name}_{dto.GetId()}";
                var serializedDto = SerializeObject(dto);
                _database.StringSet(cacheKey, serializedDto);
            }
        }

        public T? GetDto<T>(string DtoId, string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            string cacheKey = $"{id}_{typeof(T).Name}_{DtoId}";
            var serializedDto = _database.StringGet(cacheKey);
            return DeserializeObject<T>(serializedDto);
        }

        public void SetDto<T>(string DtoId, T Dto, string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            string cacheKey = $"{id}_{typeof(T).Name}_{DtoId}";
            var serializedDto = SerializeObject(Dto);
            _database.StringSet(cacheKey, serializedDto);
        }

        public void RemoveDto<T>(string DtoId, string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            string cacheKey = $"{id}_{typeof(T).Name}_{DtoId}";
            _database.KeyDelete(cacheKey);
        }

        public List<T> LoadEntities<T>(string token) where T : class
        {
            var id = token.GetUserIdFromToken();
            List<T> entities = new List<T>();

            List<string> dtoKeys = GetDtoKeys<T>(id);

            foreach (string cacheKey in dtoKeys)
            {
                var serializedDto = _database.StringGet(cacheKey);
                var dto = DeserializeObject<T>(serializedDto);
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

            List<string> dtoKeys = GetDtoKeys<T>(id);

            foreach (string cacheKey in dtoKeys)
            {
                var serializedDto = _database.StringGet(cacheKey);
                var dto = DeserializeObject<T>(serializedDto);
                if (dto != null)
                {
                    entities.Add(dto);
                }
            }

            return entities;
        }

        private List<string> GetDtoKeys<T>(string id) where T : class
        {
            List<string> dtoKeys = new List<string>();

            var scanResult = _database.ScriptEvaluate(LuaScript.Prepare("return redis.call('keys', @pattern)"), new { pattern = $"{id}_{typeof(T).Name}*" });
            var keys = (RedisResult[])scanResult;

            foreach (var key in keys)
            {
                dtoKeys.Add(key.ToString());
            }

            return dtoKeys;
        }

        private string SerializeObject(object obj)
        {
            // Use your preferred serialization method to serialize the object into a string.
            // Replace the implementation below with your actual logic.
            return JsonConvert.SerializeObject(obj);
        }

        private T DeserializeObject<T>(string serializedObj)
        {
            // Use your preferred serialization method to deserialize the string into an object of type T.
            // Replace the implementation below with your actual logic.
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }
    }
}
