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
    public class Create마켓CommandServerHandlr : CommandServerCenterHandlr<Create마켓DTO, 마켓>, IRequestHandler<Create마켓Command>
    {
        public Create마켓CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<마켓> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create마켓Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update마켓CommandServerHandlr : CommandServerCenterHandlr<Update마켓DTO, 마켓>, IRequestHandler<Update마켓Command>
    {
        public Update마켓CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<마켓> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update마켓Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete마켓CommandServerHandlr : CommandServerCenterHandlr<Delete마켓DTO, 마켓>, IRequestHandler<Delete마켓Command>
    {
        public Delete마켓CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<마켓> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete마켓Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
