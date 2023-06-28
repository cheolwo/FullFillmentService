using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Common.GateWay
{
    public interface IRabbitMQQueueStatusService
    {
        bool IsQueueReady(string queueName);
        int GetMessageCount(string queueName);
        int GetSetMessageCount(string queName);
    }

    public class RabbitMQQueueStatusService : IRabbitMQQueueStatusService
    {
        private readonly string _connectionString;
        private Dictionary<string, int> QueMessageCount = new();

        public RabbitMQQueueStatusService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("RabbitMQConnectionString") ??
                throw new ArgumentNullException(configuration.GetConnectionString("RabbitMQConnectionString"));
        }

        public bool IsQueueReady(string queueName)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(_connectionString)
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var result = channel.QueueDeclarePassive(queueName);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int GetMessageCount(string queueName)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(_connectionString)
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var result = channel.QueueDeclarePassive(queueName);
                    return (int)result.MessageCount;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int GetSetMessageCount(string queName)
        {
            var count = GetMessageCount(queName);
            var FindQueName = QueMessageCount.Keys.FirstOrDefault(e => e.Equals(queName));
            if (FindQueName != null)
            {
                QueMessageCount[FindQueName] = count;
                return QueMessageCount[FindQueName];
            }
            else
            {
                throw new ArgumentException("등록된 큐가 없습니다.");
            }
        }
    }
}
