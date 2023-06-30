using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 판매Common.Command;
using 판매Common.DTO;

namespace 판매Common.GateWay.Handlr
{
    public class Create판매중GateWayCommandHandlr : GateWayCreateCommandHandler<Create판매중DTO>, IRequestHandler<Create판매중Command>
    {
        public Create판매중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create판매중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매중GateWayCommandHandlr : GateWayUpdateCommandHandler<Update판매중DTO>, IRequestHandler<Update판매중Command>
    {
        public Update판매중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update판매중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매중GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete판매중DTO>, IRequestHandler<Delete판매중Command>
    {
        public Delete판매중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete판매중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
