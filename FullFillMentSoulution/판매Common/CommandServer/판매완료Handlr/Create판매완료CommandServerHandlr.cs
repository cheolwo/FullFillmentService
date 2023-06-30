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

namespace 판매Common.CommandServer.판매완료Handlr
{
    public class Create판매완료CommandServerHandlr : CommandServerStatusHandlr<Create판매완료DTO, 판매완료>, IRequestHandler<Create판매완료Command>
    {
        public Create판매완료CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매완료> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create판매완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매완료CommandServerHandlr : CommandServerStatusHandlr<Update판매완료DTO, 판매완료>, IRequestHandler<Update판매완료Command>
    {
        public Update판매완료CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매완료> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update판매완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매완료CommandServerHandlr : CommandServerStatusHandlr<Delete판매완료DTO, 판매완료>, IRequestHandler<Delete판매완료Command>
    {
        public Delete판매완료CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매완료> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete판매완료Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
