using Common.DTO;
using Common.Extensions;
using Common.ForCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Common.GateWay.GateWayCommand
{
    public class GateWayCommandHandler<T> : IRequestHandler<CudCommand<T>> where T : CudDTO
    {
        protected readonly IQueSelectedService _queSelectedService;
        protected readonly GateWayCommandContext _context;
        protected readonly QueConfigurationService _queConfigurationService;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        public GateWayCommandHandler(IQueSelectedService queSelectedService,
            IWebHostEnvironment webHostEnvironment,
                                    GateWayCommandContext context,
                                    QueConfigurationService queConfigurationService
                                    )
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context; 
            _queConfigurationService = queConfigurationService;
            _queSelectedService = queSelectedService;
        }

        public async Task Handle(CudCommand<T> request, CancellationToken cancellationToken)
        {
            request.DateTime = DateTime.Now;
            byte[] messageBytes = request.ToSerializedBytes();
            List<Server> servers = _queConfigurationService.GetCommandServers(request.ServerSubject);

            var queueName = _queSelectedService.GetOptimalQueueForEnque<T>(
                _webHostEnvironment.ContentRootPath, servers, OptimalQueOptions.Min);
            if (queueName == null)
            {
                //_logger.LogError("No suitable queue found.");
                throw new Exception("No suitable queue found.");
            }

            await _context.Set<T>().Enqueue(messageBytes, queueName);
        }
    }
    public class GateWayCreateCommandHandler<T> : GateWayCommandHandler<T> where T : CudDTO
    {
        public GateWayCreateCommandHandler(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
    }

    public class GateWayUpdateCommandHandler<T> : GateWayCommandHandler<T> where T : CudDTO
    {
        public GateWayUpdateCommandHandler(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
    }

    public class GateWayDeleteCommandHandler<T> : GateWayCommandHandler<T> where T : CudDTO
    {
        public GateWayDeleteCommandHandler(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
    }
}
