using FrontCommon.Actor;

namespace Common.Actor.Builder
{
    public class DtoCommandBuilder : DtoBuilder
    {
        public void ApplyConfiguration<TDto>(IDtoTypeCommandConfiguration<TDto> configuration) where TDto : class
        {
            _configurations[typeof(TDto)] = configuration;
        }
        public DtoTypeCommandBuilder<TDto> Set<TDto>() where TDto : class
        {
            return new DtoTypeCommandBuilder<TDto>(_configurations.ContainsKey(typeof(TDto)) ? (IDtoTypeCommandConfiguration<TDto>)_configurations[typeof(TDto)] : null);
        }
    }
}
