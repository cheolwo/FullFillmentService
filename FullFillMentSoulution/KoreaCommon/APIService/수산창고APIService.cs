using Common.APIService;
using System.Net.Http.Json;
using 수협Common.DTO;
using 수협Common.Model;

namespace 수협Common.APIServices
{
    public class 수산창고APICommandService : EntityCommandAPIService<수산창고, Cud수산창고DTO>
    {
        public 수산창고APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 수산창고APIQueryService : EntityQueryAPIService<수산창고, Read수산창고DTO>
    {
        private const string BaseUrl = "https://localhost:7156/api/수산창고";

        public 수산창고APIQueryService(HttpClient httpClient)
            :base(httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Read수산창고DTO>> Get수산창고With수산품목종류Async()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/With수산품목종류");
            response.EnsureSuccessStatusCode();

            var 수산창고List = await response.Content.ReadFromJsonAsync<List<Read수산창고DTO>>();
            return 수산창고List;
        }

        public async Task<Read수산창고DTO> Get수산창고With수산품별재고현황Async(string 수산창고Id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{수산창고Id}/수산품별재고현황");
            response.EnsureSuccessStatusCode();

            var 수산창고 = await response.Content.ReadFromJsonAsync<Read수산창고DTO>();
            return 수산창고;
        }
    }
}
