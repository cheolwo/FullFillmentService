using Common.Actor;
using CommunityToolkit.Mvvm.ComponentModel;
using FrontCommon.Actor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Common.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        protected readonly ILogger _logger;

        public BaseViewModel(ILogger<BaseViewModel> logger)
        {
            _logger = logger;
        }
    }
    public class WebViewModel : BaseViewModel
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
    public class ActorPageViewModel : WebViewModel
    {
        protected readonly ActorCommandContext _actorCommandContext;
        protected readonly ActorQueryContext _actorQueryContext;
        public ActorPageViewModel(ActorCommandContext actorCommandContext, ActorQueryContext actorQueryContext, IJSRuntime jsRuntime, IConfiguration configuration, ILogger<ActorPageViewModel> logger)
            : base(logger, configuration, jsRuntime)
        {
            _actorCommandContext = actorCommandContext;
            _actorQueryContext = actorQueryContext;
        }
    }
}
