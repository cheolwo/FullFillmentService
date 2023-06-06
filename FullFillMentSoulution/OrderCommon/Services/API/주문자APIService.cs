using System.Net.Http.Json;
using System.Net;
using 주문Common.Model;

namespace OrderCommon.Services.API
{
    public class 주문자ApiService
    {
        private readonly HttpClient _httpClient;
        public 주문자ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<주문자>> GetAll주문자()
        {
            var response = await _httpClient.GetAsync("api/주문자");
            response.EnsureSuccessStatusCode();
            var 주문자List = await response.Content.ReadFromJsonAsync<List<주문자>>();
            return 주문자List;
        }

        public async Task<주문자> Get주문자ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문자 = await response.Content.ReadFromJsonAsync<주문자>();
                return 주문자;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문자 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<List<주문>> GetOrdersByCustomerId(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자/{id}/주문들");
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
                throw new Exception("주문자의 주문 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<주문자> Create주문자(주문자 주문자)
        {
            var response = await _httpClient.PostAsJsonAsync("api/주문자", 주문자);
            response.EnsureSuccessStatusCode();
            var created주문자 = await response.Content.ReadFromJsonAsync<주문자>();
            return created주문자;
        }

        public async Task<주문자> Update주문자(string id, 주문자 updated주문자)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/주문자/{id}", updated주문자);
            if (response.IsSuccessStatusCode)
            {
                var 주문자 = await response.Content.ReadFromJsonAsync<주문자>();
                return 주문자;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문자 업데이트 중에 오류가 발생했습니다.");
            }
        }

        public async Task<bool> Delete주문자(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/주문자/{id}");
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
                throw new Exception("주문자 삭제 중에 오류가 발생했습니다.");
            }
        }
    }
}
