using Common.Actor;
using Common.ViewService;
using FrontCommon.Actor;

namespace Common.ViewModel
{
    public class WebViewModel : BaseViewModel
    {
        protected readonly ITokenStorage _tokenStorage;
        public WebViewModel(ActorCommandContext commandContext, ActorQueryContext queryContext, ITokenStorage tokenStoage) : base(commandContext, queryContext)
        {
            _tokenStorage = tokenStoage;
        }
    }
}
