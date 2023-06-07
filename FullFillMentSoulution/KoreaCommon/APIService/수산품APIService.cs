using KoreaCommon.Model;
using System.Net.Http.Json;

namespace KoreaCommon.Services
{
    public class 수산품APIService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7156/api/수산품";

        public 수산품APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<수산품>> GetAll수산품Async()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var 수산품List = await response.Content.ReadFromJsonAsync<List<수산품>>();
            return 수산품List;
        }

        public async Task<수산품> Get수산품ByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var 수산품 = await response.Content.ReadFromJsonAsync<수산품>();
            return 수산품;
        }

        public async Task<수산품> Create수산품Async(수산품 수산품)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, 수산품);
            response.EnsureSuccessStatusCode();

            var created수산품 = await response.Content.ReadFromJsonAsync<수산품>();
            return created수산품;
        }

        public async Task Update수산품Async(string id, 수산품 updated수산품)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", updated수산품);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete수산품Async(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
