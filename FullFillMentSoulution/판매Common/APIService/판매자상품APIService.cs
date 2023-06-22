using Common.APIService;
using System.Net.Http.Json;
using 주문Common.DTO.판매자;
using 주문Common.DTO.판매자상품;
using 주문Common.Model;

namespace 판매Common.APIService
{
    public class 판매자상품APICommandService : EntityCommandAPIService<판매자상품, Cud판매자DTO>
    {
        public 판매자상품APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 판매자상품APIQueryService : EntityQueryAPIService<판매자, Read판매자DTO>
    {
        public 판매자상품APIQueryService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Read판매자상품DTO> Get판매자상품ByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return 판매자상품DTO;
        }

        public async Task<Read판매자상품DTO> Get판매자상품With주문Async(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/주문");
            response.EnsureSuccessStatusCode();
            var 판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return 판매자상품DTO;
        }

        public async Task<Read판매자상품DTO> Get판매자상품With판매자Async(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/판매자");
            response.EnsureSuccessStatusCode();
            var 판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return 판매자상품DTO;
        }

        public async Task<Read판매자상품DTO> Get판매자상품With판매자And주문Async(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/판매자와주문");
            response.EnsureSuccessStatusCode();
            var 판매자상품DTO = await response.Content.ReadFromJsonAsync<Read판매자상품DTO>();
            return 판매자상품DTO;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceAboveAsync(double price)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/price/above/{price}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceBelowAsync(double price)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/price/below/{price}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceInRangeAsync(double minPrice, double maxPrice)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/price/range/{minPrice}/{maxPrice}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateBeforeAsync(string date)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/before/{date}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateAfterAsync(string date)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/after/{date}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateRangeAsync(string startDate, string endDate)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/range/{startDate}/{endDate}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<Read판매자상품DTO>>();
            return 판매자상품List;
        }
    }
}
