using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using 주문Common.Command;
using 주문Common.DTO.주문대기;

namespace 주문Common.GateWay.Handlr
{
    public class Create주문대기GateWayCommandHandlr : GateWayCreateCommandHandler<Create주문대기DTO>, IRequestHandler<Create주문대기Command>
    {
        public Create주문대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create주문대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문대기GateWayCommandHandlr : GateWayUpdateCommandHandler<Update주문대기DTO>, IRequestHandler<Update주문대기Command>
    {
        public Update주문대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update주문대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문대기GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete주문대기DTO>, IRequestHandler<Delete주문대기Command>
    {
        public Delete주문대기GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            주문GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete주문대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
