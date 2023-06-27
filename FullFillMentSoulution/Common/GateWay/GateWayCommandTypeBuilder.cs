using Common.DTO;
using RabbitMQ.Client;
using System.Text;

namespace Common.GateWay
{
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
        /// <summary>
        /// _GateWayContext.Set<TDto>().Enque(message, quename)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="queName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> Enqueue(byte[] message, string queName)
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
            return queName;
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
                    await Task.CompletedTask;
                    return message;
                }
            }

            return null;
        }
    }
}