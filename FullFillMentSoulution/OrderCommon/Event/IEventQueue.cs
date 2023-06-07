using Microsoft.EntityFrameworkCore;
using 주문Common.Command;
using 주문Common.Model;

namespace 주문Common.Event
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
        private readonly object _lock;

        public EventQueue()
        {
            _eventQueue = new Queue<IEvent>();
            _lock = new object();
        }

        public Task EnqueueEventAsync(IEvent @event)
        {
            lock (_lock)
            {
                _eventQueue.Enqueue(@event);
                if (@event is Create주문Command create주문Command)
                {
                    Console.WriteLine(create주문Command.Name);
                }
            }

            return Task.CompletedTask;
        }

        public Task<IEvent> DequeueEventAsync()
        {
            lock (_lock)
            {
                if (_eventQueue.Count > 0)
                {
                    return Task.FromResult(_eventQueue.Dequeue());
                }
            }

            return Task.FromResult<IEvent>(null);
        }

        public async Task ProcessEventsAsync()
        {
            while (true)
            {
                IEvent @event;
                lock (_lock)
                {
                    if (_eventQueue.Count == 0)
                    {
                        break; // No events to process, exit the loop
                    }

                    @event = _eventQueue.Dequeue();
                }

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