
using Common.APIService;
using Newtonsoft.Json;
using System.Text;

using 주문Common.DTO.할일목록;
using 주문Common.Model;

namespace 주문Common.APIService
{
    public class 할일목록APICommandService : EntityCommandAPIService<할일목록, Cud할일목록DTO>
    {
        public 할일목록APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 할일목록APIService : EntityQueryAPIService<할일목록, Read할일목록DTO>
    {
        public 할일목록APIService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public async Task<Read할일목록DTO> Get할일목록ByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/할일목록/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var 할일목록DTO = JsonConvert.DeserializeObject<Read할일목록DTO>(content);

            return 할일목록DTO;
        }

        public async Task<List<Read할일목록DTO>> Get할일목록By판매자IdAnd주문IdAsync(string 판매자Id, string 주문Id)
        {
            var response = await _httpClient.GetAsync($"api/할일목록/GetBy판매자IdAnd주문Id/{판매자Id}/{주문Id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var 할일목록DTOs = JsonConvert.DeserializeObject<List<Read할일목록DTO>>(content);

            return 할일목록DTOs;
        }

        public async Task<List<Read할일목록DTO>> Get할일목록By판매자IdWithPriorityDescendingAsync(string 판매자Id)
        {
            var response = await _httpClient.GetAsync($"api/할일목록/GetBy판매자IdWithPriorityDescending/{판매자Id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var 할일목록DTOs = JsonConvert.DeserializeObject<List<Read할일목록DTO>>(content);

            return 할일목록DTOs;
        }

        public async Task<List<Read할일목록DTO>> Get할일목록By주문IdAndStatusAsync(string 주문Id, string 상태)
        {
            var response = await _httpClient.GetAsync($"api/할일목록/GetBy주문IdAndStatus/{주문Id}/{상태}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var 할일목록DTOs = JsonConvert.DeserializeObject<List<Read할일목록DTO>>(content);

            return 할일목록DTOs;
        }

        public async Task<List<Read할일목록DTO>> Get할일목록By판매자IdAndStatusAsync(string 판매자Id, string 상태)
        {

            var response = await _httpClient.GetAsync($"api/할일목록/GetBy판매자IdAndStatus/{판매자Id}/{상태}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var 할일목록DTOs = JsonConvert.DeserializeObject<List<Read할일목록DTO>>(content);

            return 할일목록DTOs;
        }
    }
}
