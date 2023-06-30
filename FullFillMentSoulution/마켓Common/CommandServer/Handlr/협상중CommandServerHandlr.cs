using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 마켓Common.CommandServer.Handlr
{
    public class Create협상중CommandServerHandlr : CommandServerStatusHandlr<Create협상중DTO, 협상중>, IRequestHandler<Create협상중Command>
    {
        public Create협상중CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상중> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Create협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Update협상중CommandServerHandlr : CommandServerStatusHandlr<Update협상중DTO, 협상중>, IRequestHandler<Update협상중Command>
    {
        public Update협상중CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상중> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Update협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class Delete협상중CommandServerHandlr : CommandServerStatusHandlr<Delete협상중DTO, 협상중>, IRequestHandler<Delete협상중Command>
    {
        public Delete협상중CommandServerHandlr(
            마켓GateWayCommandContext gateContext, EntityRepository<협상중> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService,
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public Task Handle(Delete협상중Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
