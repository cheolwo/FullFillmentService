using Common.GateWay;
using Common.GateWayCommand;
using MediatR;
using 창고Common.Command;
using 창고Common.DTO.적재상품;

namespace 창고관리자APIGateWay.Handlr
{
    public class Create적재상품CommandHandlr : GateWayCreateCommandHandler<Create적재상품DTO>, IRequestHandler<Create적재상품Command>
    {
        public Create적재상품CommandHandlr(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Create적재상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
    public class Update적재상품CommandHandler : GateWayUpdateCommandHandler<Update적재상품DTO>, IRequestHandler<Update적재상품Command>
    {
        public Update적재상품CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }

        public async Task Handle(Update적재상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }

    public class Delete적재상품CommandHandler : GateWayDeleteCommandHandler<Delete적재상품DTO>, IRequestHandler<Delete적재상품Command>
    {
        public Delete적재상품CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Delete적재상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
}
