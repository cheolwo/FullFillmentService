using Common.APIService;
using System.Net.Http.Json;

namespace 판매Common.APIService
{
    public class 주문자구매요약APICommandService : EntityCommandAPIService<주문자구매요약, Cud주문자구매요약DTO>
    {
        public 주문자구매요약APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 주문자구매요약APIQueryService : EntityQueryAPIService<주문자구매요약, Read주문자구매요약DTO>
    {
        public 주문자구매요약APIQueryService(HttpClient httpClient) 
            : base(httpClient)
        {
        }
        public async Task<Read주문자구매요약DTO> Get주문자구매요약ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자구매요약/{id}");
            response.EnsureSuccessStatusCode();
            var 주문자구매요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 주문자구매요약DTO;
        }
        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자상품판매정보요약(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWith판매자상품판매정보요약/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWith판매자/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWith판매자상품/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith주문자(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWith주문자/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWithRelatedData(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWithRelatedData/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<List<Read주문자구매요약DTO>> Get주문자구매요약By판매자Id(string 판매자Id)
        {
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetBy판매자Id/{판매자Id}");
            response.EnsureSuccessStatusCode();
            var 요약DTOs = await response.Content.ReadFromJsonAsync<List<Read주문자구매요약DTO>>();
            return 요약DTOs;
        }

        public async Task<List<Read주문자구매요약DTO>> Get주문자구매요약By구매일시(DateTime 구매일시)
        {
            var 구매일시String = 구매일시.ToString("yyyy-MM-ddTHH:mm:ss");
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetBy구매일시/{구매일시String}");
            response.EnsureSuccessStatusCode();
            var 요약DTOs = await response.Content.ReadFromJsonAsync<List<Read주문자구매요약DTO>>();
            return 요약DTOs;
        }
    }
}
