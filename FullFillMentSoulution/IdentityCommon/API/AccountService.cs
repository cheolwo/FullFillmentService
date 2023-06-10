using IdentityCommon.Models;
using IdentityCommon.Models.ForApplicationUser;
using System.Net.Http.Json;

namespace IdentityCommon.Services
{
    public interface IAccountService
    {
        Task<List<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserAsync(string id);
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user);
        Task UpdateUserAsync(string id, ApplicationUser user);
        Task DeleteUserAsync(string id);
    }
    public class AccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:5001");
        }
        public async Task<List<ApplicationUser>?> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<ApplicationUser>>("/api/account");
        }

        public async Task<ApplicationUser?> GetUserById(string id)
        {
            return await _httpClient.GetFromJsonAsync<ApplicationUser>($"/api/account/{id}");
        }

        public async Task<HttpResponseMessage> CreateUser(ApplicationUser user)
        {
            return await _httpClient.PostAsJsonAsync("/api/account", user);
        }

        public async Task<HttpResponseMessage> UpdateUser(string id, ApplicationUser user)
        {
            return await _httpClient.PutAsJsonAsync($"/api/account/{id}", user);
        }

        public async Task<HttpResponseMessage> DeleteUser(string id)
        {
            return await _httpClient.DeleteAsync($"/api/account/{id}");
        }

        public async Task<HttpResponseMessage> RegisterUser(RegisterUserModel model)
        {
            return await _httpClient.PostAsJsonAsync("/api/account/register", model);
        }
        public async Task<HttpResponseMessage> Login(string returnUrl)
        {
            var response = await _httpClient.GetAsync($"/account/login?returnUrl={returnUrl}");
            response.EnsureSuccessStatusCode();
            return response;
        }

        //public async Task<HttpResponseMessage> Login(LoginInputModel model)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("/account/login", model);
        //    response.EnsureSuccessStatusCode();
        //    return response;
        //}

        public async Task<HttpResponseMessage> Logout(string logoutId)
        {
            var response = await _httpClient.GetAsync($"/account/logout?logoutId={logoutId}");
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}