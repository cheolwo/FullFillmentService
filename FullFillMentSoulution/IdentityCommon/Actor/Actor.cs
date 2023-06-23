using System.Text.Json;
using System.Text;
using Common.DTO;

namespace 계정Common.Actor
{
    public interface IActorLoginService
    {
        Task<string> Login(LoginModel model);
        Task<string> RefreshToken(string token);
    }
    public class Actor : IActorLoginService
    {
        private readonly HttpClient _httpClient;
        public Actor(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7114");
        }
        public async Task<string> Login(LoginModel model)
        {
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Account/login", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync());
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // 로그인 실패
                // 적절한 처리를 수행하거나 예외 처리
                throw new Exception(response.StatusCode.ToString());
            }
        }
        public async Task<string> RefreshToken(string token)
        {
            var content = new StringContent(token, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Account/refreshToken", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // 토큰 갱신 실패
                // 적절한 처리를 수행하거나 예외 처리
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}