using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 주문Common.Command;
using 주문Common.DTO.주문자;

namespace 주문Common.GateWay.Handlr
{
    public class Create주문자GateWayCommandHandlr : GateWayCreateCommandHandler<Create주문자DTO>, IRequestHandler<Create주문자Command>
    {
        public Create주문자GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create주문자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문자GateWayCommandHandlr : GateWayUpdateCommandHandler<Update주문자DTO>, IRequestHandler<Update주문자Command>
    {
        public Update주문자GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update주문자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문자GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete주문자DTO>, IRequestHandler<Delete주문자Command>
    {
        public Delete주문자GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete주문자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
