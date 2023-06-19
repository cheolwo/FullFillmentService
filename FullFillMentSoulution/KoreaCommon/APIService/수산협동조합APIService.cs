using Common.APIService;
using System.Net.Http.Json;
using 수협Common.DTO;
using 수협Common.Model;

namespace 수협Common.APIServices
{
    public class 수산협동조합APICommandService : EntityCommandAPIService<수산협동조합, Cud수산협동조합DTO>
    {
        public 수산협동조합APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 수산협동조합APIQueryService : EntityQueryAPIService<수산품별재고현황, Read수산품별재고현황DTO>
    {
        private const string BaseUrl = "https://localhost:7156/api/수산협동조합";

        public 수산협동조합APIQueryService(HttpClient httpClient) :base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Read수산협동조합DTO>> GetAll수산협동조합Async()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var 수산협동조합List = await response.Content.ReadFromJsonAsync<List<Read수산협동조합DTO>>();
            return 수산협동조합List;
        }

        public async Task<Read수산협동조합DTO> Get수산협동조합ByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var 수산협동조합 = await response.Content.ReadFromJsonAsync<Read수산협동조합DTO>();
            return 수산협동조합;
        }

        public async Task<Read수산협동조합DTO> Get수산창고With수산품별재고현황Async(string 수산협동조합Id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{수산협동조합Id}/수산창고");
            response.EnsureSuccessStatusCode();

            var 수산창고 = await response.Content.ReadFromJsonAsync<Read수산협동조합DTO>();
            return 수산창고;
        }

        public async Task<List<Read수산협동조합DTO>> GetAll수산협동조합With수산창고Async()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/With수산창고");
            response.EnsureSuccessStatusCode();

            var 수산협동조합List = await response.Content.ReadFromJsonAsync<List<Read수산협동조합DTO>>();
            return 수산협동조합List;
        }
    }
}
