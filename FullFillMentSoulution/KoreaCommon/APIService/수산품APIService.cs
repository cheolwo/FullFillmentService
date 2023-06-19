using Common.APIService;
using System.Net.Http.Json;
using 수협Common.DTO;
using 수협Common.Model;

namespace 수협Common.APIServices
{
    public class 수산품APICommandService : EntityCommandAPIService<수산품, Cud수산품DTO>
    {
        public 수산품APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 수산품APIQueryService : EntityQueryAPIService<수산품, Read수산품DTO>
    {
        public 수산품APIQueryService(HttpClient httpClient)
            :base(httpClient)
        {
            _httpClient = httpClient;
        }
    }

}
