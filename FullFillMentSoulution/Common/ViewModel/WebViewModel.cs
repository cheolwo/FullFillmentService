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
        public virtual async Task<string> GetToken()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
        }
        public async Task Logout()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "token");
        }
    }
}
