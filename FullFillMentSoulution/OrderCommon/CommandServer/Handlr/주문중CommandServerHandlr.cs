using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 주문Common.Command;
using 주문Common.DTO.주문대기;
using 주문Common.DTO.주문중;
using 주문Common.GateWay;
using 주문Common.Model;
namespace 주문Common.CommandServer.Handlr
{
    public class Create주문중CommandServerHandlr : CommandServerStatusHandlr<Create주문중DTO, 주문중>, IRequestHandler<Create주문중Command>
    {
        public Create주문중CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문중> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create주문중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문중CommandServerHandlr : CommandServerStatusHandlr<Update주문중DTO, 주문중>, IRequestHandler<Update주문중Command>
    {
        public Update주문중CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문중> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update주문중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문중CommandServerHandlr : CommandServerStatusHandlr<Delete주문중DTO, 주문중>, IRequestHandler<Delete주문중Command>
    {
        public Delete주문중CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문중> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete주문중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
