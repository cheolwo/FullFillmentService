using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 창고Common.Command;
using 창고Common.DTO.창고상품;
using 창고Common.GateWay;

namespace 창고Common.CommandServer.Handlr
{
    public class Create창고상품CommandServerHandlr : CommandServerCommodityHandlr<Create창고상품DTO, 창고상품>, IRequestHandler<Create창고상품Command>
    {
        public Create창고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<창고상품> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update창고상품CommandServerHandlr : CommandServerCommodityHandlr<Update창고상품DTO, 창고상품>, IRequestHandler<Update창고상품Command>
    {
        public Update창고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<창고상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete창고상품CommandServerHandlr : CommandServerCommodityHandlr<Delete창고상품DTO, 창고상품>, IRequestHandler<Delete창고상품Command>
    {
        public Delete창고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<창고상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete창고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
