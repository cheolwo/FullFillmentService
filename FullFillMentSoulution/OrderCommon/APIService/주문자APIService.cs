using System.Net.Http.Json;
using 주문Common.DTO.주문자;
using 주문Common.DTO.For주문;
using 주문Common.DTO.댓글;
using 주문Common.DTO.상품문의;
using Common.APIService;
using 주문Common.Model;

namespace OrderCommon.Services.API
{
    public class 주문자APICommandService : EntityCommandAPIService<주문자, Cud주문자DTO>
    {
        public 주문자APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 주문자APIQueryService : EntityQueryAPIService<주문자, Read주문자DTO>
    {
        public 주문자APIQueryService(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<List<Read주문DTO>> GetOrdersByCustomerId(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자/{id}/주문들");
            response.EnsureSuccessStatusCode();
            var 주문DTOs = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문DTOs;
        }

        public async Task<List<Read주문자DTO>> GetAll주문자()
        {
            var response = await _httpClient.GetAsync("api/주문자");
            response.EnsureSuccessStatusCode();
            var 주문자DTOs = await response.Content.ReadFromJsonAsync<List<Read주문자DTO>>();
            return 주문자DTOs;
        }

        public async Task<Read주문자DTO> Get주문자ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자/{id}");
            response.EnsureSuccessStatusCode();
            var 주문자DTO = await response.Content.ReadFromJsonAsync<Read주문자DTO>();
            return 주문자DTO;
        }

        public async Task<List<Read댓글DTO>> GetCommentsByCustomerId(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자/{id}/댓글들");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read상품문의DTO>> GetInquiriesByCustomerId(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자/{id}/상품문의들");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }
    }
}
