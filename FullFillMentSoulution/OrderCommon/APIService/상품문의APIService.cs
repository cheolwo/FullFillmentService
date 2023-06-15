using Common.APIService;
using System.Net.Http.Json;
using 주문Common.DTO.상품문의;

namespace 주문Common.APIService
{
    public class 상품문의APIService : JwtTokenAPIService
    {
        public 상품문의APIService(HttpClient httpClient) 
            : base(httpClient)
        {
        }
        public async Task<Read상품문의DTO> Create상품문의(Create상품문의DTO 상품문의DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PostAsJsonAsync("api/상품문의", 상품문의DTO);
            response.EnsureSuccessStatusCode();
            var created상품문의DTO = await response.Content.ReadFromJsonAsync<Read상품문의DTO>();
            return created상품문의DTO;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By판매자상품Id(string 판매자상품Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/상품문의/{판매자상품Id}");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task Update상품문의(string id, Update상품문의DTO updated상품문의DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PutAsJsonAsync($"api/상품문의/{id}", updated상품문의DTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete상품문의(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.DeleteAsync($"api/상품문의/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By판매자상품IdWith판매자(string 판매자상품Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/상품문의/판매자상품/{판매자상품Id}");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By주문자Id(string 주문자Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/상품문의/주문자/{주문자Id}");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By주문자IdWith주문자(string 주문자Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/상품문의/주문자/{주문자Id}/with주문자");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/상품문의/판매자상품/{판매자상품Id}/with주문자And판매자");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }

        public async Task<List<Read상품문의DTO>> Get상품문의By주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/상품문의/주문자/{주문자Id}/with판매자상품And주문자");
            response.EnsureSuccessStatusCode();
            var 상품문의DTOs = await response.Content.ReadFromJsonAsync<List<Read상품문의DTO>>();
            return 상품문의DTOs;
        }
    }
}
