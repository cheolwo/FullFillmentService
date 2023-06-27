using Common.Actor;
using Common.Actor.Builder;
using FrontCommon.Actor;
using Microsoft.Extensions.Configuration;

namespace 판매Common.Actor
{
    public class 판매자CommandContext : ActorCommandContext
    {
        private readonly IConfiguration _configuration;
        public 판매자CommandContext(IConfiguration configuration, ActorContextOptions options) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(DtoCommandBuilder dtoBuilder)
        {
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
