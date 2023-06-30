using Common.GateWay;
using Common.GateWay.GateWayCommand;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 창고Common.Command;
using 창고Common.DTO.창고;

namespace 창고Common.GateWay.Handlr
{
    public class Create창고GateWayCommandHandlr : GateWayCreateCommandHandler<Create창고DTO>, IRequestHandler<Create창고Command>
    {
        public Create창고GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create창고Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update창고GateWayCommandHandlr : GateWayUpdateCommandHandler<Update창고DTO>, IRequestHandler<Update창고Command>
    {
        public Update창고GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update창고Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete창고GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete창고DTO>, IRequestHandler<Delete창고Command>
    {
        public Delete창고GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete창고Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
