//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MVVMToolkit.Blazor.SampleApp.ViewModels;

//[Route("api/orders")]
//[ApiController]
//public class OrderController : ControllerBase
//{
//    private readonly OrderDbContext _dbContext;
//    private readonly IEventQueue _eventQueue;

//    public OrderController(OrderDbContext dbContext, IEventQueue eventQueue)
//    {
//        _dbContext = dbContext;
//        _eventQueue = eventQueue;   
//    }
//    // POST: api/orders
//    [HttpPost]
//    public async Task<ActionResult<Order>> CreateOrder(OrderRequestModel orderRequest)
//    {
//        var createOrderCommand = new CreateOrderCommand
//        {
//            Name = orderRequest.OrderName,
//            Quantity = orderRequest.OrderQuantity
            
//        };
//        await _eventQueue.EnqueueEventAsync(createOrderCommand);

//        return Ok();
//    }

//    // GET: api/orders
//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
//    {
//        return await _dbContext.Orders.ToListAsync();
//    }

//    // GET: api/orders/{orderId}
//    [HttpGet("{orderId}")]
//    public async Task<ActionResult<Order>> GetOrder(int orderId)
//    {
//        var order = await _dbContext.Orders.FindAsync(orderId);

//        if (order == null)
//        {
//            return NotFound();
//        }

//        return order;
//    }


//    // PUT: api/orders/{orderId}
//    [HttpPut("{orderId}")]
//    public async Task<IActionResult> UpdateOrder(int orderId, Order order)
//    {
//        if (orderId != order.OrderId)
//        {
//            return BadRequest();
//        }

//        _dbContext.Entry(order).State = EntityState.Modified;

//        try
//        {
//            await _dbContext.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!OrderExists(orderId))
//            {
//                return NotFound();
//            }
//            else
//            {
//                throw;
//            }
//        }

//        return NoContent();
//    }

//    // DELETE: api/orders/{orderId}
//    [HttpDelete("{orderId}")]
//    public async Task<IActionResult> DeleteOrder(int orderId)
//    {
//        var order = await _dbContext.Orders.FindAsync(orderId);

//        if (order == null)
//        {
//            return NotFound();
//        }

//        _dbContext.Orders.Remove(order);
//        await _dbContext.SaveChangesAsync();

//        return NoContent();
//    }

//    private bool OrderExists(int orderId)
//    {
//        return _dbContext.Orders.Any(o => o.OrderId == orderId);
//    }
//}
