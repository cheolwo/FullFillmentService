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

namespace 판매Common.CommandServer.판매중Handlr
{
    public class Create판매중CommandServerHandlr : CommandServerStatusHandlr<Create판매중DTO, 판매중>, IRequestHandler<Create판매중Command>
    {
        public Create판매중CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매중> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create판매중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update판매중CommandServerHandlr : CommandServerStatusHandlr<Update판매중DTO, 판매중>, IRequestHandler<Update판매중Command>
    {
        public Update판매중CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매중> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update판매중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete판매중CommandServerHandlr : CommandServerStatusHandlr<Delete판매중DTO, 판매중>, IRequestHandler<Delete판매중Command>
    {
        public Delete판매중CommandServerHandlr(
            판매GateWayCommandContext gateContext, EntityRepository<판매중> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete판매중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
