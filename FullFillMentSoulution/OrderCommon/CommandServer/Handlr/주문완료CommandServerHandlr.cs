using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 주문Common.Command;
using 주문Common.DTO.주문대기;
using 주문Common.DTO.주문완료;
using 주문Common.GateWay;
using 주문Common.Model;

namespace 주문Common.CommandServer.Handlr
{
    public class Create주문완료CommandServerHandlr : CommandServerStatusHandlr<Create주문완료DTO, 주문완료>, IRequestHandler<Create주문완료Command>
    {
        public Create주문완료CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문완료> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create주문완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update주문완료CommandServerHandlr : CommandServerStatusHandlr<Update주문완료DTO, 주문완료>, IRequestHandler<Update주문완료Command>
    {
        public Update주문완료CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문완료> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update주문완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete주문완료CommandServerHandlr : CommandServerStatusHandlr<Delete주문완료DTO, 주문완료>, IRequestHandler<Delete주문완료Command>
    {
        public Delete주문완료CommandServerHandlr(
            주문GateWayCommandContext gateContext, EntityRepository<주문완료> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete주문완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
