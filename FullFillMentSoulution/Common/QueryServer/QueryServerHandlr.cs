using AutoMapper;
using Common.Cache;
using Common.DTO;
using Common.Extensions;
using Common.ForCommand;
using Common.GateWay;
using Common.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Common.QueryServer
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
    public class QueryServerHandlr<TDTO, TEntity> where TDTO : ReadDto where TEntity : Entity
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
            var server = _queSelectedService.GetOptimalQueueForDeque<TDTO>(_webHostEnvironment.ContentRootPath, servers, OptimalQueOptions.Max);
            var queName = server.CreateQueueName<TDTO>(webHostEnvironment.ContentRootPath);
            return queName;
        }
        protected async Task<CudCommand<TDTO>> Deque(string queName)
        {
            var message = await _gateContext.Set<TDTO>().Dequeue(queName);
            CudCommand<TDTO>? cudCommand = JsonConvert.DeserializeObject<CudCommand<TDTO>>(message);
            if (cudCommand == null || cudCommand.t == null || cudCommand.t.Id == null || cudCommand.JwtToken == null)
            {
                throw new ArgumentNullException(nameof(cudCommand));
            }
            return cudCommand;
        }
    }
}
