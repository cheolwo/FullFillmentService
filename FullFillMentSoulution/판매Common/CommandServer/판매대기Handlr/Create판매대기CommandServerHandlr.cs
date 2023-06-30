using AutoMapper;
using Common.CommandServer;
using Common.GateWay;
using Common.Model.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Quartz;
using 판매Common.DTO;
using 판매Common.Model;

namespace 판매Common.CommandServer.판매대기Handlr
{
    public class Create판매대기CommandServerHandlr : CommandServerStatusHandlr<Create판매대기DTO, 판매대기>
    {
        public Create판매대기CommandServerHandlr(
            GateWayCommandContext gateContext, EntityRepository<판매대기> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService,
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }
    }
  
}
