using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 창고Common.Command;
using 창고Common.DTO.적재상품;
using 창고Common.GateWay;

namespace 창고Common.CommandServer.Handlr
{
    public class Create적재상품CommandServerHandlr : CommandServerStatusHandlr<Create적재상품DTO, 적재상품>, IRequestHandler<Create적재상품Command>
    {
        public Create적재상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<적재상품> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update적재상품CommandServerHandlr : CommandServerStatusHandlr<Update적재상품DTO, 적재상품>, IRequestHandler<Update적재상품Command>
    {
        public Update적재상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<적재상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete적재상품CommandServerHandlr : CommandServerStatusHandlr<Delete적재상품DTO, 적재상품>, IRequestHandler<Delete적재상품Command>
    {
        public Delete적재상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<적재상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete적재상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
