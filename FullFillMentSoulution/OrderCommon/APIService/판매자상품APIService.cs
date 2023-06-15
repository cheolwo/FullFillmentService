using Common.APIService;
using System.Net.Http.Json;
using 주문Common.DTO.판매자상품;


namespace OrderClient.Services
{
    public class 판매자상품APIService : JwtTokenAPIService
    {
        public 판매자상품APIService(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<Read판매자상품DTO> Create판매자상품Async(Create판매자상품DTO 판매자상품DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PostAsJsonAsync("api/판매자상품", 판매자상품DTO);
            response.EnsureSuccessStatusCode();
            var created판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return created판매자상품DTO;
        }

        public async Task Update판매자상품Async(string id, Update판매자상품DTO updated판매자상품DTO)
        {
            ReadyBearerToken();
            var response = await _httpClient.PutAsJsonAsync($"api/판매자상품/{id}", updated판매자상품DTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete판매자상품Async(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.DeleteAsync($"api/판매자상품/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Read판매자상품DTO> Get판매자상품ByIdAsync(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return 판매자상품DTO;
        }

        public async Task<Read판매자상품DTO> Get판매자상품With주문Async(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/주문");
            response.EnsureSuccessStatusCode();
            var 판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return 판매자상품DTO;
        }

        public async Task<Read판매자상품DTO> Get판매자상품With판매자Async(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/판매자");
            response.EnsureSuccessStatusCode();
            var 판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return 판매자상품DTO;
        }

        public async Task<Read판매자상품DTO> Get판매자상품With판매자And주문Async(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/판매자와주문");
            response.EnsureSuccessStatusCode();
            var 판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return 판매자상품DTO;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceAboveAsync(double price)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/price/above/{price}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceBelowAsync(double price)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/price/below/{price}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceInRangeAsync(double minPrice, double maxPrice)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/price/range/{minPrice}/{maxPrice}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateBeforeAsync(string date)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/before/{date}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateAfterAsync(string date)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/after/{date}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateRangeAsync(string startDate, string endDate)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/range/{startDate}/{endDate}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }
    }
}
