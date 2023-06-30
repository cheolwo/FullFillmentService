using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 창고Common.Command;
using 창고Common.DTO.적재상품;

namespace 창고Common.GateWay.Handlr
{
    public class Create적재상품GateWayCommandHandlr : GateWayCreateCommandHandler<Create적재상품DTO>, IRequestHandler<Create적재상품Command>
    {
        public Create적재상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update적재상품GateWayCommandHandlr : GateWayUpdateCommandHandler<Update적재상품DTO>, IRequestHandler<Update적재상품Command>
    {
        public Update적재상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete적재상품GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete적재상품DTO>, IRequestHandler<Delete적재상품Command>
    {
        public Delete적재상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
