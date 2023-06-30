using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 주문Common.Command;
using 주문Common.DTO.주문대기;
using 주문Common.GateWay;
using 주문Common.Model;

namespace 주문Common.CommandServer.Handlr
{
    public class Create주문대기CommandServerHandlr : CommandServerStatusHandlr<Create주문대기DTO, 주문대기>, IRequestHandler<Create주문대기Command>
    {
        public Create주문대기CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문대기> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create주문대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문대기CommandServerHandlr : CommandServerStatusHandlr<Update주문대기DTO, 주문대기>, IRequestHandler<Update주문대기Command>
    {
        public Update주문대기CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문대기> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update주문대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문대기CommandServerHandlr : CommandServerStatusHandlr<Delete주문대기DTO, 주문대기>, IRequestHandler<Delete주문대기Command>
    {
        public Delete주문대기CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문대기> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete주문대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
