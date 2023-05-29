using MediatR;
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

        public CreateOrderCommandHandler()
        {

        }
        public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var Order = new Order
            {
                Name = command.Name,
                Quantity = command.Quantity
            };

            //_context.Orders.Add(Order);
            //await _context.SaveChangesAsync();
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
