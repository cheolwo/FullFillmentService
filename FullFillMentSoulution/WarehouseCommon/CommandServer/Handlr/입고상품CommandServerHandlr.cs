using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 창고Common.CreateCommand;
using 창고Common.DTO.입고상품;
using 창고Common.GateWay;

namespace 창고Common.CommandServer.Handlr
{
    public class Create입고상품CommandServerHandlr : CommandServerStatusHandlr<Create입고상품DTO, 입고상품>, IRequestHandler<Create입고상품Command>
    {
        public Create입고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<입고상품> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update입고상품CommandServerHandlr : CommandServerStatusHandlr<Update입고상품DTO, 입고상품>, IRequestHandler<Update입고상품Command>
    {
        public Update입고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<입고상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete입고상품CommandServerHandlr : CommandServerStatusHandlr<Delete입고상품DTO, 입고상품>, IRequestHandler<Delete입고상품Command>
    {
        public Delete입고상품CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<입고상품> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete입고상품Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
