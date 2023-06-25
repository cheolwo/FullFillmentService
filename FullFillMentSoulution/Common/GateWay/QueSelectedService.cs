using Common.DTO;
using Common.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GateWay
{
    public interface IQueSelectedService
    {
        string GetOptimalQueue<T>(List<Server> servers);
    }

    public class QueSelectedService : IQueSelectedService
    {
        private readonly IRabbitMQQueueStatusService _rabbitMQQueueStatusService;
        private readonly IConfiguration _configuration;

        public QueSelectedService(IRabbitMQQueueStatusService rabbitMQQueueStatusService, IConfiguration configuration)
        {
            _rabbitMQQueueStatusService = rabbitMQQueueStatusService ?? throw new ArgumentNullException(nameof(rabbitMQQueueStatusService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        string IQueSelectedService.GetOptimalQueue<T>(List<Server> servers)
        {
            var gateWay = _configuration.GetConnectionString("GateWayServerUrl");
            if (gateWay == null)
            {
                throw new ArgumentNullException(nameof(gateWay));
            }

            Dictionary<string, int> dicQue = new Dictionary<string, int>();
            foreach (Server server in servers)
            {
                var queName = gateWay.CreateQueueName<T>(server.Url);
                var count = _rabbitMQQueueStatusService.GetMessageCount(queName);
                if (count > 0)
                {
                    dicQue.Add(queName, count);
                }
            }

            if (dicQue.Count > 0)
            {
                int minCount = dicQue.Min(x => x.Value);
                string optimalQueue = dicQue.First(x => x.Value == minCount).Key;

                return optimalQueue;
            }

            throw new ArgumentException("No suitable queue found.");
        }
    }
}
