using Common.Actor.Builder;
using FrontCommon.Actor;
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
    }
}
