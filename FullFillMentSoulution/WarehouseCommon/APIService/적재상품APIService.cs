using System.Net.Http.Json;
using System.Net;
using 창고Common.DTO.적재상품;

namespace WarehouseCommon.APIService
{
    public class 적재상품APIService
    {
        private readonly HttpClient _httpClient;

        public 적재상품APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7187");
        }

        public async Task<List<Read적재상품DTO>> GetAll적재상품()
        {
            var response = await _httpClient.GetAsync("api/적재상품");
            response.EnsureSuccessStatusCode();
            var 적재상품List = await response.Content.ReadFromJsonAsync<List<Read적재상품DTO>>();
            return 적재상품List;
        }


        public async Task<Read적재상품DTO> Get적재상품ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/적재상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 적재상품 = await response.Content.ReadFromJsonAsync<Read적재상품DTO>();
                return 적재상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("적재상품 조회 중에 오류가 발생했습니다.");
            }
        }


        public async Task<Read적재상품DTO> Create적재상품(Create적재상품DTO 적재상품)
        {
            var response = await _httpClient.PostAsJsonAsync("api/적재상품", 적재상품);
            response.EnsureSuccessStatusCode();
            var created적재상품 = await response.Content.ReadFromJsonAsync<Read적재상품DTO>();
            return created적재상품;
        }


        public async Task Update적재상품(string id, Update적재상품DTO updated적재상품)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/적재상품/{id}", updated적재상품);
            response.EnsureSuccessStatusCode();
        }


        public async Task Delete적재상품(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/적재상품/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Read적재상품DTO> Get적재상품ByIdWith출고상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/적재상품/{id}/with출고상품");
            if (response.IsSuccessStatusCode)
            {
                var 적재상품 = await response.Content.ReadFromJsonAsync<Read적재상품DTO>();
                return 적재상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("출고상품 정보를 함께 조회하는 중에 오류가 발생했습니다.");
            }
        }


        public async Task<List<Read적재상품DTO>> Get적재상품By창고Id(string 창고Id)
        {
            var response = await _httpClient.GetAsync($"api/적재상품/창고/{창고Id}");
            response.EnsureSuccessStatusCode();
            var 적재상품List = await response.Content.ReadFromJsonAsync<List<Read적재상품DTO>>();
            return 적재상품List;
        }


        public async Task<List<Read적재상품DTO>> Get적재상품By창고상품Id(string 창고상품Id)
        {
            var response = await _httpClient.GetAsync($"api/적재상품/창고상품/{창고상품Id}");
            response.EnsureSuccessStatusCode();
            var 적재상품List = await response.Content.ReadFromJsonAsync<List<Read적재상품DTO>>();
            return 적재상품List;
        }


        public async Task<List<Read적재상품DTO>> Get적재상품By입고상품Id(string 입고상품Id)
        {
            var response = await _httpClient.GetAsync($"api/적재상품/입고상품/{입고상품Id}");
            response.EnsureSuccessStatusCode();
            var 적재상품List = await response.Content.ReadFromJsonAsync<List<Read적재상품DTO>>();
            return 적재상품List;
        }
    }
}
