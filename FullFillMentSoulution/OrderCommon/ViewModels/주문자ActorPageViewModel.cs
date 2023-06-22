using Common.Actor;
using Common.ViewModel;
using FrontCommon.Actor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using 주문Common.DTO.For주문;

namespace 주문Common.ViewModels
{
    public class 주문자ActorPageViewModel : ActorWebPageViewModel
    {
        public 주문자ActorPageViewModel(ActorCommandContext actorCommandContext, 
            ActorQueryContext actorQueryContext, 
            IJSRuntime jsRuntime, 
            IConfiguration configuration, 
            ILogger<ActorWebPageViewModel> logger) : base(actorCommandContext, actorQueryContext, jsRuntime, configuration, logger)
        {
        }
        public async Task 주문(Create주문DTO dto)
        {
            await _actorCommandContext.Set<Create주문DTO>().PostAsync(dto);   
        }
    }
}
