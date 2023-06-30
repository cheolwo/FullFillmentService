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
using 창고Common.CreateCommand;
using 창고Common.DTO.입고상품;
using 창고Common.DTO.창고;

namespace 창고Common.GateWay.Handlr
{
    public class Create입고상품GateWayCommandHandlr : GateWayCreateCommandHandler<Create입고상품DTO>, IRequestHandler<Create입고상품Command>
    {
        public Create입고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment, 
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }
        public Task Handle(Create입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update입고상품GateWayCommandHandlr : GateWayUpdateCommandHandler<Update입고상품DTO>, IRequestHandler<Update입고상품Command>
    {
        public Update입고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Update입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete입고상품GateWayCommandHandlr : GateWayDeleteCommandHandler<Delete입고상품DTO>, IRequestHandler<Delete입고상품Command>
    {
        public Delete입고상품GateWayCommandHandlr(IQueSelectedService queSelectedService, IWebHostEnvironment webHostEnvironment,
            창고GateWayCommandContext context, QueConfigurationService queConfigurationService) : base(queSelectedService, webHostEnvironment, context, queConfigurationService)
        {
        }

        public Task Handle(Delete입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
