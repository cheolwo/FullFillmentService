using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using 주문Common.Model;

namespace OrderClient.Services
{
    public class 판매자APIService
    {
        private readonly HttpClient _httpClient;

        public 판매자APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7007");
        }

        public async Task<List<판매자>> GetAll판매자()
        {
            var response = await _httpClient.GetAsync("api/판매자");
            response.EnsureSuccessStatusCode();
            var 판매자List = await response.Content.ReadFromJsonAsync<List<판매자>>();
            return 판매자List;
        }

        public async Task<판매자> Get판매자ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/{id}");
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

        public async Task<List<판매자상품>> Get판매자상품들By판매자Id(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/{id}/판매자상품들");
            if (response.IsSuccessStatusCode)
            {
                var 판매자상품들 = await response.Content.ReadFromJsonAsync<List<판매자상품>>();
                return 판매자상품들;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("판매자의 판매자상품들 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<List<주문>> Get주문된것들By판매자Id(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/{id}/주문된것들");
            if (response.IsSuccessStatusCode)
            {
                var 주문된것들 = await response.Content.ReadFromJsonAsync<List<주문>>();
                return 주문된것들;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("판매자의 주문된것들 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<판매자> Create판매자(판매자 판매자)
        {
            var response = await _httpClient.PostAsJsonAsync("api/판매자", 판매자);
            response.EnsureSuccessStatusCode();
            var created판매자 = await response.Content.ReadFromJsonAsync<판매자>();
            return created판매자;
        }

        public async Task<판매자> Update판매자(string id, 판매자 updated판매자)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/판매자/{id}", updated판매자);
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
                throw new Exception("판매자 업데이트 중에 오류가 발생했습니다.");
            }
        }

        public async Task<bool> Delete판매자(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/판매자/{id}");
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
                throw new Exception("판매자 삭제 중에 오류가 발생했습니다.");
            }
        }
    }
}
