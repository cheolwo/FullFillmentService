using Common.Actor.Builder;
using FrontCommon.Actor;
using 주문Common.Actor.Config;
using 주문Common.Actor.Config04;

namespace 주문FrontCommon.Actor
{
    public class 주문자ActorCommandContext : ActorCommandContext
    {
        public 주문자ActorCommandContext(ActorContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(DtoCommandBuilder bulider)
        {
            bulider.ApplyConfiguration(new Create주문대기DtoConfiguration());
            bulider.ApplyConfiguration(new Update주문대기DtoConfiguration());
            bulider.ApplyConfiguration(new Delete주문대기DtoConfiguration());

            bulider.ApplyConfiguration(new Create주문중DtoConfiguration());
            bulider.ApplyConfiguration(new Update주문중DtoConfiguration());
            bulider.ApplyConfiguration(new Delete주문중DtoConfiguration());

            bulider.ApplyConfiguration(new Create주문완료DtoConfiguration());
            bulider.ApplyConfiguration(new Update주문완료DtoConfiguration());
            bulider.ApplyConfiguration(new Delete주문완료DtoConfiguration());

            bulider.ApplyConfiguration(new Create주문상품DtoConfiguration());
            bulider.ApplyConfiguration(new Update주문상품DtoConfiguration());
            bulider.ApplyConfiguration(new Delete주문상품DtoConfiguration());

            bulider.ApplyConfiguration(new Create주문자DtoConfiguration());
            bulider.ApplyConfiguration(new Update주문자DtoConfiguration());
            bulider.ApplyConfiguration(new Delete주문자DtoConfiguration());
        }
    }
}
