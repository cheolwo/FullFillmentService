using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using 창고Common.Command;
using 창고Common.DTO.출고상품;

namespace 창고관리자APIGateWay.Handlr
{
    public class Create출고상품CommandHandlr : GateWayCreateCommandHandler<Create출고상품DTO>, IRequestHandler<Create출고상품Command>
    {
        public Create출고상품CommandHandlr(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Create출고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
    public class Update출고상품CommandHandler : GateWayUpdateCommandHandler<Update출고상품DTO>, IRequestHandler<Update출고상품Command>
    {
        public Update출고상품CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }

        public async Task Handle(Update출고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }

    public class Delete출고상품CommandHandler : GateWayDeleteCommandHandler<Delete출고상품DTO>, IRequestHandler<Delete출고상품Command>
    {
        public Delete출고상품CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Delete출고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
}
