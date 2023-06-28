using Common.Cache;
using Common.Extensions;
using Common.ForCommand;
using Common.GateWay;
using Common.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Common.CommandServer
{
    /// <summary>
    /// 1. 현존 CommandServer 정보를 얻는단계
    /// 2. 가장 메세지가 많은 큐를 선택하는 단계
    /// 3. 해당 큐에서 메세지를 Deque하는 단계
    /// 4. Deque된 메세지를 역직렬화하여 DTO로 치환하는 단계
    /// 5. 치환된 DTO를 CUD 프로세스에 따라 Redis 및 InMemory를 변경하는 단계
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="webHostEnvironment"></param>
    /// <param name="serverSubject"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public class QueryServerHandlr<TEntity> where TEntity : Entity, IStorableInCenterMemory
    {
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly ICommandServerConfiguringService _commandServerConfiguring;
        protected readonly IQueSelectedService _queSelectedService;
        protected readonly CenterMemoryModule _centerMemoryModule;
        protected readonly GateWayQueryContext _gateContext;
        public QueryServerHandlr(
            ICommandServerConfiguringService commandServerConfiguringService,
            IWebHostEnvironment webHostEnvironment, IQueSelectedService queSelectedService,
            CenterMemoryModule centerMemoryModule,
            GateWayQueryContext gateContext)
        {
            _commandServerConfiguring = commandServerConfiguringService;
            _webHostEnvironment = webHostEnvironment;
            _queSelectedService = queSelectedService;
            _gateContext = gateContext;
            _centerMemoryModule = centerMemoryModule;
        }
        // 1, 2
        protected string GetQueNameFromCommandServer(IWebHostEnvironment webHostEnvironment, ServerSubject serverSubject)
        {
            var servers = _commandServerConfiguring.GetCommandServers(serverSubject);
            var server = _queSelectedService.GetOptimalQueueForDeque<TEntity>(_webHostEnvironment.ContentRootPath, servers, OptimalQueOptions.Max);
            var queName = server.CreateQueueName<TEntity>(webHostEnvironment.ContentRootPath);
            return queName;
        }
        // 3.4.5
        protected async Task DequeHandle(string queName)
        {
            var message = await _gateContext.Set<TEntity>().Dequeue(queName);
            ReadQuery<TEntity>? readQuery = JsonConvert.DeserializeObject<ReadQuery<TEntity>>(message);
            if (readQuery == null || readQuery.t == null || readQuery.t.Id == null || readQuery.JwtToken == null)
            {
                throw new ArgumentNullException(nameof(readQuery));
            }

            if (readQuery.t is Center center)
            {
                _centerMemoryModule.SetCenter(center);
            }
            else if (readQuery.t is Commodity commodity)
            {
                string centerId = commodity.GetCenterId();
                if (!string.IsNullOrEmpty(centerId))
                {
                    _centerMemoryModule.SetCommodity(centerId, commodity);
                }
            }
            else if (readQuery.t is Status status)
            {
                string centerId = status.GetCenterId();
                if (!string.IsNullOrEmpty(centerId))
                {
                    _centerMemoryModule.SetStatus(centerId, status);
                }
            }
            else
            {
                throw new NotSupportedException($"Type '{typeof(TEntity).Name}' is not supported for storage in the CenterMemoryModule.");
            }
        }
        protected string GetQueNameFromGateWayServer(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            var gateWayServer = configuration.GetSection("GateWayServer").Value;
            if (gateWayServer == null) { throw new ArgumentNullException(nameof(gateWayServer)); }
            var queName = gateWayServer.CreateQueueName<TEntity>(webHostEnvironment.ContentRootPath);
            return queName;
        }
    }
}
