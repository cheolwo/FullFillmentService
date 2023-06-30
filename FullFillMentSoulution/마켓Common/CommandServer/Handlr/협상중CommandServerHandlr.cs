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
    public class Create협상중CommandServerHandlr : CommandServerStatusHandlr<Create협상중DTO, 협상중>, IRequestHandler<Create협상중Command>
    {
        public Create협상중CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상중> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update협상중CommandServerHandlr : CommandServerStatusHandlr<Update협상중DTO, 협상중>, IRequestHandler<Update협상중Command>
    {
        public Update협상중CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상중> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete협상중CommandServerHandlr : CommandServerStatusHandlr<Delete협상중DTO, 협상중>, IRequestHandler<Delete협상중Command>
    {
        public Delete협상중CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상중> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
