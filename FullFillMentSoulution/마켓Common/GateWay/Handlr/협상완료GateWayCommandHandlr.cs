using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 마켓Common.Command;
using 마켓Common.DTO;
using System.Threading.Tasks;

namespace 마켓Common.GateWay.Handlr
{
    public class Create협상완료GateWayCommandHandlr : GateWayCreateCommandHandler<Create협상완료DTO>, IRequestHandler<Create협상완료Command>
    {
        public Create협상완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create협상완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update협상완료GateWayCommandHandlr : GateWayUpdateCommandHandler<Update협상완료DTO>, IRequestHandler<Update협상완료Command>
    {
        public Update협상완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update협상완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete협상완료GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete협상완료DTO>, IRequestHandler<Delete협상완료Command>
    {
        public Delete협상완료GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            마켓GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete협상완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
