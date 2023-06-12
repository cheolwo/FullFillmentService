using CommunityToolkit.Mvvm.ComponentModel;
using OrderCommon.Services.API;
using System.Collections.ObjectModel;
using 주문Common.DTO.For주문;
namespace 주문FrontCommon.ViewModels
{
    public class 주문ViewModel : ObservableObject
    {
        private readonly 주문APIService _주문APIService;

        public ObservableCollection<Read주문DTO> 주문List { get; set; }

        public 주문ViewModel(주문APIService 주문APIService)
        {
            _주문APIService = 주문APIService;
            주문List = new ObservableCollection<Read주문DTO>();
        }

        public async Task LoadAll주문()
        {
            var 주문List = await _주문APIService.GetAll주문();
            주문List.Clear();
            foreach (var 주문 in 주문List)
            {
                주문List.Add(주문);
            }
        }

        public async Task<Read주문DTO> Get주문ById(string id)
        {
            return await _주문APIService.Get주문ById(id);
        }

        public async Task<Read주문DTO> Create주문(Create주문DTO 주문)
        {
            return await _주문APIService.Create주문(주문);
        }

        public async Task<Read주문DTO> Update주문(string id, Update주문DTO updated주문)
        {
            return await _주문APIService.Update주문(id, updated주문);
        }

        public async Task<bool> Delete주문(string id)
        {
            return await _주문APIService.Delete주문(id);
        }

        public async Task<Read주문DTO> Get주문ByIdWith판매자상품(string id)
        {
            return await _주문APIService.Get주문ByIdWith판매자상품(id);
        }

        public async Task<Read주문DTO> Get주문ByIdWith주문자(string id)
        {
            return await _주문APIService.Get주문ByIdWith주문자(id);
        }

        public async Task<Read주문DTO> Get주문ByIdWith판매자(string id)
        {
            return await _주문APIService.Get주문ByIdWith판매자(id);
        }

        public async Task<Read주문DTO> Get주문ByIdWith판매자And판매자상품(string id)
        {
            return await _주문APIService.Get주문ByIdWith판매자And판매자상품(id);
        }

        public async Task<Read주문DTO> Get주문ByIdWith판매자And판매자상품And주문자(string id)
        {
            return await _주문APIService.Get주문ByIdWith판매자And판매자상품And주문자(id);
        }

        public async Task Load주문ByPriceAbove(double price)
        {
            var 주문List = await _주문APIService.Get주문ByPriceAbove(price);
            주문List.Clear();
            foreach (var 주문 in 주문List)
            {
                주문List.Add(주문);
            }
        }

        public async Task Load주문ByPriceBelow(double price)
        {
            var 주문List = await _주문APIService.Get주문ByPriceBelow(price);
            주문List.Clear();
            foreach (var 주문 in 주문List)
            {
                주문List.Add(주문);
            }
        }

        public async Task Load주문ByPriceInRange(double minPrice, double maxPrice)
        {
            var 주문List = await _주문APIService.Get주문ByPriceInRange(minPrice, maxPrice);
            주문List.Clear();
            foreach (var 주문 in 주문List)
            {
                주문List.Add(주문);
            }
        }
    }
}
