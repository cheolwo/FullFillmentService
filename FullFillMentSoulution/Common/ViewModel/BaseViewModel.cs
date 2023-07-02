using Common.Actor;
using CommunityToolkit.Mvvm.ComponentModel;
using FrontCommon.Actor;

namespace Common.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        protected readonly ActorCommandContext _actorCommandContext;
        protected readonly ActorQueryContext _actorQueryContext;
        public BaseViewModel(ActorCommandContext commandContext, ActorQueryContext queryContext)
        {
            _actorCommandContext = commandContext;
            _actorQueryContext = queryContext;
        }
    }
}
