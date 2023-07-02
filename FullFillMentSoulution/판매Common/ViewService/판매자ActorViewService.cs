using Common.ViewService;
using 판매Common.Actor;

namespace 판매Common.ViewService
{
    public class 판매자ActorViewService : ActorViewService
    {
        public 판매자ActorViewService(판매자CommandContext commandContext, 판매자QueryContext queryContext) 
            : base(commandContext, queryContext)
        {
        }
    }
}
