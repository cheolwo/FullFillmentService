using Common.CommandServer.Collector;
using MediatR;
using Quartz;

namespace Common.CommandServer.Mediator
{
    public class CommandServerMediator : IJob
    {
        private readonly IMediator _mediator;
        private readonly IHandleEvent _handleEvent;

        public CommandServerMediator(IMediator mediator, IHandleEvent handleEvent)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _handleEvent = handleEvent ?? throw new ArgumentNullException(nameof(handleEvent));
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var commandEvent = await _handleEvent.DequeAsync();

            while (commandEvent != null)
            {
                commandEvent.Execute(_mediator);
                commandEvent = await _handleEvent.DequeAsync();
            }
        }
    }
}
