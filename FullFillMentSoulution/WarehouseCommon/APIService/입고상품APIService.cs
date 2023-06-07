using System.Net.Http.Json;
using System.Net;
using 창고Common;

namespace WarehouseCommon.APIService
{
    public class 입고상품APIService
    {
        private readonly HttpClient _httpClient;

        public 입고상품APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7187");
        }

        public async Task<List<입고상품>> GetAll입고상품()
        {
            var response = await _httpClient.GetAsync("api/입고상품");
            response.EnsureSuccessStatusCode();
            var 입고상품List = await response.Content.ReadFromJsonAsync<List<입고상품>>();
            return 입고상품List;
        }

        public async Task<입고상품> Get입고상품ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/입고상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 입고상품 = await response.Content.ReadFromJsonAsync<입고상품>();
                return 입고상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("입고상품 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<입고상품> Create입고상품(입고상품 입고상품)
        {
            var response = await _httpClient.PostAsJsonAsync("api/입고상품", 입고상품);
            response.EnsureSuccessStatusCode();
            var created입고상품 = await response.Content.ReadFromJsonAsync<입고상품>();
            return created입고상품;
        }

        public async Task Update입고상품(string id, 입고상품 updated입고상품)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/입고상품/{id}", updated입고상품);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete입고상품(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/입고상품/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<입고상품>> Get입고상품By창고Id(string 창고Id)
        {
            var response = await _httpClient.GetAsync($"api/입고상품/창고/{창고Id}");
            response.EnsureSuccessStatusCode();
            var 입고상품List = await response.Content.ReadFromJsonAsync<List<입고상품>>();
            return 입고상품List;
        }

        public async Task<List<입고상품>> Get입고상품By창고상품Id(string 창고상품Id)
        {
            var response = await _httpClient.GetAsync($"api/입고상품/창고상품/{창고상품Id}");
            response.EnsureSuccessStatusCode();
            var 입고상품List = await response.Content.ReadFromJsonAsync<List<입고상품>>();
            return 입고상품List;
        }
    }
}
