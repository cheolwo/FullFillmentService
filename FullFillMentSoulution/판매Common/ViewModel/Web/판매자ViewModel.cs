using Common.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using 판매Common.Actor;

namespace 판매Common.ViewModel.Web
{
    public class 판매자WebViewModel : ActorWebPageViewModel
    {
        public 판매자WebViewModel(판매자CommandContext actorCommandContext, 판매자QueryContext actorQueryContext, 
            IJSRuntime jsRuntime, IConfiguration configuration, ILogger<ActorWebPageViewModel> logger) 
            : base(actorCommandContext, actorQueryContext, jsRuntime, configuration, logger)
        {
        }
    }
    public class 판매자ViewModel : 판매자WebViewModel
    {
        public 판매자ViewModel(판매자CommandContext actorCommandContext, 판매자QueryContext actorQueryContext, 
            IJSRuntime jsRuntime, IConfiguration configuration, ILogger<ActorWebPageViewModel> logger) 
            : base(actorCommandContext, actorQueryContext, jsRuntime, configuration, logger)
        {
        }
    }
    public class 판매상품ViewModel : 판매자WebViewModel
    {
        public 판매상품ViewModel(판매자CommandContext actorCommandContext, 판매자QueryContext actorQueryContext, 
            IJSRuntime jsRuntime, IConfiguration configuration, ILogger<ActorWebPageViewModel> logger) 
            : base(actorCommandContext, actorQueryContext, jsRuntime, configuration, logger)
        {
        }
    }
    public class 판매대기ViewModel : 판매자WebViewModel
    {
        public 판매대기ViewModel(판매자CommandContext actorCommandContext, 판매자QueryContext actorQueryContext, 
            IJSRuntime jsRuntime, IConfiguration configuration, ILogger<ActorWebPageViewModel> logger) 
            : base(actorCommandContext, actorQueryContext, jsRuntime, configuration, logger)
        {
        }
    }
    public class 판매중ViewModel : 판매자WebViewModel
    {
        public 판매중ViewModel(판매자CommandContext actorCommandContext, 판매자QueryContext actorQueryContext, 
            IJSRuntime jsRuntime, IConfiguration configuration, ILogger<ActorWebPageViewModel> logger) 
            : base(actorCommandContext, actorQueryContext, jsRuntime, configuration, logger)
        {
        }
    }
    public class 판매완료ViewModel : 판매자WebViewModel
    {
        public 판매완료ViewModel(판매자CommandContext actorCommandContext, 판매자QueryContext actorQueryContext, 
            IJSRuntime jsRuntime, IConfiguration configuration, ILogger<ActorWebPageViewModel> logger) 
            : base(actorCommandContext, actorQueryContext, jsRuntime, configuration, logger)
        {
        }
    }
}
