using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 주문Common.Command;
using 주문Common.DTO.주문완료;

namespace 주문Common.GateWay.Handlr
{
    public class Create주문완료GateWayCommandHandlr : GateWayCreateCommandHandler<Create주문완료DTO>, IRequestHandler<Create주문완료Command>
    {
        public Create주문완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create주문완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문완료GateWayCommandHandlr : GateWayUpdateCommandHandler<Update주문완료DTO>, IRequestHandler<Update주문완료Command>
    {
        public Update주문완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update주문완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문완료GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete주문완료DTO>, IRequestHandler<Delete주문완료Command>
    {
        public Delete주문완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete주문완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
