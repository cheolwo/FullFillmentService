using Azure.Core;
using Common.DTO;
using Common.Extensions;
using Common.ForCommand;
using Common.GateWay;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Common.GateWayCommand
{
    public interface IGateWayCommandHandlr<T> where T : CudDTO
    {
        
    }
    public class GateWayCommandHandler<T> : IRequestHandler<CudCommand<T>> where T : CudDTO
    {
        protected readonly IQueSelectedService _queSelectedService;
        protected readonly GateWayCommandContext _context;
        protected readonly QueConfigurationService _queConfigurationService;

        public GateWayCommandHandler(IQueSelectedService queSelectedService,
                                    GateWayCommandContext context,
                                    QueConfigurationService queConfigurationService
                                    )
        {
            _context = context;
            _queConfigurationService = queConfigurationService;
            _queSelectedService = queSelectedService;
        }

        public async Task Handle(CudCommand<T> request, CancellationToken cancellationToken)
        {
            byte[] messageBytes = request.ToSerializedBytes();
            List<Server> servers = _queConfigurationService.GetLogisticsServers();

            var queueName = _queSelectedService.GetOptimalQueue<T>(servers);
            if (queueName == null)
            {
                //_logger.LogError("No suitable queue found.");
                throw new Exception("No suitable queue found.");
            }

            await _context.Set<T>().Enqueue(messageBytes, queueName);
            //_logger.LogInformation("Enqueued message to {QueueName}", queueName);
        }
    }
    public class GateWayCreateCommandHandler<T> : GateWayCommandHandler<T> where T : CudDTO
    {
        public GateWayCreateCommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
    }

    public class GateWayUpdateCommandHandler<T> : GateWayCommandHandler<T> where T : CudDTO
    {
        public GateWayUpdateCommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
    }

    public class GateWayDeleteCommandHandler<T> : GateWayCommandHandler<T> where T : CudDTO
    {
        public GateWayDeleteCommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
    }
}
