using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MVVMToolkit.Blazor.SampleApp.ViewModels;
using OrderCommon.Model;

namespace OrderCommon.Services.Command
{
    // Commands
    public class CreateOrderCommand : IRequest<int>, IEvent
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    // Queries
    public class GetOrderQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IServiceProvider _serviceProvider;

        public CreateOrderCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();

                var Order = new Order
                {
                    Name = command.Name,
                    Quantity = command.Quantity
                };

                dbContext.Orders.Add(Order);
                await dbContext.SaveChangesAsync();
            }

            Console.WriteLine("스케줄러에 의해 처리되었습니다.");
            Console.WriteLine(command.Name);

            return 1;
        }
    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order>
    {
        private readonly OrderDbContext _context;

        public GetOrderQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {
            var Order = await _context.Orders.FindAsync(query.Id);
            return Order;
        }
    }
}
