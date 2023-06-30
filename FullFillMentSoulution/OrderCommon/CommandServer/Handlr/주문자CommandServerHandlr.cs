using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 주문Common.Command;
using 주문Common.DTO.주문대기;
using 주문Common.DTO.주문자;
using 주문Common.GateWay;
using 주문Common.Model;

namespace 주문Common.CommandServer.Handlr
{
    public class Create주문자CommandServerHandlr : CommandServerCenterHandlr<Create주문자DTO, 주문자>, IRequestHandler<Create주문자Command>
    {
        public Create주문자CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문자> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create주문자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문자CommandServerHandlr : CommandServerCenterHandlr<Update주문자DTO, 주문자>, IRequestHandler<Update주문자Command>
    {
        public Update주문자CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문자> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update주문자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문자CommandServerHandlr : CommandServerCenterHandlr<Delete주문자DTO, 주문자>, IRequestHandler<Delete주문자Command>
    {
        public Delete주문자CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문자> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete주문자Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
