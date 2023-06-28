using AutoMapper;
using Common.Cache;
using Common.DTO;
using Common.Extensions;
using Common.ForCommand;
using Common.GateWay;
using Common.Model;
using Common.Model.Repository;
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
    public class QueryServerHandlr<TDTO, TEntity> where TDTO : CudDTO where TEntity : Entity
    {
        protected readonly IConfiguration _configuration;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IMapper _mapper;
        protected readonly ICommandServerConfiguringService _commandServerConfiguring;
        protected readonly IQueSelectedService _queSelectedService;
        protected readonly IEntityQueryRepository<TEntity> _entityQueryRepository;
        protected readonly ActorMemoryModule _actorMemoryModule;
        protected readonly ActorDistributedCacheModule _actorDistributedCacheModule;
        protected readonly GateWayQueryContext _gateContext;
        public QueryServerHandlr(IMapper mapper, 
            ICommandServerConfiguringService commandServerConfiguringService,
            IEntityQueryRepository<TEntity> entityQueryRepository,
            IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IQueSelectedService queSelectedService,
            ActorMemoryModule actorMemoryModule,
            ActorDistributedCacheModule actorDistributedCacheModule, 
            GateWayQueryContext gateContext)
        {
            _mapper = mapper;
            _commandServerConfiguring = commandServerConfiguringService;
            _entityQueryRepository = entityQueryRepository;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _queSelectedService = queSelectedService;
            _gateContext = gateContext;
            _actorMemoryModule = actorMemoryModule;
            _actorDistributedCacheModule = actorDistributedCacheModule;
        }
        // 1, 2
        protected string GetQueNameFromCommandServer(IWebHostEnvironment webHostEnvironment, ServerSubject serverSubject)
        {
            var servers = _commandServerConfiguring.GetCommandServers(serverSubject);
            var server = _queSelectedService.GetOptimalQueueForDeque<TDTO>(_webHostEnvironment.ContentRootPath, servers, OptimalQueOptions.Max);
            var queName = server.CreateQueueName<TDTO>(webHostEnvironment.ContentRootPath);
            return queName;
        }
        // 3.4.5
        protected async Task DequeHandle(string queName)
        {
            var message = await _gateContext.Set<TDTO>().Dequeue(queName);
            ReadQuery<TDTO>? readQuery = JsonConvert.DeserializeObject<ReadQuery<TDTO>>(message);
            if(readQuery == null || readQuery.T == null || readQuery.T.Id == null || readQuery.JwtToken == null) 
                                                                    { throw new ArgumentNullException(nameof(readQuery)); }
            _actorMemoryModule.SetDto(readQuery.T.Id, readQuery.T, readQuery.JwtToken);
            _actorDistributedCacheModule.SetDto(readQuery.T.Id, readQuery.T, readQuery.JwtToken);
        }
        protected string GetQueNameFromGateWayServer(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            var gateWayServer = configuration.GetSection("GateWayServer").Value;
            if (gateWayServer == null) { throw new ArgumentNullException(nameof(gateWayServer)); }
            var queName = gateWayServer.CreateQueueName<TDTO>(webHostEnvironment.ContentRootPath);
            return queName;
        }
    }
}
