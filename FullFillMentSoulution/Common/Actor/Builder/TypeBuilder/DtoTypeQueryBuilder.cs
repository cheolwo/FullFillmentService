using Common.Actor.Query;
using FrontCommon.Actor;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;

namespace Common.Actor.Builder.TypeBuilder
{
    public class DtoTypeQueryBuilder<TDto> : DtoTypeBuilder<TDto> where TDto : class
    {
        private string redisConnection;
        public DtoTypeQueryBuilder(IDtoTypeQueryConfiguration<TDto> configuration)
            :base(configuration)
        {
            configuration.Configure(this);
        }
        public DtoTypeQueryBuilder<TDto> SetRedisConnectionString(string connectionString)
        {
            redisConnection = connectionString;
            return this;
        }
        public async Task<List<TDto>?> GetToListAsync()
        {
            if (IsDistributed())
            {
                // Access data from Redis server
                var redisData = await GetFromRedisAsync();
                return ApplyQueryOptions(redisData);
            }
            else
            {
                var selectedRoute = GetSelectedBaseRoute();
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.GetAsync(selectedRoute.Route);
                    response.EnsureSuccessStatusCode();

                    var dtos = await response.Content.ReadFromJsonAsync<List<TDto>>();
                    return ApplyQueryOptions(dtos);
                }
            }
        }
        private async Task<List<TDto>?> GetFromRedisAsync()
        {
            var redisConfiguration = ConfigurationOptions.Parse(redisConnection); // Replace with your Redis server configuration

            // Create a Redis connection
            using (var connection = ConnectionMultiplexer.Connect(redisConfiguration))
            {
                // Get a reference to the Redis database
                var database = connection.GetDatabase();

                var redisKey = GenerateRedisKey(); // Replace with your Redis key generation logic

                // Retrieve the data from Redis as a string
                var redisValue = await database.StringGetAsync(redisKey);

                if (!redisValue.IsNull)
                {
                    // Deserialize the data from Redis
                    var dtos = DeserializeData(redisValue);

                    return ApplyQueryOptions(dtos);
                }
            }

            return null; // Placeholder for handling when data is not found in Redis
        }

        private List<TDto> DeserializeData(RedisValue redisValue)
        {
            // Implement logic to deserialize the RedisValue to List<TDto>
            // Example:
            var serializedData = redisValue.ToString();
            var dtos = JsonConvert.DeserializeObject<List<TDto>>(serializedData);
            return dtos;
        }

        private string GenerateRedisKey()
        {
            // Implement logic to generate a unique Redis key for the specific query
            // Example:
            var key = "order_query_key";
            return key;
        }

        private List<TDto> ApplyQueryOptions(List<TDto>? dtos)
        {
            return dtos;
        }
        private bool IsDistributed()
        {
            var distributedAttribute = typeof(TDto).GetCustomAttribute<DistributedAttribute>();
            return distributedAttribute != null;
        }

        private ServerBaseRouteInfo GetSelectedBaseRoute()
        {
            var IsCqrs = IsApiGatewayCompatible();
            if (IsCqrs)
            {
                // DTO에 CQRS 특성이 있고 활성화된 경우 API Gateway를 사용하는 서버 선택
                var selectedRoute = ServerBaseRoutes.FirstOrDefault(route => route.UseApiGateway);
                if (selectedRoute != null)
                {
                    return selectedRoute;
                }
            }

            // CQRS 특성이 없거나 비활성화된 경우 비즈니스 서버 선택
            var defaultRoute = ServerBaseRoutes.FirstOrDefault();
            if (defaultRoute != null)
            {
                return defaultRoute;
            }

            throw new Exception("No serve base route available.");
        }

        private bool IsApiGatewayCompatible()
        {
            var cqsAttribute = typeof(TDto).GetCustomAttribute<CQRSAttribute>();
            return cqsAttribute != null && cqsAttribute.IsEnabled;
        }
    }

}
