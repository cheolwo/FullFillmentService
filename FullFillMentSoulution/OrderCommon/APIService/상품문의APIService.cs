using Common.APIService;
using System.Net.Http.Json;
using 주문Common.DTO.상품문의;
using 주문Common.Model;

namespace 주문Common.APIService
{
    public class 상품문의APICommandService : EntityCommandAPIService<상품문의, Cud상품문의DTO>
    {
        public 상품문의APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 상품문의APIService : EntityQueryAPIService<상품문의, Read상품문의DTO>
    {
        public 상품문의APIService(HttpClient httpClient) 
            : base(httpClient)
        {
        }
        public async Task<List<Read상품문의DTO>> Get상품문의By판매자상품Id(string 판매자상품Id)
        {
            var response = await _httpClient.GetAsync($"api/상품문의/{판매자상품Id}");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }
        public async Task<List<Read상품문의DTO>> Get상품문의By판매자상품IdWith판매자(string 판매자상품Id)
        {
            var response = await _httpClient.GetAsync($"api/상품문의/판매자상품/{판매자상품Id}");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By주문자Id(string 주문자Id)
        {
            var response = await _httpClient.GetAsync($"api/상품문의/주문자/{주문자Id}");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By주문자IdWith주문자(string 주문자Id)
        {
            var response = await _httpClient.GetAsync($"api/상품문의/주문자/{주문자Id}/with주문자");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            var response = await _httpClient.GetAsync($"api/상품문의/판매자상품/{판매자상품Id}/with주문자And판매자");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            var response = await _httpClient.GetAsync($"api/상품문의/주문자/{주문자Id}/with판매자상품And주문자");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }
    }
}
