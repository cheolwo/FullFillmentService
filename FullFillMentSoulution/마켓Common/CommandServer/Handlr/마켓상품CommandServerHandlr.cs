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
    public class Create마켓상품CommandServerHandlr : CommandServerCommodityHandlr<Create마켓상품DTO, 마켓상품>, IRequestHandler<Create마켓상품Command>
    {
        public Create마켓상품CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<마켓상품> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create마켓상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update마켓상품CommandServerHandlr : CommandServerCommodityHandlr<Update마켓상품DTO, 마켓상품>, IRequestHandler<Update마켓상품Command>
    {
        public Update마켓상품CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<마켓상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update마켓상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete마켓상품CommandServerHandlr : CommandServerCommodityHandlr<Delete마켓상품DTO, 마켓상품>, IRequestHandler<Delete마켓상품Command>
    {
        public Delete마켓상품CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<마켓상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete마켓상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
