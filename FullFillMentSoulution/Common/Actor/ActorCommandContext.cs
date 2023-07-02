using Common.Actor.Builder;
using FluentValidation.Results;

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
        public DtoTypeCommandBuilder<TDto> Set<TDto>() where TDto : class
        {
            return dtoCommandBuilder.Set<TDto>();
        }
        public bool IsWeb()
        {
            return _options.IsWeb;
        }
    }
}
