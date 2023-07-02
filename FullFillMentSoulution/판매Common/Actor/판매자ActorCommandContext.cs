using Common.Actor;
using Common.Actor.Builder;
using FrontCommon.Actor;
using 판매Common.Actor.Config04;

namespace 판매Common.Actor
{
    public class 판매자ActorCommandContext : ActorCommandContext
    {
        public 판매자ActorCommandContext(ActorContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(DtoCommandBuilder dtoBuilder)
        {
            dtoBuilder.ApplyConfiguration(new Create판매자상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update판매자상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete판매자상품DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create판매자DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update판매자DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete판매자DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create판매대기DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update판매대기DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete판매대기DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create판매중DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update판매중DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete판매중DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create판매완료DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update판매완료DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete판매완료DtoConfiguration());
        }
    }

    public class 판매자QueryContext : ActorQueryContext
    {
        protected 판매자QueryContext(ActorContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(DtoQueryBuilder dtoBuilder)
        {
            base.OnModelCreating(dtoBuilder);
        }
    }
}
