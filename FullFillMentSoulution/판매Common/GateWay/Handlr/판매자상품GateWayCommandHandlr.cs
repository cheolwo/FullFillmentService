using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 판매Common.Command;
using 판매Common.DTO;

namespace 판매Common.GateWay.Handlr
{
    public class Create판매자상품GateWayCommandHandlr : GateWayCreateCommandHandler<Create판매자상품DTO>, IRequestHandler<Create판매자상품Command>
    {
        public Create판매자상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create판매자상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매자상품GateWayCommandHandlr : GateWayUpdateCommandHandler<Update판매자상품DTO>, IRequestHandler<Update판매자상품Command>
    {
        public Update판매자상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update판매자상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매자상품GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete판매자상품DTO>, IRequestHandler<Delete판매자상품Command>
    {
        public Delete판매자상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            판매GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete판매자상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
