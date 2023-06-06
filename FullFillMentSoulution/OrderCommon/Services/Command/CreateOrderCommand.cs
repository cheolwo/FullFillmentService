using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderCommon.Model;
using OrderCommon.Services;
using 주문Common.Model;

namespace 주문Common.Services.Command
{
    // Commands
    public class Create주문Command : IRequest<int>, IEvent
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    // Queries
    public class Get주문Query : IRequest<주문>
    {
        public int Id { get; set; }
    }

    public class Create주문CommandHandler : IRequestHandler<Create주문Command, int>
    {
        private readonly IServiceProvider _serviceProvider;

        public Create주문CommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<int> Handle(Create주문Command command, CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<주문DbContext>();

                var 주문 = new 주문
                {
                    Name = command.Name,
                    Quantity = command.Quantity.ToString()
                };

                dbContext.Set<주문>().Add(주문);
                await dbContext.SaveChangesAsync();
            }

            Console.WriteLine("스케줄러에 의해 처리되었습니다.");
            Console.WriteLine(command.Name);

            return 1;
        }
    }

    public class Get주문QueryHandler : IRequestHandler<Get주문Query, 주문>
    {
        private readonly 주문DbContext _context;

        public Get주문QueryHandler(주문DbContext context)
        {
            _context = context;
        }

        public async Task<주문?> Handle(Get주문Query query, CancellationToken cancellationToken)
        {
            var 주문 = await _context.Set<주문>().FindAsync(query.Id);
            return 주문;
        }
    }
}
