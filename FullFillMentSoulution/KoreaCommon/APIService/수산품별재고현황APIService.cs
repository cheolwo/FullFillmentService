using System.Net.Http.Json;
using 수협Common.DTO;

namespace KoreaCommon.Services
{
    public class 수산품별재고현황APIService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7156/api/수산품별재고현황";

        public 수산품별재고현황APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Read수산품별재고현황DTO>> GetAll수산품별재고현황Async()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var 수산품별재고현황List = await response.Content.ReadFromJsonAsync<List<Read수산품별재고현황DTO>>();
            return 수산품별재고현황List;
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

        public async Task<Read수산품별재고현황DTO> Create수산품별재고현황Async(Create수산품별재고현황DTO 수산품별재고현황)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, 수산품별재고현황);
            response.EnsureSuccessStatusCode();

            var created수산품별재고현황 = await response.Content.ReadFromJsonAsync<Read수산품별재고현황DTO>();
            return created수산품별재고현황;
        }

        public async Task Update수산품별재고현황Async(string id, Update수산품별재고현황DTO updated수산품별재고현황)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", updated수산품별재고현황);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete수산품별재고현황Async(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}