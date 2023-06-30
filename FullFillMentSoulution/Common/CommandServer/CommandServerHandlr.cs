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
    public interface ICommandServerHandler<TDTO> where TDTO : CudDTO
    {
        Task<TDTO?> Handle(CudCommand<TDTO> cudCommand);
    }
    public abstract class CommandServerHandlerBase<TDTO, TEntity> : ICommandServerHandler<TDTO>
    where TDTO : CudDTO
    where TEntity : Entity
    {
        protected readonly GateWayCommandContext _gateContext;
        protected readonly EntityRepository<TEntity> _commandRepository;
        protected readonly IQueryServerConfiguringServcie _queConfigurationService;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _configuration;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IQueSelectedService _queSelectedService;
        protected string _queName;

        public CommandServerHandlerBase(
            GateWayCommandContext gateContext,
            EntityRepository<TEntity> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService,
            IQueSelectedService queSelectedService,
            IMapper mapper,
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment)
        {
            _queSelectedService = queSelectedService;
            _queConfigurationService = queConfigurationService;
            _gateContext = gateContext;
            _mapper = mapper;
            _commandRepository = commandRepository;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public abstract Task<TDTO?> Handle(CudCommand<TDTO> cudCommand);

        protected async Task EnqueHandleResultToQueryServer(CudCommand<TDTO> command)
        {
            var message = command.ToSerializedBytes();
            var servers = _queConfigurationService.GetQueryServers(command.ServerSubject);
            var server = _queSelectedService.GetOptimalQueueForEnque<TDTO>(_webHostEnvironment.ContentRootPath, servers, OptimalQueOptions.Min);
            await _gateContext.Set<TDTO>().Enqueue(message, server);
        }
    }
}
