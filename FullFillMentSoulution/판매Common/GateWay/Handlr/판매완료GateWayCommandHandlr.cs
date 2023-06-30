using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 판매Common.Command;
using 판매Common.DTO;
namespace 판매Common.GateWay.Handlr
{
    public class Create판매완료GateWayCommandHandlr : GateWayCreateCommandHandler<Create판매완료DTO>, IRequestHandler<Create판매완료Command>
    {
        public Create판매완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create판매완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매완료GateWayCommandHandlr : GateWayUpdateCommandHandler<Update판매완료DTO>, IRequestHandler<Update판매완료Command>
    {
        public Update판매완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update판매완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매완료GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete판매완료DTO>, IRequestHandler<Delete판매완료Command>
    {
        public Delete판매완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete판매완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
