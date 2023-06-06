using System.Net;
using System.Net.Http.Json;
using 주문Common.Model;

namespace OrderCommon.Services.API
{
    public class 주문APIService
    {
        private readonly HttpClient _httpClient;
        public 주문APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<주문>> GetAll주문()
        {
            var response = await _httpClient.GetAsync("api/주문");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<주문>>();
            return 주문List;
        }

        public async Task<주문> Get주문ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<주문>();
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

        public async Task<주문> Create주문(주문 주문)
        {
            var response = await _httpClient.PostAsJsonAsync("api/주문", 주문);
            response.EnsureSuccessStatusCode();
            var created주문 = await response.Content.ReadFromJsonAsync<주문>();
            return created주문;
        }

        public async Task<주문> Update주문(string id, 주문 updated주문)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/주문/{id}", updated주문);
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<주문>();
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

        public async Task<주문> Get주문ByIdWith판매자상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith판매자상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<주문>();
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

        public async Task<주문> Get주문ByIdWith주문자(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith주문자/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<주문>();
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

        public async Task<주문> Get주문ByIdWith판매자(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith판매자/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<주문>();
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

        public async Task<주문> Get주문ByIdWith판매자And판매자상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith판매자And판매자상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<주문>();
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

        public async Task<주문> Get주문ByIdWith판매자And판매자상품And주문자(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByIdWith판매자And판매자상품And주문자/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문 = await response.Content.ReadFromJsonAsync<주문>();
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

        public async Task<List<주문>> Get주문ByPriceAbove(double price)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceAbove/{price}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<주문>>();
            return 주문List;
        }

        public async Task<List<주문>> Get주문ByPriceBelow(double price)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceBelow/{price}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<주문>>();
            return 주문List;
        }

        public async Task<List<주문>> Get주문ByPriceInRange(double minPrice, double maxPrice)
        {
            var response = await _httpClient.GetAsync($"api/주문/GetByPriceInRange/{minPrice}/{maxPrice}");
            response.EnsureSuccessStatusCode();
            var 주문List = await response.Content.ReadFromJsonAsync<List<주문>>();
            return 주문List;
        }
    }
}
