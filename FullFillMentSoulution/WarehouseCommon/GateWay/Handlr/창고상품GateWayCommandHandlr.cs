using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 창고Common.Command;
using 창고Common.DTO.창고상품;

namespace 창고Common.GateWay.Handlr
{
    public class Create창고상품GateWayCommandHandlr : GateWayCreateCommandHandler<Create창고상품DTO>, IRequestHandler<Create창고상품Command>
    {
        public Create창고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update창고상품GateWayCommandHandlr : GateWayUpdateCommandHandler<Update창고상품DTO>, IRequestHandler<Update창고상품Command>
    {
        public Update창고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete창고상품GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete창고상품DTO>, IRequestHandler<Delete창고상품Command>
    {
        public Delete창고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
