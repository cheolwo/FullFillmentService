using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 마켓Common.Command;
using 마켓Common.DTO;

namespace 마켓Common.GateWay.Handlr
{
    public class Create마켓GateWayCommandHandlr : GateWayCreateCommandHandler<Create마켓DTO>, IRequestHandler<Create마켓Command>
    {
        public Create마켓GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create마켓Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update마켓GateWayCommandHandlr : GateWayUpdateCommandHandler<Update마켓DTO>, IRequestHandler<Update마켓Command>
    {
        public Update마켓GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update마켓Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete마켓GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete마켓DTO>, IRequestHandler<Delete마켓Command>
    {
        public Delete마켓GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete마켓Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
