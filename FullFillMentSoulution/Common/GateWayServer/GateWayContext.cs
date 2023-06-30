using Common.DTO;
using Common.Model;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;

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
        public void ApplyConfiguration<TDto>(IGateWayQueryConfiguration<TDto> configuration) where TDto : ReadDto
        {
            _configurations[typeof(TDto)] = configuration;
        }
        public GateWayQueryTypeBuilder<TDto> Set<TDto>() where TDto : ReadDto
        {
            if (_configurations.TryGetValue(typeof(TDto), out var configuration))
            {
                return new GateWayQueryTypeBuilder<TDto>((IGateWayQueryConfiguration<TDto>)configuration);
            }
            else
            {
                return new GateWayQueryTypeBuilder<TDto>(null);
            }
        }
    }
    public interface IQueForGateWayServer
    {
        Task<string?> Enqueue(byte[] message, string queName);
    }
    public interface IQueForBusinessServer
    {
        Task<string?> Dequeue(string queName);
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
        public GateWayContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration)
        {
            this.commandBuilder = commandBuilder;
            _configuration = configuration;
        }
    }
    public abstract class GateWayCommandContext 
    {
        protected readonly GateWayCommandBuilder _commandBuilder;
        protected readonly IConfiguration _configuration;
        private readonly string _connectionString;
        protected GateWayCommandContext(GateWayCommandBuilder commandBuilder, IConfiguration configuration)
        {
            _commandBuilder = commandBuilder;
            _configuration = configuration;
            _connectionString = _configuration.GetSection("RabbitMqConnectionString")?.Value ?? throw new ArgumentNullException(_connectionString);
        }
        protected abstract void OnModelCreating(GateWayCommandBuilder commandBuilder);
        public virtual GateWayCommandTypeBuilder<TDto> Set<TDto>() where TDto : CudDTO
        {
            return _commandBuilder.Set<TDto>();
        }
    }
    public abstract class GateWayQueryContext 
    {
        protected readonly GateWayQueryBuilder _gateWayQueryBuilder;
        protected readonly IConfiguration _configuration;
        protected GateWayQueryContext(GateWayQueryBuilder gateWayQueryBuilder, IConfiguration configuration) 
        {
            _gateWayQueryBuilder = gateWayQueryBuilder;
            _configuration = configuration;
        }

        protected abstract void OnModelCreating(GateWayQueryBuilder queryBuilder);
        public virtual GateWayQueryTypeBuilder<TDto> Set<TDto>() where TDto : ReadDto
        {
            return _gateWayQueryBuilder.Set<TDto>();
        }
    }
}