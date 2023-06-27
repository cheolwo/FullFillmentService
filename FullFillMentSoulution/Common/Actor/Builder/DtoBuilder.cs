using FrontCommon.Actor;

namespace Common.Actor.Builder
{
    public class DtoBuilder : IDisposable
    {
        protected readonly Dictionary<Type, object> _configurations;

        public DtoBuilder()
        {
            _configurations = new Dictionary<Type, object>();
        }
        public virtual void Dispose()
        {
            foreach (var configuration in _configurations.Values)
            {
                if (configuration is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            _configurations.Clear();
        }
    }
}
