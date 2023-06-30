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

namespace 판매Common.CommandServer.판매자상품Handlr
{
    public class Create판매자상품CommandServerHandlr : CommandServerCommodityHandlr<Create판매자상품DTO, 판매자상품>, IRequestHandler<Create판매자상품Command>
    {
        public Create판매자상품CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매자상품> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create판매자상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매자상품CommandServerHandlr : CommandServerCommodityHandlr<Update판매자상품DTO, 판매자상품>, IRequestHandler<Update판매자상품Command>
    {
        public Update판매자상품CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매자상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update판매자상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매자상품CommandServerHandlr : CommandServerCommodityHandlr<Delete판매자상품DTO, 판매자상품>, IRequestHandler<Delete판매자상품Command>
    {
        public Delete판매자상품CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매자상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete판매자상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
