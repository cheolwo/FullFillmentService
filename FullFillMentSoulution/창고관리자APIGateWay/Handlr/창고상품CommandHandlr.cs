using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using 창고Common.Command;
using 창고Common.DTO.창고상품;

namespace 창고관리자APIGateWay.Handlr
{
    public class Create창고상품CommandHandlr : GateWayCreateCommandHandler<Create창고상품DTO>, IRequestHandler<Create창고상품Command>
    {
        public Create창고상품CommandHandlr(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Create창고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
    public class Update창고상품CommandHandler : GateWayUpdateCommandHandler<Update창고상품DTO>, IRequestHandler<Update창고상품Command>
    {
        public Update창고상품CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }

        public async Task Handle(Update창고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }

    public class Delete창고상품CommandHandler : GateWayDeleteCommandHandler<Delete창고상품DTO>, IRequestHandler<Delete창고상품Command>
    {
        public Delete창고상품CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Delete창고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
}
