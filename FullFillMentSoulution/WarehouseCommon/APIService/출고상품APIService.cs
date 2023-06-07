using System.Net.Http.Json;
using System.Net;
using 창고Common.DTO.출고상품;

namespace WarehouseCommon.APIService
{
    public class 출고상품APIService
    {
        private readonly HttpClient _httpClient;

        public 출고상품APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7187");
        }

        public async Task<List<Read출고상품DTO>> GetAll출고상품()
        {
            var response = await _httpClient.GetAsync("api/출고상품");
            response.EnsureSuccessStatusCode();
            var 출고상품List = await response.Content.ReadFromJsonAsync<List<Read출고상품DTO>>();
            return 출고상품List;
        }

        public async Task<Read출고상품DTO> Get출고상품ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/출고상품/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 출고상품 = await response.Content.ReadFromJsonAsync<Read출고상품DTO>();
                return 출고상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("출고상품 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<Read출고상품DTO> Create출고상품(Create출고상품DTO 출고상품)
        {
            var response = await _httpClient.PostAsJsonAsync("api/출고상품", 출고상품);
            response.EnsureSuccessStatusCode();
            var created출고상품 = await response.Content.ReadFromJsonAsync<Read출고상품DTO>();
            return created출고상품;
        }

        public async Task<Read출고상품DTO> Update출고상품(string id, Update출고상품DTO updated출고상품)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/출고상품/{id}", updated출고상품);
            if (response.IsSuccessStatusCode)
            {
                var 출고상품 = await response.Content.ReadFromJsonAsync<Read출고상품DTO>();
                return 출고상품;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("출고상품 업데이트 중에 오류가 발생했습니다.");
            }
        }

        public async Task<bool> Delete출고상품(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/출고상품/{id}");
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
                throw new Exception("출고상품 삭제 중에 오류가 발생했습니다.");
            }
        }

        public async Task<List<Read출고상품DTO>> Get출고상품ListBy창고Id(string 창고Id)
        {
            var response = await _httpClient.GetAsync($"api/출고상품/창고/{창고Id}");
            response.EnsureSuccessStatusCode();
            var 출고상품List = await response.Content.ReadFromJsonAsync<List<Read출고상품DTO>>();
            return 출고상품List;
        }

        public async Task<List<Read출고상품DTO>> Get출고상품ListBy창고상품Id(string 창고상품Id)
        {
            var response = await _httpClient.GetAsync($"api/출고상품/창고상품/{창고상품Id}");
            response.EnsureSuccessStatusCode();
            var 출고상품List = await response.Content.ReadFromJsonAsync<List<Read출고상품DTO>>();
            return 출고상품List;
        }

        public async Task<List<Read출고상품DTO>> Get출고상품ListBy입고상품Id(string 입고상품Id)
        {
            var response = await _httpClient.GetAsync($"api/출고상품/입고상품/{입고상품Id}");
            response.EnsureSuccessStatusCode();
            var 출고상품List = await response.Content.ReadFromJsonAsync<List<Read출고상품DTO>>();
            return 출고상품List;
        }

        public async Task<List<Read출고상품DTO>> Get출고상품ListBy적재상품Id(string 적재상품Id)
        {
            var response = await _httpClient.GetAsync($"api/출고상품/적재상품/{적재상품Id}");
            response.EnsureSuccessStatusCode();
            var 출고상품List = await response.Content.ReadFromJsonAsync<List<Read출고상품DTO>>();
            return 출고상품List;
        }
    }

}
