using Common.Extensions;
using Common.ForCommand;
using Microsoft.Extensions.Configuration;
using Quartz.Impl.AdoJobStore.Common;

namespace Common.GateWay
{
    public interface IQueSelectedService
    {
        string GetOptimalQueueForEnque<TDTO>(string provider, List<Server> enqueServers, OptimalQueOptions options);
        string GetOptimalQueueForDeque<TDTO>(string consumer, List<Server> dequeServers, OptimalQueOptions options);
    }
    public enum OptimalQueOptions { Min, Max }
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

        public int SetCurrentMessageInQue<T>(Server server, IEvent @event)
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

        public string GetOptimalQueueForEnque<T>(string provider, List<Server> enqueServers, OptimalQueOptions options)
        {
            foreach (Server server in enqueServers) 
            {
                var queName = provider.CreateQueueName<T>(server.Url);
                var count = _rabbitMQQueueStatusService.GetMessageCount(queName);
                if (count > 0)
                {
                    dicQue.Add(queName, count);
                }
            }

            if (dicQue.Count > 0)
            {
                switch (options)
                {
                    case OptimalQueOptions.Min:
                        return GetMinOptiomalQue(dicQue);
                    case OptimalQueOptions.Max:
                        return GetMaxOptiomalQue(dicQue);
                    default:
                        break;
                }
            }

            throw new ArgumentException("No suitable queue found.");
        }
        public string GetOptimalQueueForDeque<T>(string consumer, List<Server> dequeServers, OptimalQueOptions options)
        {
            foreach (Server server in dequeServers)
            {
                if(server.Url == null) { continue; }
                var queName = server.Url.CreateQueueName<T>(consumer);
                var count = _rabbitMQQueueStatusService.GetMessageCount(queName);
                if (count > 0)
                {
                    dicQue.Add(queName, count);
                }
            }

            if (dicQue.Count > 0)
            {
                switch (options)
                {
                    case OptimalQueOptions.Min:
                        return GetMinOptiomalQue(dicQue);
                    case OptimalQueOptions.Max:
                        return GetMaxOptiomalQue(dicQue);
                    default:
                        break;
                }
            }
            throw new ArgumentException("No suitable queue found.");
        }
        private string GetMinOptiomalQue(Dictionary<string, int> dicQue)
        {
            int minCount = dicQue.Min(x => x.Value);
            string optimalQueue = dicQue.First(x => x.Value == minCount).Key;

            return optimalQueue;
        }
        private string GetMaxOptiomalQue(Dictionary<string, int> dicQue)
        {
            int minCount = dicQue.Max(x => x.Value);
            string optimalQueue = dicQue.First(x => x.Value == minCount).Key;

            return optimalQueue;
        }

    }
}
