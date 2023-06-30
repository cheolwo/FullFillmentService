using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 판매Common.Command;
using 판매Common.DTO;

namespace 판매Common.GateWay.Handlr
{
    public class Create판매대기GateWayCommandHandlr : GateWayCreateCommandHandler<Create판매대기DTO>, IRequestHandler<Create판매대기Command>
    {
        public Create판매대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create판매대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매대기GateWayCommandHandlr : GateWayUpdateCommandHandler<Update판매대기DTO>, IRequestHandler<Update판매대기Command>
    {
        public Update판매대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update판매대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매대기GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete판매대기DTO>, IRequestHandler<Delete판매대기Command>
    {
        public Delete판매대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete판매대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
