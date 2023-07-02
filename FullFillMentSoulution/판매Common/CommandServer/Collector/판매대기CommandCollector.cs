using Common.CommandServer.Collector;
using Common.ForCommand;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Quartz;
using 판매Common.Command;
using 판매Common.DTO;
using 판매Common.GateWay;

namespace 판매Common.CommandServer.Collector
{
    public class Create판매대기CommandCollector : CommandServerCollector<Create판매대기DTO>, IJob
    {
        public Create판매대기CommandCollector(판매GateWayCommandContext context, CommandStorage commandStorage, 
            IConfiguration configuration, IWebHostEnvironment webHostEnvironment) : base(context, commandStorage, configuration, webHostEnvironment)
        {
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var StringCommands = await Deque(queueName);
            foreach(var command in StringCommands)
            {
                IEvent Command = JsonConvert.DeserializeObject<Create판매자Command>(command);
                await Store(Command);
            }
        }
    }
}
