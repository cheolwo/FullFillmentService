using System.Net.Http.Json;
using System.Net;
using 주문Common.DTO.주문자;
using 주문Common.DTO.주문;

namespace OrderCommon.Services.API
{
    public class 주문자ApiService
    {
        private readonly HttpClient _httpClient;
        public 주문자ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7007");
        }
        public async Task<Read주문자DTO> GetByIdWithRelatedData(string id)
        {
            // 주문자 API의 initialize/{id} 엔드포인트에 GET 요청을 보냅니다.
            var response = await _httpClient.GetAsync($"api/주문자/initialize/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문자 = await response.Content.ReadFromJsonAsync<Read주문자DTO>();
                return 주문자;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주문자 데이터 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<List<Read주문자DTO>> GetAll주문자()
        {
            var response = await _httpClient.GetAsync("api/주문자");
            response.EnsureSuccessStatusCode();
            var 주문자List = await response.Content.ReadFromJsonAsync<List<Read주문자DTO>>();
            return 주문자List;
        }

        public async Task<Read주문자DTO> Get주문자ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 주문자 = await response.Content.ReadFromJsonAsync<Read주문자DTO>();
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

        public async Task<List<Read주문DTO>> GetOrdersByCustomerId(string id)
        {
            var response = await _httpClient.GetAsync($"api/주문자/{id}/주문들");
            if (response.IsSuccessStatusCode)
            {
                var 주문들 = await response.Content.ReadFromJsonAsync<List<Read주문DTO>>();
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

        public async Task<Read주문자DTO> Create주문자(Create주문자DTO 주문자)
        {
            var response = await _httpClient.PostAsJsonAsync("api/주문자", 주문자);
            response.EnsureSuccessStatusCode();
            var created주문자 = await response.Content.ReadFromJsonAsync<Read주문자DTO>();
            return created주문자;
        }

        public async Task<Read주문자DTO> Update주문자(string id, Update주문자DTO updated주문자)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/주문자/{id}", updated주문자);
            if (response.IsSuccessStatusCode)
            {
                var 주문자 = await response.Content.ReadFromJsonAsync<Read주문자DTO>();
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
