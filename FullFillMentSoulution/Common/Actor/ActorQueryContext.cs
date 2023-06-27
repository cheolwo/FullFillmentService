using Common.Actor.Builder;
using Common.Actor.Builder.TypeBuilder;
using FrontCommon.Actor;
using System.Data.Common;
using System.Linq.Expressions;

namespace Common.Actor
{
    public class SortOption<TDto>
    {
        public Expression<Func<TDto>> KeySelector { get; set; }
        public SortDirection Direction { get; set; }
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
    public class ActorQueryContext : ActorContext
    {
        protected readonly DtoQueryBuilder dtoQueryBuilder = new();
        protected ActorQueryContext(ActorContextOptions options)
            : base(options)
        {
            OnModelCreating(dtoQueryBuilder);
        }
        protected virtual void OnModelCreating(DtoQueryBuilder dtoBuilder)
        {
        }
        public DtoTypeQueryBuilder<TDto> Set<TDto>() where TDto : class
        {
            return dtoQueryBuilder.Set<TDto>();
        }
    }
}
