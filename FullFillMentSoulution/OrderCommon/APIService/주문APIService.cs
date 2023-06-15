using Common.APIService;
using System.Net;
using System.Net.Http.Json;
using 주문Common.DTO.For주문;

namespace OrderCommon.Services.API
{
    public class 주문APIService : JwtTokenAPIService
    {
        public 주문APIService(HttpClient httpClient)
            :base(httpClient)
        {
        }

        public async Task<List<Read주문DTO>> GetAll주문()
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync("api/주문");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문List;
        }

        public async Task<Read주문DTO> Get주문ById(string id)
        {
            ReadyBearerToken();
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

        public async Task<Read주문DTO> Create주문(Create주문DTO 주문)
        {
            ReadyBearerToken();
            var response = await _httpClient.PostAsJsonAsync("api/주문", 주문);
            response.EnsureSuccessStatusCode();
            var created주문 = await response.Content.ReadFromJsonAsync<Read주문DTO>();
            return created주문;
        }

        public async Task<Read주문DTO> Update주문(string id, Update주문DTO updated주문)
        {
            ReadyBearerToken();
            var response = await _httpClient.PutAsJsonAsync($"api/주문/{id}", updated주문);
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
                throw new Exception("주문 업데이트 중에 오류가 발생했습니다.");
            }
        }

        public async Task<bool> Delete주문(string id)
        {
            ReadyBearerToken();
            var response = await _httpClient.DeleteAsync($"api/주문/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                throw new Exception("주문 삭제 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read주문DTO> Get주문ByIdWith판매자상품(string id)
        {
            ReadyBearerToken();
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
            ReadyBearerToken();
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
            ReadyBearerToken();
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
            ReadyBearerToken();
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
            ReadyBearerToken();
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
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceAbove/{price}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문List;
        }

        public async Task<List<Read주문DTO>> Get주문ByPriceBelow(double price)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceBelow/{price}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문List;
        }

        public async Task<List<Read주문DTO>> Get주문ByPriceInRange(double minPrice, double maxPrice)
        {
            ReadyBearerToken();
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceInRange/{minPrice}/{maxPrice}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
            return 주문List;
        }
    }
}
