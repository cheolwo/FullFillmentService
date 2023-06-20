using Common.Actor.Builder;
using FrontCommon.Actor;
using 주문Common.Actor.Config;

namespace 주문FrontCommon.Actor
{
    public class 주문자ActorCommandContext : ActorCommandContext
    {
        public 주문자ActorCommandContext(ActorContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(DtoCommandBuilder dtoBuilder)
        {
            base.OnModelCreating(dtoBuilder);
            dtoBuilder.ApplyConfiguration(new Create주문DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update주문DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete주문DtoConfiguration());
        }
    }
}
