using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 창고Common.Command;
using 창고Common.DTO.출고상품;
using 창고Common.GateWay;

namespace 창고Common.CommandServer.Handlr
{
    public class Create출고상품CommandServerHandlr : CommandServerStatusHandlr<Create출고상품DTO, 출고상품>, IRequestHandler<Create출고상품Command>
    {
        public Create출고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<출고상품> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update출고상품CommandServerHandlr : CommandServerStatusHandlr<Update출고상품DTO, 출고상품>, IRequestHandler<Update출고상품Command>
    {
        public Update출고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<출고상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete출고상품CommandServerHandlr : CommandServerStatusHandlr<Delete출고상품DTO, 출고상품>, IRequestHandler<Delete출고상품Command>
    {
        public Delete출고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<출고상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete출고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
