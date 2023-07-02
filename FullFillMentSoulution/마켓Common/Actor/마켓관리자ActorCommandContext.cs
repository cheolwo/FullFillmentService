using Common.Actor.Builder;
using FrontCommon.Actor;
using 마켓Common.Actor.Config;

namespace 마켓Common.Actor
{
    public class 마켓관리자ActorCommandContext : ActorCommandContext
    {
        protected 마켓관리자ActorCommandContext(ActorContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(DtoCommandBuilder dtoBuilder)
        {
            dtoBuilder.ApplyConfiguration(new Create마켓상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update마켓상품DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete마켓상품DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create마켓DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update마켓DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete마켓DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create협상대기DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update협상대기DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete협상대기DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create협상중DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update협상중DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete협상중DtoConfiguration());

            dtoBuilder.ApplyConfiguration(new Create협상완료DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Update협상완료DtoConfiguration());
            dtoBuilder.ApplyConfiguration(new Delete협상완료DtoConfiguration());
        }
    }
}
