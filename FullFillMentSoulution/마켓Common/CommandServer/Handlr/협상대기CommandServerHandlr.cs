using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 마켓Common.Command;
using 마켓Common.DTO;
using 마켓Common.GateWay;
using 마켓Common.Model;

namespace 마켓Common.CommandServer.Handlr
{
    public class Create협상대기CommandServerHandlr : CommandServerStatusHandlr<Create협상대기DTO, 협상대기>, IRequestHandler<Create협상대기Command>
    {
        public Create협상대기CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상대기> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create협상대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update협상대기CommandServerHandlr : CommandServerStatusHandlr<Update협상대기DTO, 협상대기>, IRequestHandler<Update협상대기Command>
    {
        public Update협상대기CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상대기> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update협상대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete협상대기CommandServerHandlr : CommandServerStatusHandlr<Delete협상대기DTO, 협상대기>, IRequestHandler<Delete협상대기Command>
    {
        public Delete협상대기CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상대기> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete협상대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
