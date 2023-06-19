using Common.APIService;
using Newtonsoft.Json;
using System.Text;

using 주문Common.DTO.판매자판매정보요약;
using 주문Common.Model;

namespace 주문Common.APIService
{
    public class 판매자판매정보요약APICommandService : EntityCommandAPIService<판매자판매정보요약, Cud판매자판매정보요약DTO>
    {
        public 판매자판매정보요약APICommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
    public class 판매자판매정보요약APIQueryService : EntityQueryAPIService<판매자판매정보요약, Read판매자판매정보요약DTO>
    {
        public 판매자판매정보요약APIQueryService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public async Task<Read판매자판매정보요약DTO> Get판매자판매정보요약ByIdAsync(string id)
        {
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
