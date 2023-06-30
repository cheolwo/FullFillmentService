using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 마켓Common.Command;
using 마켓Common.DTO;

namespace 마켓Common.GateWay.Handlr
{
    public class Create마켓상품GateWayCommandHandlr : GateWayCreateCommandHandler<Create마켓상품DTO>, IRequestHandler<Create마켓상품Command>
    {
        public Create마켓상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create마켓상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update마켓상품GateWayCommandHandlr : GateWayUpdateCommandHandler<Update마켓상품DTO>, IRequestHandler<Update마켓상품Command>
    {
        public Update마켓상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update마켓상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete마켓상품GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete마켓상품DTO>, IRequestHandler<Delete마켓상품Command>
    {
        public Delete마켓상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete마켓상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
