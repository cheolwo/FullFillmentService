using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using 창고Common.Command;
using 창고Common.CreateCommand;
using 창고Common.DTO.입고상품;

namespace 창고관리자APIGateWay.Handlr
{
    public class Create입고상품CommandHandlr : GateWayCreateCommandHandler<Create입고상품DTO>, IRequestHandler<Create입고상품Command>
    {
        public Create입고상품CommandHandlr(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Create입고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
    public class Update입고상품CommandHandler : GateWayUpdateCommandHandler<Update입고상품DTO>, IRequestHandler<Update입고상품Command>
    {
        public Update입고상품CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }

        public async Task Handle(Update입고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }

    public class Delete입고상품CommandHandler : GateWayDeleteCommandHandler<Delete입고상품DTO>, IRequestHandler<Delete입고상품Command>
    {
        public Delete입고상품CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Delete입고상품Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
}
