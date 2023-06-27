using Common.DTO;
using Microsoft.Extensions.Configuration;

namespace Common.GateWay
{
    public class GateWayCommandContextOptions
    {

    }
    public class GateWayCommandBuilder
    {
        protected readonly Dictionary<Type, object> _configurations;

        public GateWayCommandBuilder()
        {
            _configurations = new Dictionary<Type, object>();
        }

        public void ApplyConfiguration<TDto>(IGateWayCommandConfiguration<TDto> configuration) where TDto : CudDTO
        {
            _configurations[typeof(TDto)] = configuration;
        }

        public GateWayCommandTypeBuilder<TDto> Set<TDto>() where TDto : CudDTO
        {
            if (_configurations.TryGetValue(typeof(TDto), out var configuration))
            {
                return new GateWayCommandTypeBuilder<TDto>((IGateWayCommandConfiguration<TDto>)configuration);
            }
            else
            {
                return new GateWayCommandTypeBuilder<TDto>(null);
            }
        }
        public IQueForGateWayServer SetFromGateWay<TDto>() where TDto : CudDTO
        {
            if (_configurations.TryGetValue(typeof(TDto), out var configuration))
            {
                return new GateWayCommandTypeBuilder<TDto>((IGateWayCommandConfiguration<TDto>)configuration);
            }
            else
            {
                return new GateWayCommandTypeBuilder<TDto>(null);
            }
        }
        public IQueForBusinessServer SetFromBusinessServer<TDto>() where TDto : CudDTO
        {
            if (_configurations.TryGetValue(typeof(TDto), out var configuration))
            {
                return new GateWayCommandTypeBuilder<TDto>((IGateWayCommandConfiguration<TDto>)configuration);
            }
            else
            {
                return new GateWayCommandTypeBuilder<TDto>(null);
            }
        }
    }
    public interface IQueForGateWayServer
    {
        Task<string> Enqueue(byte[] message, string queName);
    }
    public interface IQueForBusinessServer
    {
        Task<string> Dequeue(string queName);
    }


    public interface IGateWayCommandConfiguration<T> where T : CudDTO
    {
        void Configure(GateWayCommandTypeBuilder<T> builder);
    }

    public abstract class GateWayCommandContext
    {
        protected readonly GateWayCommandBuilder commandBuilder;
        protected readonly IConfiguration _configuration;
        protected readonly GateWayCommandContextOptions _options;
        public GateWayCommandContext(
               IConfiguration configuration,
            GateWayCommandContextOptions options)
        {
            commandBuilder = new GateWayCommandBuilder();
            OnModelCreating(commandBuilder);
            _options = options;
            _configuration = configuration;
        }

        protected abstract void OnModelCreating(GateWayCommandBuilder commandBuilder);
        public GateWayCommandTypeBuilder<TDto> Set<TDto>() where TDto : CudDTO
        {
            return commandBuilder.Set<TDto>();
        }
    }
}