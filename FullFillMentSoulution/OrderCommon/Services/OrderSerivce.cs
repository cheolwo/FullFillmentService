using MVVMToolkit.Blazor.SampleApp.ViewModels;

namespace OrderCommon.Services
{
    public interface IOrderService
    {
        Task PlaceOrder(OrderRequestModel requestModel);
    }

    public class OrderService : IOrderService
    {
        public Task PlaceOrder(OrderRequestModel requestModel)
        {
            // 주문 처리 로직 구현

            return Task.CompletedTask;
        }
    }
}
