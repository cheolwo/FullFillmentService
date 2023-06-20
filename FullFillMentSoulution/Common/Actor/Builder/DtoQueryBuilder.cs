using Common.Actor.Builder.TypeBuilder;
using FrontCommon.Actor;

namespace Common.Actor.Builder
{
    public class DtoQueryBuilder : DtoBuilder
    {
        public void ApplyConfiguration<TDto>(IDtoConfiguration<TDto> configuration) where TDto : class
        {
            _configurations[typeof(TDto)] = configuration;
        }

        public DtoTypeQueryBuilder<TDto> Set<TDto>() where TDto : class
        {
            return new DtoTypeQueryBuilder<TDto>(_configurations.ContainsKey(typeof(TDto)) ? (IDtoTypeQueryConfiguration<TDto>)_configurations[typeof(TDto)] : null);
        }
    }
}
