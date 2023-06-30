using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 주문Common.Command;
using 주문Common.DTO.주문상품;
using 주문Common.GateWay;
using 주문Common.Model;
namespace 주문Common.CommandServer.Handlr
{
    public class Create주문상품CommandServerHandlr : CommandServerCommodityHandlr<Create주문상품DTO, 주문상품>, IRequestHandler<Create주문상품Command>
    {
        public Create주문상품CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문상품> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create주문상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문상품CommandServerHandlr : CommandServerCommodityHandlr<Update주문상품DTO, 주문상품>, IRequestHandler<Update주문상품Command>
    {
        public Update주문상품CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update주문상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문상품CommandServerHandlr : CommandServerCommodityHandlr<Delete주문상품DTO, 주문상품>, IRequestHandler<Delete주문상품Command>
    {
        public Delete주문상품CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete주문상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
