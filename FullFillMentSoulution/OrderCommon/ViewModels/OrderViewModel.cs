using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrderCommon;
using OrderCommon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMToolkit.Blazor.SampleApp.ViewModels
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
    }
    public class OrderRequestModel
    {
        public string OrderName { get; set; }
        public int OrderQuantity { get; set; }
    }
}
