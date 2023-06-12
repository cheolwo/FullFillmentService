using Newtonsoft.Json;
using System.Text;
using 계정Common.API;
using 주문Common.DTO.판매자판매정보요약;

namespace 주문Common.APIService
{
    public class 판매자판매정보요약APIService : JwtTokenAPIService
    {
        public 판매자판매정보요약APIService(HttpClient httpClient) 
            : base(httpClient)
        {
        }
        public async Task<HttpResponseMessage> Create판매자판매정보요약Async(Create판매자판매정보요약DTO 판매자판매정보요약DTO)
        {
            ReadyBearerToken();

            var json = JsonConvert.SerializeObject(판매자판매정보요약DTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/판매자판매정보요약", content);

            return response;
        }

        public async Task<HttpResponseMessage> Update판매자판매정보요약Async(string id, Update판매자판매정보요약DTO updated판매자판매정보요약DTO)
        {
            ReadyBearerToken();

            var json = JsonConvert.SerializeObject(updated판매자판매정보요약DTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/판매자판매정보요약/{id}", content);

            return response;
        }

        public async Task<HttpResponseMessage> Delete판매자판매정보요약Async(string id)
        {
            ReadyBearerToken();

            var response = await _httpClient.DeleteAsync($"api/판매자판매정보요약/{id}");

            return response;
        }

        public async Task<Read판매자판매정보요약DTO> Get판매자판매정보요약ByIdAsync(string id)
        {
            ReadyBearerToken();

            var response = await _httpClient.GetAsync($"api/판매자판매정보요약/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var 판매자판매정보요약DTO = JsonConvert.DeserializeObject<Read판매자판매정보요약DTO>(content);

            return 판매자판매정보요약DTO;
        }

        public async Task<List<Read판매자판매정보요약DTO>> Get판매자판매정보요약By판매자IdAsync(string 판매자Id)
        {
            ReadyBearerToken();

            var response = await _httpClient.GetAsync($"api/판매자판매정보요약/GetBy판매자Id/{판매자Id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var 정보요약DTOs = JsonConvert.DeserializeObject<List<Read판매자판매정보요약DTO>>(content);

            return 정보요약DTOs;
        }
    }
}
