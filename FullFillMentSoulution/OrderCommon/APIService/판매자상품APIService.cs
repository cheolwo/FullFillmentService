using System.Net;
using System.Net.Http.Json;
using 주문Common.Model;

namespace OrderClient.Services
{
    public class 판매자상품APIService
    {
        private readonly HttpClient _httpClient;

        public 판매자상품APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7007");
        }

        public async Task<List<판매자상품>> GetAll판매자상품()
        {
            var response = await _httpClient.GetAsync("api/판매자상품");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<판매자상품>>();
            return 판매자상품List;
        }

        public async Task<판매자상품> Get판매자상품ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 판매자상품 = await response.Content.ReadFromJsonAsync<판매자상품>();
                return 판매자상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("판매자상품 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<판매자상품> Create판매자상품(판매자상품 판매자상품)
        {
            var response = await _httpClient.PostAsJsonAsync("api/판매자상품", 판매자상품);
            response.EnsureSuccessStatusCode();
            var created판매자상품 = await response.Content.ReadFromJsonAsync<판매자상품>();
            return created판매자상품;
        }

        public async Task<판매자상품> Update판매자상품(string id, 판매자상품 updated판매자상품)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/판매자상품/{id}", updated판매자상품);
            if (response.IsSuccessStatusCode)
            {
                var 판매자상품 = await response.Content.ReadFromJsonAsync<판매자상품>();
                return 판매자상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("판매자상품 업데이트 중에 오류가 발생했습니다.");
            }
        }

        public async Task<bool> Delete판매자상품(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/판매자상품/{id}");
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
                throw new Exception("판매자상품 삭제 중에 오류가 발생했습니다.");
            }
        }

        public async Task<List<주문>> Get주문By판매자상품Id(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/주문");
            if (response.IsSuccessStatusCode)
            {
                var 주문들 = await response.Content.ReadFromJsonAsync<List<주문>>();
                return 주문들;
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

        public async Task<판매자> Get판매자By판매자상품Id(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/판매자");
            if (response.IsSuccessStatusCode)
            {
                var 판매자 = await response.Content.ReadFromJsonAsync<판매자>();
                return 판매자;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("판매자 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<판매자상품> Get판매자상품With판매자And주문(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/{id}/판매자와주문");
            if (response.IsSuccessStatusCode)
            {
                var 판매자상품 = await response.Content.ReadFromJsonAsync<판매자상품>();
                return 판매자상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("판매자상품 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<List<판매자상품>> Get판매자상품ByPriceAbove(double price)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/price/above/{price}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<판매자상품>>();
            return 판매자상품List;
        }

        public async Task<List<판매자상품>> Get판매자상품ByPriceBelow(double price)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/price/below/{price}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<판매자상품>>();
            return 판매자상품List;
        }

        public async Task<List<판매자상품>> Get판매자상품ByPriceInRange(double minPrice, double maxPrice)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/price/range/{minPrice}/{maxPrice}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<판매자상품>>();
            return 판매자상품List;
        }

        public async Task<List<판매자상품>> Get판매자상품BySaleDateBefore(string date)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/before/{date}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<판매자상품>>();
            return 판매자상품List;
        }

        public async Task<List<판매자상품>> Get판매자상품BySaleDateAfter(string date)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/after/{date}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<판매자상품>>();
            return 판매자상품List;
        }

        public async Task<List<판매자상품>> Get판매자상품BySaleDateRange(string startDate, string endDate)
        {
            var response = await _httpClient.GetAsync($"api/판매자상품/saledate/range/{startDate}/{endDate}");
            response.EnsureSuccessStatusCode();
            var 판매자상품List = await response.Content.ReadFromJsonAsync<List<판매자상품>>();
            return 판매자상품List;
        }
    }
}
