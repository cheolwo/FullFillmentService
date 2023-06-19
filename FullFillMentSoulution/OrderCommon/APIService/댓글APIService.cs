using Common.APIService;
using System.Net.Http.Json;
using 주문Common.DTO.For주문;
using 주문Common.DTO.댓글;
using 주문Common.Model;

namespace 주문Common.APIService
{
    public class 댓글APICommandService : EntityCommandAPIService<댓글, Cud댓글DTO>
    {
        public 댓글APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 댓글APIService : EntityQueryAPIService<댓글, Read댓글DTO>
    {
        public 댓글APIService(HttpClient httpClient)
            : base(httpClient) 
        {

        }
        public async Task<List<Read댓글DTO>> Get댓글By판매자상품Id(string 판매자상품Id)
        {
            var response = await _httpClient.GetAsync($"api/댓글/판매자상품/{판매자상품Id}");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By주문자Id(string 주문자Id)
        {
            var response = await _httpClient.GetAsync($"api/댓글/주문자/{주문자Id}");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By판매자상품IdWith주문자(string 판매자상품Id)
        {
            var response = await _httpClient.GetAsync($"api/댓글/판매자상품/{판매자상품Id}/주문자");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By주문자IdWith판매자상품(string 주문자Id)
        {
            var response = await _httpClient.GetAsync($"api/댓글/주문자/{주문자Id}/판매자상품");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            var response = await _httpClient.GetAsync($"api/댓글/판매자상품/{판매자상품Id}/주문자And판매자");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            var response = await _httpClient.GetAsync($"api/댓글/주문자/{주문자Id}/판매자상품And주문자");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

    }
}
