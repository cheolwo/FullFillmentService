using AutoMapper;
using Common.Cache;
using Common.GateWay;
using Common.QueryServer;
using Microsoft.AspNetCore.Hosting;
using Quartz;
using 판매Common.DTO.DetailDTO;
using 판매Common.Model;

namespace 판매Common.QueryServer.Handlr
{
    public class 판매중QueryServerHandlr : QueryServerStatusHandlr<판매중CudDTO, 판매중, 판매자>, IJob

    {
        public 판매중QueryServerHandlr(ICommandServerConfiguringService commandServerConfiguringService, 
            IWebHostEnvironment webHostEnvironment, IQueSelectedService queSelectedService, 
            IMapper mapper, 
            CenterMemoryModule centerMemoryModule, GateWayQueryContext gateContext) 
            : base(commandServerConfiguringService, webHostEnvironment, queSelectedService, mapper, centerMemoryModule, gateContext)
        {
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var queName = GetQueNameFromCommandServer(_webHostEnvironment, ServerSubject.판매);
            var command = await Deque(queName);
            await Handle(command);
        }
    }
}
