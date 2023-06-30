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
namespace 판매Common.CommandServer.판매자Handlr
{
    public class Create판매자CommandServerHandlr : CommandServerCenterHandlr<Create판매자DTO, 판매자>, IRequestHandler<Create판매자Command>
    {
        public Create판매자CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매자> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create판매자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매자CommandServerHandlr : CommandServerCenterHandlr<Update판매자DTO, 판매자>, IRequestHandler<Update판매자Command>
    {
        public Update판매자CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매자> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update판매자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매자CommandServerHandlr : CommandServerCenterHandlr<Delete판매자DTO, 판매자>, IRequestHandler<Delete판매자Command>
    {
        public Delete판매자CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매자> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete판매자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
