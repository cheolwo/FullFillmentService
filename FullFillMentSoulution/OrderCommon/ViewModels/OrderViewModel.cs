using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrderCommon.Services;
using 주문Common;

namespace 주문FrontCommon.ViewModels
{
    public class OrderViewModel : ObservableRecipient
    {
        private readonly IOrderService _orderService;

        public OrderViewModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private string _orderName;
        public string OrderName
        {
            get => _orderName;
            set => SetProperty(ref _orderName, value);
        }

        private int _orderQuantity;
        public int OrderQuantity
        {
            get => _orderQuantity;
            set => SetProperty(ref _orderQuantity, value);
        }

        private bool _orderPlaced;
        public bool OrderPlaced
        {
            get => _orderPlaced;
            set => SetProperty(ref _orderPlaced, value);
        }


        public IAsyncRelayCommand PlaceOrderCommand => new AsyncRelayCommand(PlaceOrderAsync);
        public IAsyncRelayCommand RandomOrderCommnad => new AsyncRelayCommand(RandomOrderAsync);

        private async Task PlaceOrderAsync()
        {
            // 주문에 대한 RequestModel 생성
            var requestModel = new OrderRequestModel
            {
                OrderName = OrderName,
                OrderQuantity = OrderQuantity
            };

            // 주문 처리
            await _orderService.PlaceOrder(requestModel);

            // 주문 완료 후 처리할 로직 추가
            // 주문 완료 여부 속성 업데이트
            OrderPlaced = true;
        }
        private async Task RandomOrderAsync()
        {
            await _orderService.RandomPlaceOrder();
        }
    }
}
