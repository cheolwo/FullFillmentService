using Common.DTO;
using Common.Model;
using RabbitMQ.Client;
using System.Text;

namespace Common.GateWay
{
    public class GateWayTypeBuilder<T> where T : class
    {
        protected string? _connectionString;
        public async Task<string?> Enqueue(byte[] message, string queName)
        {
            if (_connectionString == null) { throw new ArgumentNullException(nameof(_connectionString)); }

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
            return queName;
        }

        public async Task<string?> Dequeue(string queName)
        {
            if (_connectionString == null) { throw new ArgumentNullException(nameof(_connectionString)); }

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
                    await Task.CompletedTask;
                    return message;
                }
            }

            return null;
        }
        public async Task<List<string>> DequeueAll(string queName)
        {
            if (_connectionString == null) { throw new ArgumentNullException(nameof(_connectionString)); }

            var factory = new ConnectionFactory
            {
                Uri = new Uri(_connectionString)
            };

            List<string> messages = new List<string>();

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                bool keepDequeuing = true;
                while (keepDequeuing)
                {
                    BasicGetResult result = channel.BasicGet(queName, autoAck: true);

                    if (result != null)
                    {
                        var body = result.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        messages.Add(message);
                    }
                    else
                    {
                        keepDequeuing = false;
                    }
                }
            }

            return messages;
        }
        public GateWayTypeBuilder<T> SetRabbitMqConnection(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }
    }
    public class GateWayCommandTypeBuilder<T> : GateWayTypeBuilder<T>, IQueForGateWayServer, IQueForBusinessServer where T : class
    {
        private string? _gateWay;
        public GateWayCommandTypeBuilder(IGateWayCommandConfiguration<T>? configuration)
        {
            if(configuration == null) { throw new ArgumentNullException(nameof(configuration)); }
            configuration.Configure(this);
        }
        public GateWayCommandTypeBuilder<T> SetGateWay(string gateWay)
        {
            _gateWay = gateWay;
            return this;
        }
    }
    public class GateWayQueryTypeBuilder<T> : GateWayTypeBuilder<T>, IQueForGateWayServer, IQueForBusinessServer where T : class
    {
        public GateWayQueryTypeBuilder(IGateWayQueryConfiguration<T>? configuration)
        {
            if (configuration == null) { throw new ArgumentNullException(nameof(configuration)); }
            configuration.Configure(this);
        }
    }
}