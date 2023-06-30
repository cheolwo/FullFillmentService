using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 판매Common.Command;
using 판매Common.DTO;
using 판매Common.GateWay;
using 판매Common.Model;

namespace 판매Common.CommandServer.판매대기Handlr
{
    public class Create판매대기CommandServerHandlr : CommandServerStatusHandlr<Create판매대기DTO, 판매대기>, IRequestHandler<Create판매대기Command>
    {
        public Create판매대기CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매대기> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create판매대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매대기CommandServerHandlr : CommandServerStatusHandlr<Update판매대기DTO, 판매대기>, IRequestHandler<Update판매대기Command>
    {
        public Update판매대기CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매대기> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update판매대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매대기CommandServerHandlr : CommandServerStatusHandlr<Delete판매대기DTO, 판매대기>, IRequestHandler<Delete판매대기Command>
    {
        public Delete판매대기CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매대기> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete판매대기Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
