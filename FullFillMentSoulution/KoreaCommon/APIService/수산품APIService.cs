using System.Net.Http.Json;
using 수협Common.DTO;

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

        public async Task<List<Read수산품DTO>> GetAll수산품Async()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var 수산품List = await response.Content.ReadFromJsonAsync<List<Read수산품DTO>>();
            return 수산품List;
        }

        public async Task<Read수산품DTO> Get수산품ByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var 수산품 = await response.Content.ReadFromJsonAsync<Read수산품DTO>();
            return 수산품;
        }

        public async Task<Read수산품DTO> Create수산품Async(Create수산품DTO 수산품)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, 수산품);
            response.EnsureSuccessStatusCode();

            var created수산품 = await response.Content.ReadFromJsonAsync<Read수산품DTO>();
            return created수산품;
        }

        public async Task<Read수산품DTO> Update수산품Async(string id, Update수산품DTO updated수산품)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", updated수산품);
            response.EnsureSuccessStatusCode();

            var updated수산품Dto = await response.Content.ReadFromJsonAsync<Read수산품DTO>();
            return updated수산품Dto;
        }

        public async Task Delete수산품Async(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
