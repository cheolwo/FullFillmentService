using Common.Actor.Builder;
using Common.DTO;
using Common.Extensions;
using Common.ForCommand;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using StackExchange.Redis;
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
    public interface IQueForGateWayServer
    {
        Task Enqueue(byte[] message, string queName);
    }
    public interface IQueForBusinessServer
    {
        Task<string> Dequeue(string queName);
    }
    public class GateWayCommandTypeBuilder<T> : IQueForGateWayServer, IQueForBusinessServer where T : CudDTO
    {
        private string? _connectionString;
        private string? _gateWay;
        public GateWayCommandTypeBuilder(IGateWayCommandConfiguration<T>? configuration)
        {
            if(configuration == null) { throw new ArgumentNullException(nameof(configuration)); }
            configuration.Configure(this);
        }
        public GateWayCommandTypeBuilder<T> SetRabbitMqConnection(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }
        public GateWayCommandTypeBuilder<T> SetGateWay(string gateWay)
        {
            _gateWay = gateWay;
            return this;
        }
        public async Task Enqueue(byte[] message, string queName)
        {
            if(_connectionString == null) { throw new ArgumentNullException(nameof(_connectionString));}
            if(_gateWay == null) { throw new ArgumentNullException(nameof(_gateWay)); }

            var factory = new ConnectionFactory
            {
                Uri = new Uri(_connectionString)
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.BasicPublish(exchange: "", routingKey: queName, basicProperties: null, body: message);
            }

            await Task.CompletedTask;
        }

        public async Task<string> Dequeue(string queName)
        {
            if (_connectionString == null) { throw new ArgumentNullException(nameof(_connectionString)); }
            if (_gateWay == null) { throw new ArgumentNullException(nameof(_gateWay)); }

            var factory = new ConnectionFactory
            {
                Uri = new Uri(_connectionString)
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                BasicGetResult result = channel.BasicGet(queName, autoAck: true);

                if (result != null)
                {
                    var body = result.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    return message;
                }
            }

            return null;
        }
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
    //public class RabbitMQCommandQue<T> : IQueForGateWayServer<T>, IQueForBusinessServer<T> where T : CudDTO
    //{
    //    private readonly IWebHostEnvironment _webHostEnvironment;
    //    private readonly IConfiguration _configuration;
    //    private readonly string _connectionString;

    //    public RabbitMQCommandQue(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    //    {
    //        _webHostEnvironment = webHostEnvironment;
    //        _configuration = configuration;

    //        // 연결 문자열 구성
    //        _connectionString = _configuration["RabbitMQ:ConnectionString"];
    //    }

    //    public async Task Enqueue(T command)
    //    {
    //        var factory = new ConnectionFactory
    //        {
    //            Uri = new Uri(_connectionString)
    //        };

    //        using (var connection = factory.CreateConnection())
    //        using (var channel = connection.CreateModel())
    //        {
    //            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

    //            var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));

    //            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: message);
    //        }

    //        await Task.CompletedTask;
    //    }

    //    public async Task<T> Dequeue()
    //    {
    //        var factory = new ConnectionFactory
    //        {
    //            Uri = new Uri(_connectionString)
    //        };

    //        using (var connection = factory.CreateConnection())
    //        using (var channel = connection.CreateModel())
    //        {
    //            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

    //            BasicGetResult result = channel.BasicGet(_queueName, autoAck: true);

    //            if (result != null)
    //            {
    //                var body = result.Body.ToArray();
    //                var message = Encoding.UTF8.GetString(body);

    //                T command = JsonConvert.DeserializeObject<T>(message);

    //                return command;
    //            }
    //        }

    //        return null;
    //    }
    //}
}