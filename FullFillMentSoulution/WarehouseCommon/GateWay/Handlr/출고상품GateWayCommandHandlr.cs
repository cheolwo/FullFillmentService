using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 창고Common.Command;
using 창고Common.DTO.출고상품;

namespace 창고Common.GateWay.Handlr
{
    public class Create출고상품GateWayCommandHandlr : GateWayCreateCommandHandler<Create출고상품DTO>, IRequestHandler<Create출고상품Command>
    {
        public Create출고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update출고상품GateWayCommandHandlr : GateWayUpdateCommandHandler<Update출고상품DTO>, IRequestHandler<Update출고상품Command>
    {
        public Update출고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete출고상품GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete출고상품DTO>, IRequestHandler<Delete출고상품Command>
    {
        public Delete출고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
