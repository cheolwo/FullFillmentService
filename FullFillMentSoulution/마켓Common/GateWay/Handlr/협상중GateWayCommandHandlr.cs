using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 마켓Common.Command;
using 마켓Common.DTO;

namespace 마켓Common.GateWay.Handlr
{
    public class Create협상중GateWayCommandHandlr : GateWayCreateCommandHandler<Create협상중DTO>, IRequestHandler<Create협상중Command>
    {
        public Create협상중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update협상중GateWayCommandHandlr : GateWayUpdateCommandHandler<Update협상중DTO>, IRequestHandler<Update협상중Command>
    {
        public Update협상중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete협상중GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete협상중DTO>, IRequestHandler<Delete협상중Command>
    {
        public Delete협상중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
