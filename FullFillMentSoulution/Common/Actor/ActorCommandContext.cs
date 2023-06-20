using Common.Actor.Builder;

namespace FrontCommon.Actor
{
    public class ActorCommandContext : ActorContext
    {
        protected readonly DtoCommandBuilder dtoCommandBuilder = new();
        protected ActorCommandContext(ActorContextOptions options)
            :base(options)
        {
            OnModelCreating(dtoCommandBuilder);
        }

        protected virtual void OnModelCreating(DtoCommandBuilder dtoBuilder) 
        {

        }
        protected DtoTypeCommandBuilder<TDto> Set<TDto>() where TDto : class
        {
            return dtoCommandBuilder.Set<TDto>();
        }
    }
}
