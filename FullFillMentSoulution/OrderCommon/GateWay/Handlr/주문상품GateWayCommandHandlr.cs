using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 주문Common.Command;
using 주문Common.DTO.주문상품;

namespace 주문Common.GateWay.Handlr
{
    public class Create주문상품GateWayCommandHandlr : GateWayCreateCommandHandler<Create주문상품DTO>, IRequestHandler<Create주문상품Command>
    {
        public Create주문상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create주문상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문상품GateWayCommandHandlr : GateWayUpdateCommandHandler<Update주문상품DTO>, IRequestHandler<Update주문상품Command>
    {
        public Update주문상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update주문상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문상품GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete주문상품DTO>, IRequestHandler<Delete주문상품Command>
    {
        public Delete주문상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete주문상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
