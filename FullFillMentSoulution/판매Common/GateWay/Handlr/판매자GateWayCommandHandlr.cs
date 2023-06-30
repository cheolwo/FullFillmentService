using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 판매Common.Command;
using 판매Common.DTO;
namespace 판매Common.GateWay.Handlr
{
    public class Create판매자GateWayCommandHandlr : GateWayCreateCommandHandler<Create판매자DTO>, IRequestHandler<Create판매자Command>
    {
        public Create판매자GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create판매자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매자GateWayCommandHandlr : GateWayUpdateCommandHandler<Update판매자DTO>, IRequestHandler<Update판매자Command>
    {
        public Update판매자GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update판매자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매자GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete판매자DTO>, IRequestHandler<Delete판매자Command>
    {
        public Delete판매자GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete판매자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
