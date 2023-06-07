using System.Net.Http.Json;
using 수협Common.DTO;

namespace KoreaCommon.Services
{
    public class 수산협동조합APIService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7156/api/수산협동조합";

        public 수산협동조합APIService(HttpClient httpClient)
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

        public async Task<Read수산협동조합DTO> Create수산협동조합Async(Create수산협동조합DTO 수산협동조합)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, 수산협동조합);
            response.EnsureSuccessStatusCode();

            var created수산협동조합 = await response.Content.ReadFromJsonAsync<Read수산협동조합DTO>();
            return created수산협동조합;
        }

        public async Task<Read수산협동조합DTO> Update수산협동조합Async(string id, Update수산협동조합DTO updated수산협동조합)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", updated수산협동조합);
            response.EnsureSuccessStatusCode();

            var update수산협동조합 = await response.Content.ReadFromJsonAsync<Read수산협동조합DTO>();
            return update수산협동조합;
        }

        public async Task Delete수산협동조합Async(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
