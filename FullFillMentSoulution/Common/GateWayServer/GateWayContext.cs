using Common.DTO;
using Common.Model;
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
    public class GateWayQueryBuilder
    {
        protected readonly Dictionary<Type, object> _configurations;
        public GateWayQueryBuilder()
        {
            _configurations = new Dictionary<Type, object>();
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


    public interface IGateWayCommandConfiguration<T> where T : class
    {
        void Configure(GateWayCommandTypeBuilder<T> builder);
    }
    public interface IGateWayQueryConfiguration<T> where T : class
    {
        void Configure(GateWayQueryTypeBuilder<T> builder);
    }
    public abstract class GateWayContext
    {
        protected readonly GateWayCommandBuilder commandBuilder;
        protected readonly IConfiguration _configuration;
        protected readonly GateWayCommandContextOptions _options;
        public GateWayContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration, GateWayCommandContextOptions options)
        {
            this.commandBuilder = commandBuilder;
            _configuration = configuration;
            _options = options;
        }
    }
    public abstract class GateWayCommandContext : GateWayContext
    {
        protected GateWayCommandContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration, 
            GateWayCommandContextOptions options) : base(commandBuilder, configuration, options)
        {
        }

        protected abstract void OnModelCreating(GateWayCommandBuilder commandBuilder);
        public abstract GateWayCommandTypeBuilder<TDto> Set<TDto>() where TDto : class;
    }
    public abstract class GateWayQueryContext : GateWayContext
    {
        protected GateWayQueryContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration, 
            GateWayCommandContextOptions options) : base(commandBuilder, configuration, options)
        {
        }
        protected abstract void OnModelCreating(GateWayCommandBuilder commandBuilder);
        public abstract GateWayQueryTypeBuilder<TDto> Set<TDto>() where TDto : class;
    }
}