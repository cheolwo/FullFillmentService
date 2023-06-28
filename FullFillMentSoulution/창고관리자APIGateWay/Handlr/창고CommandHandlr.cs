using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using 창고Common.Command;
using 창고Common.DTO.창고;

namespace 창고관리자APIGateWay.Handlr
{
    public class Create창고CommandHandlr : GateWayCreateCommandHandler<Create창고DTO>, IRequestHandler<Create창고Command>
    {
        public Create창고CommandHandlr(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }

        public async Task Handle(Create창고Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
    public class Update창고CommandHandler : GateWayUpdateCommandHandler<Update창고DTO>, IRequestHandler<Update창고Command>
    {
        public Update창고CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }

        public async Task Handle(Update창고Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }

    public class Delete창고CommandHandler : GateWayDeleteCommandHandler<Delete창고DTO>, IRequestHandler<Delete창고Command>
    {
        public Delete창고CommandHandler(IQueSelectedService queSelectedService, 
            GateWayCommandContext context, 
            QueConfigurationService queConfigurationService) : base(queSelectedService, context, queConfigurationService)
        {
        }
        public async Task Handle(Delete창고Command request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);
        }
    }
}
