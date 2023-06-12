]using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 계정Common.API;
using 주문Common.DTO.할일목록;

namespace 주문Common.APIService
{
    public class 할일목록APIService : JwtTokenAPIService
    {
        public 할일목록APIService(HttpClient httpClient) 
            : base(httpClient)
        {
        }
        public async Task<HttpResponseMessage> Create할일목록Async(Create할일목록DTO 할일목록DTO)
        {
            ReadyBearerToken();

            var json = JsonConvert.SerializeObject(할일목록DTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/할일목록", content);

            return response;
        }

        public async Task<HttpResponseMessage> Update할일목록Async(string id, Update할일목록DTO updated할일목록DTO)
        {
            ReadyBearerToken();

            var json = JsonConvert.SerializeObject(updated할일목록DTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/할일목록/{id}", content);

            return response;
        }

        public async Task<HttpResponseMessage> Delete할일목록Async(string id)
        {
            ReadyBearerToken();

            var response = await _httpClient.DeleteAsync($"api/할일목록/{id}");

            return response;
        }

        public async Task<Read할일목록DTO> Get할일목록ByIdAsync(string id)
        {
            ReadyBearerToken();

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
            ReadyBearerToken();

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
            ReadyBearerToken();

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
            ReadyBearerToken();

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
            ReadyBearerToken();

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
