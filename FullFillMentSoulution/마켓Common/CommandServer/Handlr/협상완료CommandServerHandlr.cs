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
    public class Create협상완료CommandServerHandlr : CommandServerStatusHandlr<Create협상완료DTO, 협상완료>, IRequestHandler<Create협상완료Command>
    {
        public Create협상완료CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상완료> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create협상완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update협상완료CommandServerHandlr : CommandServerStatusHandlr<Update협상완료DTO, 협상완료>, IRequestHandler<Update협상완료Command>
    {
        public Update협상완료CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상완료> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update협상완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete협상완료CommandServerHandlr : CommandServerStatusHandlr<Delete협상완료DTO, 협상완료>, IRequestHandler<Delete협상완료Command>
    {
        public Delete협상완료CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상완료> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete협상완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
