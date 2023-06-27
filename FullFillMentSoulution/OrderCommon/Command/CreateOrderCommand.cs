using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderCommon.Model;
using 주문Common.Event;

namespace 주문Common.Command
{
    // Commands
    public class Create주문Command : IRequest<int>, IEvent
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

}
