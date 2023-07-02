using Microsoft.JSInterop;
using Xamarin.Essentials;

namespace Common.ViewService
{
    public interface ITokenStorage
    {
        Task<string> GetToken();
        Task SetToken(string token);
    }

    public class WebTokenStorage : ITokenStorage
    {
        private readonly IJSRuntime _jsRuntime;

        public WebTokenStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<string> GetToken()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
            return token;
        }

        public async Task SetToken(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", token);
        }
    }
    public class MobileTokenStorage : ITokenStorage
{
    private const string TokenKey = "UserToken";

    public Task<string> GetToken()
    {
        string token = Preferences.Get(TokenKey, string.Empty);
        return Task.FromResult(token);
    }

    public Task SetToken(string token)
    {
        Preferences.Set(TokenKey, token);
        return Task.CompletedTask;
    }
}
}
