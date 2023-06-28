using AutoMapper;
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
    /// 1. GateWayServer 와 HostServer로 구성정보 흭득단계
    /// 2. 흭득된 정보로 QueName을 구성단계
    /// 1. RabbitMQ 메세지 Deque단계
    /// 2. Deque 메세지 Command로 역직렬화단계
    /// 3. 역질렬화 개체 Model로 매핑단계
    /// 4. 매핑개체 Repository로 CUD단계
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommandServerHandlr<TDTO, TEntity> where TDTO : CudDTO where TEntity : Entity
    {
        protected readonly GateWayCommandContext _gateContext;
        protected readonly IQueryServerConfiguringServcie _queConfigurationService;
        protected readonly IMapper _mapper;
        protected readonly IEntityCommandRepository<TEntity> _commandRepository;
        protected readonly IConfiguration _configuration;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IQueSelectedService _queSelectedServcie;
        public CommandServerHandlr(GateWayCommandContext gateContext,
            IQueryServerConfiguringServcie queConfigurationService,
            IQueSelectedService queSelectedService,
            IMapper mapper,
            IEntityCommandRepository<TEntity> commandRepository,
            IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _queSelectedServcie = queSelectedService;
            _queConfigurationService = queConfigurationService;
            _gateContext = gateContext;
            _mapper = mapper;
            _commandRepository = commandRepository;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        protected string GetQueNameFromGateWayServer(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            var gateWayServer = configuration.GetSection("GateWayServer").Value;
            if (gateWayServer == null) { throw new ArgumentNullException(nameof(gateWayServer)); }
            var queName = gateWayServer.CreateQueueName<TDTO>(webHostEnvironment.ContentRootPath);
            return queName;
        }
        protected async Task<TEntity> DequeHandle(string queName)
        {
            var message = await _gateContext.Set<TDTO>().Dequeue(queName);
            CudCommand<TDTO>? cudCommand = JsonConvert.DeserializeObject<CudCommand<TDTO>>(message);
            if (cudCommand == null) { throw new ArgumentNullException(nameof(cudCommand)); }
            TDTO dto = cudCommand.t;
            if (dto != null)
            {
                var entity = _mapper.Map<TEntity>(dto);
                if (entity != null)
                {
                    await _commandRepository.AddAsync(entity);
                    await _commandRepository.SaveChangesAsync();
                    return entity;
                }
            }
            throw new ArgumentNullException(nameof(dto));
        }
        protected async Task EnqueHandleResultToQueryServer(TEntity entity, ServerSubject serverSubject, string jwtToken)
        {
            ReadQuery<TEntity> query = new(entity, serverSubject, jwtToken);
            var message = query.ToSerializedBytes();
            var servers = _queConfigurationService.GetQueryServers(serverSubject);
            var server = _queSelectedServcie.GetOptimalQueueForEnque<TDTO>(_webHostEnvironment.ContentRootPath, servers, OptimalQueOptions.Min);
            await _gateContext.Set<TDTO>().Enqueue(message, server);
        }
    }
}
