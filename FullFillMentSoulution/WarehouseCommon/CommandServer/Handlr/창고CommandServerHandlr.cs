using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using 창고Common.Command;
using 창고Common.DTO.창고;
using 창고Common.GateWay;
namespace 창고Common.CommandServer.Handlr
{
    public class Create창고CommandServerHandlr : CommandServerCenterHandlr<Create창고DTO, 창고>, IRequestHandler<Create창고Command>
    {
        public Create창고CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<창고> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create창고Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update창고CommandServerHandlr : CommandServerCenterHandlr<Update창고DTO, 창고>, IRequestHandler<Update창고Command>
    {
        public Update창고CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<창고> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update창고Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete창고CommandServerHandlr : CommandServerCenterHandlr<Delete창고DTO, 창고>, IRequestHandler<Delete창고Command>
    {
        public Delete창고CommandServerHandlr(
            창고GateWayCommandContext gateContext, EntityRepository<창고> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete창고Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
