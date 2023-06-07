using CommunityToolkit.Mvvm.ComponentModel;
using OrderCommon.Services.API;
using 주문Common.DTO.주문;
namespace 주문FrontCommon.ViewModels
{
    public class 주문ViewModel : ObservableObject
    {
        private readonly 주문APIService _주문APIService;

        public 주문ViewModel(주문APIService 주문APIService)
        {
            _주문APIService = 주문APIService;
        }

        private List<Read주문DTO> _주문List;
        public List<Read주문DTO> 주문List
        {
            get { return _주문List; }
            set { SetProperty(ref _주문List, value); }
        }

        public async Task Load주문()
        {
            주문List = await _주문APIService.GetAll주문();
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

        public async Task<List<Read주문DTO>> Get주문ByPriceAbove(double price)
        {
            return await _주문APIService.Get주문ByPriceAbove(price);
        }

        public async Task<List<Read주문DTO>> Get주문ByPriceBelow(double price)
        {
            return await _주문APIService.Get주문ByPriceBelow(price);
        }

        public async Task<List<Read주문DTO>> Get주문ByPriceInRange(double minPrice, double maxPrice)
        {
            return await _주문APIService.Get주문ByPriceInRange(minPrice, maxPrice);
        }
}
