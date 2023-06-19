using Common.APIService;
using System.Net.Http.Json;
using 주문Common.DTO.판매자;
using 주문Common.Model;

namespace OrderCommon.Services.API
{
    public class 판매자APICommandService : EntityCommandAPIService<판매자, Cud판매자DTO>
    {
        public 판매자APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 판매자APIQueryService : EntityQueryAPIService<판매자, Read판매자DTO>
    {
        public 판매자APIQueryService(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<Read판매자DTO> Get판매자ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith판매자상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWith판매자상품/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith주문(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWith주문/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWithRelatedData(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWithRelatedData/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<List<Read판매자DTO>> GetAll판매자With판매자상품()
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetAllWith판매자상품");
            response.EnsureSuccessStatusCode();
            var 판매자DTOs = await response.Content.ReadFromJsonAsync<List<Read판매자DTO>>();
            return 판매자DTOs;
        }

        public async Task<List<Read판매자DTO>> GetAll판매자With주문()
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetAllWith주문");
            response.EnsureSuccessStatusCode();
            var 판매자DTOs = await response.Content.ReadFromJsonAsync<List<Read판매자DTO>>();
            return 판매자DTOs;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith상품문의(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWith상품문의/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith댓글(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWith댓글/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith할일목록(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWith할일목록/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith주문자구매요약(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWith주문자구매요약/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith판매자상품판매정보요약(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWith판매자상품판매정보요약/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith판매자판매정보요약(string id)
        {
            var response = await _httpClient.GetAsync($"api/판매자/GetByIdWith판매자판매정보요약/{id}");
            response.EnsureSuccessStatusCode();
            var 판매자DTO = await response.Content.ReadFromJsonAsync<Read판매자DTO>();
            return 판매자DTO;
        }
    }
}
