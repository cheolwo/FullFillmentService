using Common.APIService;
using System.Net;
using System.Net.Http.Json;
using 주문Common.DTO.For주문;
using 주문Common.Model;

namespace OrderCommon.Services.API
{
    public class 주문APICommandService : EntityCommandAPIService<주문, Cud주문DTO>
    {
        public 주문APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 주문APIQueryService : EntityQueryAPIService<주문, Read주문DTO>
    {
        public 주문APIQueryService(HttpClient httpClient)
            :base(httpClient)
        {
        }

        public async Task<List<Read주문DTO>> GetAll주문()
        {
            var response = await _httpClient.GetAsync("api/주문");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문List;
        }

        public async Task<Read주문DTO> Get주문ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<Read주문DTO>();
                return 주문;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문 조회 중에 오류가 발생했습니다.");
            }
        }
        public async Task<Read주문DTO> Get주문ByIdWith판매자상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith판매자상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<Read주문DTO>();
                return 주문;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read주문DTO> Get주문ByIdWith주문자(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith주문자/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<Read주문DTO>();
                return 주문;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read주문DTO> Get주문ByIdWith판매자(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith판매자/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<Read주문DTO>();
                return 주문;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read주문DTO> Get주문ByIdWith판매자And판매자상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith판매자And판매자상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<Read주문DTO>();
                return 주문;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read주문DTO> Get주문ByIdWith판매자And판매자상품And주문자(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith판매자And판매자상품And주문자/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<Read주문DTO>();
                return 주문;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<List<Read주문DTO>> Get주문ByPriceAbove(double price)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceAbove/{price}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문List;
        }

        public async Task<List<Read주문DTO>> Get주문ByPriceBelow(double price)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceBelow/{price}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문List;
        }

        public async Task<List<Read주문DTO>> Get주문ByPriceInRange(double minPrice, double maxPrice)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceInRange/{minPrice}/{maxPrice}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문List;
        }
    }
}
