using Common.DTO;
using Common.Extensions;
using Common.ForCommand;
using Common.GateWay;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Quartz;
using Quartz.Impl.AdoJobStore.Common;

namespace Common.CommandServer.Collector
{
    /// <summary>
    /// 1. Deque 단계
    /// 2. Command를 동일한 형식 Command로 역직렬화 단계
    /// 3. 역질려화 Command를 List<IEvent>에 저장하는 단계
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CommandServerCollector<T> where T : CudDTO
    {
        protected readonly GateWayCommandContext _context;
        protected readonly ICollectEvent _commandStorage;
        protected readonly IConfiguration _configuration;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly string queueName;
        public CommandServerCollector(GateWayCommandContext context, ICollectEvent commandStorage,
            IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _commandStorage = commandStorage;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            queueName = GetQueNameFromGateWayServer();
        }
        private string GetQueNameFromGateWayServer()
        {
            var gateWayServer = _configuration.GetSection("GateWayServer").Value;
            if (gateWayServer == null) { throw new ArgumentNullException(nameof(gateWayServer)); }
            var queName = gateWayServer.CreateQueueName<T>(_webHostEnvironment.ContentRootPath);
            return queName;
        }
        protected async Task Store(IEvent @event)
        {
            await _commandStorage.EnqueAsync(@event);
        }

        protected async Task<IEnumerable<string>> Deque(string queueName)
        {
            var commands = await _context.Set<T>().DequeueAll(queueName);
            return commands;
        }

    }
    public interface ICollectEvent
    {
        Task EnqueAsync(IEvent @event);
    }
    public interface IHandleEvent
    {
        Task<IEvent> DequeAsync();
    }
    public class CommandStorage : ICollectEvent, IHandleEvent
    {
        private readonly SortedSet<IEvent> Events = new SortedSet<IEvent>(Comparer<IEvent>.Create((e1, e2)
            => e1.GetTime().CompareTo(e2.GetTime())));
        private readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

        public async Task EnqueAsync(IEvent @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            await Semaphore.WaitAsync();

            try
            {
                Events.Add(@event);
            }
            finally
            {
                Semaphore.Release();
            }
        }

        public async Task<IEvent> DequeAsync()
        {
            await Semaphore.WaitAsync();

            try
            {
                if (Events.Count == 0)
                    return null;

                var firstEvent = Events.Min;
                Events.Remove(firstEvent);
                return firstEvent;
            }
            finally
            {
                Semaphore.Release();
            }
        }
    }

}
