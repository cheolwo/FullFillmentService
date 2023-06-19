using MediatR;
using Newtonsoft.Json;
using StackExchange.Redis;
using 주문Common.DTO.For주문;

namespace 수협비즈니스APIGateWay.Handlr
{
    public class Create주문Command : IRequest
    {
        public Create주문DTO? Dto { get; set; }
    }
    public class Update주문Command : IRequest
    {
        public Update주문DTO? Dto { get; set; }
    }
    public class Delete주문Command : IRequest
    {
        public Delete주문DTO? Dto { get; set; }
    }
    public class Create주문CommandHandler : IRequestHandler<Create주문Command>
    {
        private readonly ISubscriber _redisSubscriber;
        public Create주문CommandHandler(ISubscriber redisSubscriber)
        {
            _redisSubscriber = redisSubscriber; 
        }
        public Task Handle(Create주문Command request, CancellationToken cancellationToken)
        {
            var channel = typeof(Create주문Command).Name;
            var message = JsonConvert.SerializeObject(request.Dto);

            _redisSubscriber.Publish(channel, message);

            return Task.CompletedTask;
        }
    }

    public class Update주문CommandHandler : IRequestHandler<Update주문Command>
    {
        private readonly ISubscriber _redisSubscriber;

        public Update주문CommandHandler(ISubscriber redisSubscriber)
        {
            _redisSubscriber = redisSubscriber;
        }

        public Task Handle(Update주문Command request, CancellationToken cancellationToken)
        {
            var channel = typeof(Update주문Command).Name;
            var message = JsonConvert.SerializeObject(request.Dto);

            _redisSubscriber.Publish(channel, message);

            return Task.CompletedTask;
        }
    }

    public class Delete주문CommandHandler : IRequestHandler<Delete주문Command>
    {
        private readonly ISubscriber _redisSubscriber;

        public Delete주문CommandHandler(ISubscriber redisSubscriber)
        {
            _redisSubscriber = redisSubscriber;
        }

        public Task Handle(Delete주문Command request, CancellationToken cancellationToken)
        {
            var channel = typeof(Delete주문Command).Name;
            var message = JsonConvert.SerializeObject(request.Dto);

            _redisSubscriber.Publish(channel, message);

            return Task.CompletedTask;
        }
    }
}
