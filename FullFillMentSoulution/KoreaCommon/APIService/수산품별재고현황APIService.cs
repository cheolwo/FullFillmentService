using KoreaCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KoreaCommon.Services
{
    public class 수산품별재고현황APIService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7156/api/수산품별재고현황";

        public 수산품별재고현황APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<수산품별재고현황>> GetAll수산품별재고현황Async()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var 수산품별재고현황List = await response.Content.ReadFromJsonAsync<List<수산품별재고현황>>();
            return 수산품별재고현황List;
        }

        public async Task<List<수산품별재고현황>> Get수산품별재고현황By창고번호Async(string 창고번호)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/by창고번호/{창고번호}");
            response.EnsureSuccessStatusCode();

            var 수산품별재고현황List = await response.Content.ReadFromJsonAsync<List<수산품별재고현황>>();
            return 수산품별재고현황List;
        }

        public async Task<수산품별재고현황> Get수산품별재고현황ByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var 수산품별재고현황 = await response.Content.ReadFromJsonAsync<수산품별재고현황>();
            return 수산품별재고현황;
        }

        public async Task<수산품별재고현황> Create수산품별재고현황Async(수산품별재고현황 수산품별재고현황)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, 수산품별재고현황);
            response.EnsureSuccessStatusCode();

            var created수산품별재고현황 = await response.Content.ReadFromJsonAsync<수산품별재고현황>();
            return created수산품별재고현황;
        }

        public async Task Update수산품별재고현황Async(string id, 수산품별재고현황 updated수산품별재고현황)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", updated수산품별재고현황);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete수산품별재고현황Async(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}