using System.Net.Http.Json;
using 계정Common.API;
using 주문Common.DTO.주문자구매요약;

namespace 주문Common.APIService
{
    public class 주문자구매요약APIService : JwtTokenAPIService
    {
        public 주문자구매요약APIService(HttpClient httpClient) 
            : base(httpClient)
        {
        }
        public async Task<Read주문자구매요약DTO> Create주문자구매요약(Create주문자구매요약DTO 주문자구매요약DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PostAsJsonAsync("api/주문자구매요약", 주문자구매요약DTO);
            response.EnsureSuccessStatusCode();
            var created주문자구매요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return created주문자구매요약DTO;
        }

        public async Task Update주문자구매요약(string id, Update주문자구매요약DTO updated주문자구매요약DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PutAsJsonAsync($"api/주문자구매요약/{id}", updated주문자구매요약DTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ById(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자구매요약/{id}");
            response.EnsureSuccessStatusCode();
            var 주문자구매요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 주문자구매요약DTO;
        }

        public async Task Delete주문자구매요약(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.DeleteAsync($"api/주문자구매요약/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자상품판매정보요약(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWith판매자상품판매정보요약/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWith판매자/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자상품(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWith판매자상품/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith주문자(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWith주문자/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWithRelatedData(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetByIdWithRelatedData/{id}");
            response.EnsureSuccessStatusCode();
            var 요약DTO = await response.Content.ReadFromJsonAsync<Read주문자구매요약DTO>();
            return 요약DTO;
        }

        public async Task<List<Read주문자구매요약DTO>> Get주문자구매요약By판매자Id(string 판매자Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetBy판매자Id/{판매자Id}");
            response.EnsureSuccessStatusCode();
            var 요약DTOs = await response.Content.ReadFromJsonAsync<List<Read주문자구매요약DTO>>();
            return 요약DTOs;
        }

        public async Task<List<Read주문자구매요약DTO>> Get주문자구매요약By구매일시(DateTime 구매일시)
        {
            ReadyBearerToken();
            var 구매일시String = 구매일시.ToString("yyyy-MM-ddTHH:mm:ss");
            var response = await _httpClient.GetAsync($"api/주문자구매요약/GetBy구매일시/{구매일시String}");
            response.EnsureSuccessStatusCode();
            var 요약DTOs = await response.Content.ReadFromJsonAsync<List<Read주문자구매요약DTO>>();
            return 요약DTOs;
        }
    }
}
