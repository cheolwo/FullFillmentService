using System.Net.Http.Json;
using 수협Common.DTO;

namespace KoreaCommon.Services
{
    public class 수산창고APIService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7156/api/수산창고";

        public 수산창고APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Read수산창고DTO>> GetAll수산창고Async()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var 수산창고List = await response.Content.ReadFromJsonAsync<List<Read수산창고DTO>>();
            return 수산창고List;
        }

        public async Task<List<Read수산창고DTO>> Get수산창고With수산품목종류Async()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/With수산품목종류");
            response.EnsureSuccessStatusCode();

            var 수산창고List = await response.Content.ReadFromJsonAsync<List<Read수산창고DTO>>();
            return 수산창고List;
        }

        public async Task<Read수산창고DTO> Get수산창고ByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var 수산창고 = await response.Content.ReadFromJsonAsync<Read수산창고DTO>();
            return 수산창고;
        }

        public async Task<Read수산창고DTO> Get수산창고With수산품별재고현황Async(string 수산창고Id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{수산창고Id}/수산품별재고현황");
            response.EnsureSuccessStatusCode();

            var 수산창고 = await response.Content.ReadFromJsonAsync<Read수산창고DTO>();
            return 수산창고;
        }

        public async Task<Read수산창고DTO> Create수산창고Async(Create수산창고DTO 수산창고)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, 수산창고);
            response.EnsureSuccessStatusCode();

            var created수산창고 = await response.Content.ReadFromJsonAsync<Read수산창고DTO>();
            return created수산창고;
        }

        public async Task<Read수산창고DTO> Update수산창고Async(string id, Update수산창고DTO updated수산창고)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", updated수산창고);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Read수산창고DTO>();
            return result;
        }

        public async Task Delete수산창고Async(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
