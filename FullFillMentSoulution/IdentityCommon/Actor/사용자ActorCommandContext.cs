using Common.Actor.Builder;
using Common.DTO;
using FrontCommon.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 계정Common.Actor
{
    public class 사용자ActorCommandContext : ActorCommandContext
    {
        protected 사용자ActorCommandContext(ActorContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(DtoCommandBuilder dtoBuilder)
        {
            base.OnModelCreating(dtoBuilder);
        }
    }
}
