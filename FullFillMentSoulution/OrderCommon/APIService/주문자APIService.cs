using System.Net.Http.Json;
using 주문Common.DTO.주문자;
using 주문Common.DTO.For주문;
using 주문Common.DTO.댓글;
using 주문Common.DTO.상품문의;
using Common.APIService;

namespace OrderCommon.Services.API
{
    public class 주문자ApiService : JwtTokenAPIService
    {
        public 주문자ApiService(HttpClient httpClient) : base(httpClient) 
        {
        }
        public async Task<List<Read주문DTO>> GetOrdersByCustomerId(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자/{id}/주문들");
            response.EnsureSuccessStatusCode();
            var 주문DTOs = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문DTOs;
        }

        public async Task<List<Read주문자DTO>> GetAll주문자()
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync("api/주문자");
            response.EnsureSuccessStatusCode();
            var 주문자DTOs = await response.Content.ReadFromJsonAsync<List<Read주문자DTO>>();
            return 주문자DTOs;
        }

        public async Task<Read주문자DTO> Get주문자ById(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자/{id}");
            response.EnsureSuccessStatusCode();
            var 주문자DTO = await response.Content.ReadFromJsonAsync<Read주문자DTO>();
            return 주문자DTO;
        }

        public async Task<Read주문자DTO> Create주문자(Create주문자DTO 주문자DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PostAsJsonAsync("api/주문자", 주문자DTO);
            response.EnsureSuccessStatusCode();
            var created주문자DTO = await response.Content.ReadFromJsonAsync<Read주문자DTO>();
            return created주문자DTO;
        }

        public async Task Update주문자(string id, Update주문자DTO updated주문자DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PutAsJsonAsync($"api/주문자/{id}", updated주문자DTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete주문자(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.DeleteAsync($"api/주문자/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Read댓글DTO>> GetCommentsByCustomerId(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자/{id}/댓글들");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read상품문의DTO>> GetInquiriesByCustomerId(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자/{id}/상품문의들");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }
    }
}
