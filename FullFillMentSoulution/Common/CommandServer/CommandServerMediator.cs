using Common.Extensions;
using Common.ForCommand;
using Common.GateWay;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Quartz;

namespace Common.CommandServer
{
    public abstract class CommandServerMediator 
    {
        protected readonly IMediator _mediator;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IConfiguration _configuration;
        protected readonly GateWayCommandContext _context;

        public CommandServerMediator(IMediator mediator, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, GateWayCommandContext context)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _context = context;
        }
    }
    public class 판매ServerMediator : CommandServerMediator, IJob
    {
        protected readonly ServerSubject _serverSubject;
        protected string queName;

        public 판매ServerMediator(IMediator mediator, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, GateWayCommandContext context) :
            base(mediator, webHostEnvironment, configuration, context)
        {
            _serverSubject = ServerSubject.판매;
            queName = configuration.GetSection("GateWayServer")?.Value?.CreateQueueName(webHostEnvironment.ContentRootPath, _serverSubject.ToString()) ?? throw new ArgumentNullException();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var commandJson = await _context.Dequeue(queName);
            if (!string.IsNullOrEmpty(commandJson))
            {
                CudCommand<T> command = JsonConvert.DeserializeObject<CudCommand<T>>(commandJson);
                await _mediator.Send(command);
            }
        }
    }
}
