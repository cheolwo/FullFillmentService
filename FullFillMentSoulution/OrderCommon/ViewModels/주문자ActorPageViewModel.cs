using Common.Actor;
using Common.ViewModel;
using FrontCommon.Actor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace 주문Common.ViewModels
{
    public class 주문자WebViewModel : ActorWebPageViewModel
    {
        public 주문자WebViewModel(ActorCommandContext actorCommandContext, 
            ActorQueryContext actorQueryContext, 
            IJSRuntime jsRuntime, 
            IConfiguration configuration, 
            ILogger<ActorWebPageViewModel> logger) : base(actorCommandContext, actorQueryContext, jsRuntime, configuration, logger)
        {
        }
    }
}
