using System.Net;
using 창고Common;
using System.Net.Http.Json;
using 창고Common.DTO.창고상품;

namespace WarehouseCommon.APIService
{
    public class 창고상품APIService
    {
        private readonly HttpClient _httpClient;

        public 창고상품APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7187");
        }

        public async Task<List<Read창고상품DTO>> GetAll창고상품()
        {
            var response = await _httpClient.GetAsync("api/창고상품");
            response.EnsureSuccessStatusCode();
            var 창고상품List = await response.Content.ReadFromJsonAsync<List<Read창고상품DTO>>();
            return 창고상품List;
        }

        public async Task<Read창고상품DTO> Get창고상품ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 창고상품 = await response.Content.ReadFromJsonAsync<Read창고상품DTO>();
                return 창고상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("창고상품 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read창고상품DTO> Create창고상품(Create창고상품DTO 창고상품)
        {
            var response = await _httpClient.PostAsJsonAsync("api/창고상품", 창고상품);
            response.EnsureSuccessStatusCode();
            var created창고상품 = await response.Content.ReadFromJsonAsync<Read창고상품DTO>();
            return created창고상품;
        }

        public async Task<Read창고상품DTO> Update창고상품(string id, Update창고상품DTO updated창고상품)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/창고상품/{id}", updated창고상품);
            if (response.IsSuccessStatusCode)
            {
                var 창고상품 = await response.Content.ReadFromJsonAsync<Read창고상품DTO>();
                return 창고상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("창고상품 업데이트 중에 오류가 발생했습니다.");
            }
        }

        public async Task<bool> Delete창고상품(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/창고상품/{id}");
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
                throw new Exception("창고상품 삭제 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read창고상품DTO> Get창고상품ByIdWith입고상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고상품/{id}/with입고상품");
            if (response.IsSuccessStatusCode)
            {
                var 창고상품 = await response.Content.ReadFromJsonAsync<Read창고상품DTO>();
                return 창고상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("입고상품 정보를 함께 조회하는 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read창고상품DTO> Get창고상품ByIdWith적재상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고상품/{id}/with적재상품");
            if (response.IsSuccessStatusCode)
            {
                var 창고상품 = await response.Content.ReadFromJsonAsync<Read창고상품DTO>();
                return 창고상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("적재상품 정보를 함께 조회하는 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read창고상품DTO> Get창고상품ByIdWith출고상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고상품/{id}/with출고상품");
            if (response.IsSuccessStatusCode)
            {
                var 창고상품 = await response.Content.ReadFromJsonAsync<Read창고상품DTO>();
                return 창고상품;
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

        public async Task<List<Read창고상품DTO>> Get창고상품ListBy창고Id(string 창고Id)
        {
            var response = await _httpClient.GetAsync($"api/창고상품/창고Id/{창고Id}");
            response.EnsureSuccessStatusCode();
            var 창고상품List = await response.Content.ReadFromJsonAsync<List<Read창고상품DTO>>();
            return 창고상품List;
        }
    }
}
