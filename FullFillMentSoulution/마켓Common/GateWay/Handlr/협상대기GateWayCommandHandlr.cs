using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 마켓Common.Command;
using 마켓Common.DTO;

namespace 마켓Common.GateWay.Handlr
{
    public class Create협상대기GateWayCommandHandlr : GateWayCreateCommandHandler<Create협상대기DTO>, IRequestHandler<Create협상대기Command>
    {
        public Create협상대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create협상대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update협상대기GateWayCommandHandlr : GateWayUpdateCommandHandler<Update협상대기DTO>, IRequestHandler<Update협상대기Command>
    {
        public Update협상대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update협상대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete협상대기GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete협상대기DTO>, IRequestHandler<Delete협상대기Command>
    {
        public Delete협상대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete협상대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
