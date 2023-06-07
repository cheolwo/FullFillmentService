using System.Text;
using System.Text.Json;
using MediatR;
using Quartz;
using 주문Common;
using 주문Common.Command;
using 주문Common.Event;

namespace OrderCommon.Services
{
    public interface IOrderService
    {
        Task PlaceOrder(OrderRequestModel requestModel);
        Task RandomPlaceOrder();
    }

    public class OrderService : IOrderService
    {
        private HttpClient _httpClient = new();
        public OrderService()
        {
        }

        public async Task PlaceOrder(OrderRequestModel requestModel)
        {
            string requestJson = JsonSerializer.Serialize(requestModel);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7007/api/orders", content);

            response.EnsureSuccessStatusCode();
        }
        public async Task RandomPlaceOrder()
        {
            // 주문을 처리하기 위한 로직을 수행
            var requestModel = new OrderRequestModel
            {
                OrderName = GenerateRandomOrderName(),
                OrderQuantity = GenerateRandomOrderQuantity()
            };

            string requestJson = JsonSerializer.Serialize(requestModel);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7007/api/orders", content);

            response.EnsureSuccessStatusCode();
        }
        private string GenerateRandomOrderName()
        {
            // OrderName을 랜덤하게 생성하는 로직
            // 예시: 6글자로 구성된 랜덤 문자열 생성
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var randomOrderName = new string(Enumerable.Repeat(chars, 6)
                                                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomOrderName;
        }

        private int GenerateRandomOrderQuantity()
        {
            // OrderQuantity를 랜덤하게 생성하는 로직
            // 예시: 1부터 100 사이의 랜덤 정수 생성
            var random = new Random();
            var randomOrderQuantity = random.Next(1, 101);
            return randomOrderQuantity;
        }
    }
    public class OrderJob : IJob
    {
        private readonly IOrderService _orderService;

        public OrderJob(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // 주문을 처리하기 위한 로직을 수행
            var requestModel = new OrderRequestModel
            {
                OrderName = GenerateRandomOrderName(),
                OrderQuantity = GenerateRandomOrderQuantity()
            };

            await _orderService.PlaceOrder(requestModel);
        }
        private string GenerateRandomOrderName()
        {
            // OrderName을 랜덤하게 생성하는 로직
            // 예시: 6글자로 구성된 랜덤 문자열 생성
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var randomOrderName = new string(Enumerable.Repeat(chars, 6)
                                                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomOrderName;
        }

        private int GenerateRandomOrderQuantity()
        {
            // OrderQuantity를 랜덤하게 생성하는 로직
            // 예시: 1부터 100 사이의 랜덤 정수 생성
            var random = new Random();
            var randomOrderQuantity = random.Next(1, 101);
            return randomOrderQuantity;
        }
    }
    public class ProcessOrderJob : IJob
    {
        private readonly IEventQueue _eventQueue;
        private readonly IMediator _mediator;

        public ProcessOrderJob(IEventQueue eventQueue, IMediator mediator)
        {
            _eventQueue = eventQueue;
            _mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var @event = await _eventQueue.DequeueEventAsync();
            while (@event != null)
            {
                await ProcessEventAndAddToDbContextAsync(@event);
                @event = await _eventQueue.DequeueEventAsync();
            }
        }

        private async Task ProcessEventAndAddToDbContextAsync(IEvent @event)
        {
            if (@event is Create주문Command create주문Command)
            {
                var result = await _mediator.Send(create주문Command);
            }
            else
            {
                // 다른 이벤트 타입에 대한 처리 로직 추가
            }
        }
    }
}
