using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using OrderCommon.Services.Command;

namespace OrderCommon.Services
{
    public interface IEvent
    {
        // 이벤트에 대한 추가적인 속성이 필요한 경우 정의할 수 있음
    }
    public interface IEventQueue
    {
        Task EnqueueEventAsync(IEvent @event);
        Task<IEvent> DequeueEventAsync();
        Task ProcessEventsAsync();
    }

    public class EventQueue : IEventQueue
    {
        private readonly Queue<IEvent> _eventQueue;

        public EventQueue()
        {
            _eventQueue = new Queue<IEvent>();
        }

        public Task EnqueueEventAsync(IEvent @event)
        {
            _eventQueue.Enqueue(@event);
            foreach(var value in _eventQueue)
            {
                if (@event is CreateOrderCommand createOrderCommand)
                {
                    Console.WriteLine(createOrderCommand.Name);
                }
            }
            return Task.CompletedTask;
        }

        public Task<IEvent> DequeueEventAsync()
        {
            if (_eventQueue.Count > 0)
            {
                return Task.FromResult(_eventQueue.Dequeue());
            }

            return Task.FromResult<IEvent>(null);
        }

        public async Task ProcessEventsAsync()
        {
            while (_eventQueue.Count > 0)
            {
                var @event = await DequeueEventAsync();
                await ProcessEventAsync(@event);
            }
        }

        private Task ProcessEventAsync(IEvent @event)
        {
            // 이벤트 처리 로직
            Console.WriteLine("Processing event: " + @event);

            return Task.CompletedTask;
        }
    }
}