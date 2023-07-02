using Common.Actor.Builder;
using FrontCommon.Actor;
using 창고Common.Actor.Configuration;

namespace 창고FrontCommon.Actor
{
    public class 창고관리자ActorCommandContext : ActorCommandContext
    {
        protected 창고관리자ActorCommandContext(ActorContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(DtoCommandBuilder dtoBuilder)
        {
            dtoBuilder.ApplyConfiguration(new Create입고상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update입고상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete입고상품DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create적재상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update적재상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete적재상품DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create출고상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update출고상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete출고상품DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create창고상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update창고상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete창고상품DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create창고DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update창고DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete창고DtoConfiguration());
        }
    }
}
