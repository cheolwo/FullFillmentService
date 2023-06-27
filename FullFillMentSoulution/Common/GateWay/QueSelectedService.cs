using Common.Extensions;
using Microsoft.Extensions.Configuration;

namespace Common.GateWay
{
    public interface IQueSelectedService
    {
        string GetOptimalQueue<T>(List<Server> servers);
        //int SetCurrentMessageInQue(Server server);
        //int GetCurrentMessageInQue(Server server);
        //int GetSetCurretnMessageInQue(Server server);
    }

    public class QueSelectedService : IQueSelectedService
    {
        private readonly IRabbitMQQueueStatusService _rabbitMQQueueStatusService;
        private readonly IConfiguration _configuration;
        private Dictionary<string, int> dicQue = new();
        public QueSelectedService(IRabbitMQQueueStatusService rabbitMQQueueStatusService, IConfiguration configuration)
        {
            _rabbitMQQueueStatusService = rabbitMQQueueStatusService ?? throw new ArgumentNullException(nameof(rabbitMQQueueStatusService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public int SetCurrentMessageInQue<T>(Server server)
        {
            var gateWay = _configuration.GetConnectionString("GateWayServerUrl");
            if (gateWay == null)
            {
                throw new ArgumentNullException(nameof(gateWay));
            }
            var queName = gateWay.CreateQueueName<T>(server.Url);
            var count = _rabbitMQQueueStatusService.GetMessageCount(queName);
            var FindQueName = dicQue.Keys.FirstOrDefault(e => e.Equals(queName));
            if (FindQueName != null)
            {
                dicQue[FindQueName] = count;
                return dicQue[FindQueName];
            }
            else
            {
                throw new ArgumentException("등록된 큐가 없습니다.");
            }
        }

        string IQueSelectedService.GetOptimalQueue<T>(List<Server> servers)
        {
            var gateWay = _configuration.GetConnectionString("GateWayServerUrl");
            if (gateWay == null)
            {
                throw new ArgumentNullException(nameof(gateWay));
            }
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
