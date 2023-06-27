using Common.Actor;
using Common.DTO;
using CommunityToolkit.Mvvm.ComponentModel;
using FrontCommon.Actor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Common.ViewModel
{
    public abstract class BaseViewModel : ObservableObject
    {
        protected readonly ILogger _logger;

        public BaseViewModel(ILogger<BaseViewModel> logger)
        {
            _logger = logger;
        }
    }
    public abstract class WebViewModel : BaseViewModel
    {
        protected readonly IConfiguration _configuration;
        protected readonly IJSRuntime _jsRuntime;

        public WebViewModel(ILogger<WebViewModel> logger, IConfiguration configuration, IJSRuntime jsRuntime)
            : base(logger)
        {
            _configuration = configuration;
            _jsRuntime = jsRuntime;
        }
    }
    public class ActorWebPageViewModel : WebViewModel
    {
        protected readonly ActorCommandContext _actorCommandContext;
        protected readonly ActorQueryContext _actorQueryContext;
        public ActorWebPageViewModel(ActorCommandContext actorCommandContext, ActorQueryContext actorQueryContext, IJSRuntime jsRuntime, IConfiguration configuration, ILogger<ActorWebPageViewModel> logger)
            : base(logger, configuration, jsRuntime)
        {
            _actorCommandContext = actorCommandContext;
            _actorQueryContext = actorQueryContext;
        }
        public virtual async Task Login(LoginModel loginModel)
        {
            var response = await _actorCommandContext.Set<LoginModel>().PostAsync(loginModel);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(token))
                {
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", token);
                }
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"서버 응답: {errorMessage}");
            }
        }
        public virtual async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
        }
        public async Task Logout()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "token");
        }
        public async Task Delete<T>(string id) where T : class
        {
            var token = await GetTokenAsync();
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            await _actorCommandContext.Set<T>().DeleteAsync(id, token);
        }
        public async Task<List<T>?> GetToListAsync<T>() where T : class
        {
            var token = await GetTokenAsync();
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            return await _actorQueryContext.Set<T>().GetToListAsync(token);
        }
        public async Task Post<T>(T t, string jwtToken) where T : class
        {
            var token = await GetTokenAsync();
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            await _actorCommandContext.Set<T>().PostAsync(t, token);
        }
        public async Task Update<T>(T t, string jwtToken) where T : class
        {
            var token = await GetTokenAsync();
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            await _actorCommandContext.Set<T>().PutAsync(t, token);
        }
    }
}
