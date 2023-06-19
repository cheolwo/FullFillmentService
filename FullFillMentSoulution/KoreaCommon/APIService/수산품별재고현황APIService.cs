using Common.APIService;
using System.Net.Http.Json;
using 수협Common.DTO;
using 수협Common.Model;

namespace 수협Common.APIServices
{
    public class 수산품별재고현황APICommandService : EntityCommandAPIService<수산품별재고현황, Cud수산품별재고현황DTO>
    {
        public 수산품별재고현황APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 수산품별재고현황APIQueryService : EntityQueryAPIService<수산품별재고현황, Read수산품별재고현황DTO>
    {
        private const string BaseUrl = "https://localhost:7156/api/수산품별재고현황";

        public 수산품별재고현황APIQueryService(HttpClient httpClient) :base(httpClient)
        {
        }
        public async Task<List<Read수산품별재고현황DTO>> Get수산품별재고현황By창고번호Async(string 창고번호)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/by창고번호/{창고번호}");
            response.EnsureSuccessStatusCode();

            var 수산품별재고현황List = await response.Content.ReadFromJsonAsync<List<Read수산품별재고현황DTO>>();
            return 수산품별재고현황List;
        }

        public async Task<Read수산품별재고현황DTO> Get수산품별재고현황ByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var 수산품별재고현황 = await response.Content.ReadFromJsonAsync<Read수산품별재고현황DTO>();
            return 수산품별재고현황;
        }
    }
}