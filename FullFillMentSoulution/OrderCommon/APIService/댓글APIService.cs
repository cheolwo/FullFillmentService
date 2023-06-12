using System.Net.Http.Json;
using 계정Common.API;
using 주문Common.DTO.댓글;

namespace 주문Common.APIService
{
    public class 댓글APIService : JwtTokenAPIService
    {
        public 댓글APIService(HttpClient httpClient)
            : base(httpClient) 
        {

        }
        public async Task<List<Read댓글DTO>> Get댓글By판매자상품Id(string 판매자상품Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/댓글/판매자상품/{판매자상품Id}");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By주문자Id(string 주문자Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/댓글/주문자/{주문자Id}");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By판매자상품IdWith주문자(string 판매자상품Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/댓글/판매자상품/{판매자상품Id}/주문자");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By주문자IdWith판매자상품(string 주문자Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/댓글/주문자/{주문자Id}/판매자상품");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/댓글/판매자상품/{판매자상품Id}/주문자And판매자");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<List<Read댓글DTO>> Get댓글By주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/댓글/주문자/{주문자Id}/판매자상품And주문자");
            response.EnsureSuccessStatusCode();
            var 댓글DTOs = await response.Content.ReadFromJsonAsync<List<Read댓글DTO>>();
            return 댓글DTOs;
        }

        public async Task<Read댓글DTO> Create댓글(Create댓글DTO 댓글DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PostAsJsonAsync("api/댓글", 댓글DTO);
            response.EnsureSuccessStatusCode();
            var created댓글DTO = await response.Content.ReadFromJsonAsync<Read댓글DTO>();
            return created댓글DTO;
        }

        public async Task Update댓글(string id, Update댓글DTO updated댓글DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PutAsJsonAsync($"api/댓글/{id}", updated댓글DTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete댓글(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.DeleteAsync($"api/댓글/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
