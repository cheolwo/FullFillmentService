using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 주문Common.Command;
using 주문Common.DTO.주문중;

namespace 주문Common.GateWay.Handlr
{
    public class Create주문중GateWayCommandHandlr : GateWayCreateCommandHandler<Create주문중DTO>, IRequestHandler<Create주문중Command>
    {
        public Create주문중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create주문중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문중GateWayCommandHandlr : GateWayUpdateCommandHandler<Update주문중DTO>, IRequestHandler<Update주문중Command>
    {
        public Update주문중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update주문중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문중GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete주문중DTO>, IRequestHandler<Delete주문중Command>
    {
        public Delete주문중GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete주문중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
