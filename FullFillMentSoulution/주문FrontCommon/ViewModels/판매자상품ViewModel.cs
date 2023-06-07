using CommunityToolkit.Mvvm.ComponentModel;
using OrderClient.Services;
using 주문Common.DTO.주문;
using 주문Common.DTO.판매자;
using 주문Common.DTO.판매자상품;

namespace 주문FrontCommon.ViewModels
{
    public class 판매자상품ViewModel : ObservableObject
    {
        private readonly 판매자상품APIService _판매자상품APIService;

        public 판매자상품ViewModel(판매자상품APIService 판매자상품APIService)
        {
            _판매자상품APIService = 판매자상품APIService;
        }

        private List<Read판매자상품DTO> _판매자상품List;
        public List<Read판매자상품DTO> 판매자상품List
        {
            get { return _판매자상품List; }
            set { SetProperty(ref _판매자상품List, value); }
        }

        public async Task Load판매자상품()
        {
            판매자상품List = await _판매자상품APIService.GetAll판매자상품();
        }

        public async Task<Read판매자상품DTO> Get판매자상품ById(string id)
        {
            return await _판매자상품APIService.Get판매자상품ById(id);
        }

        public async Task<Read판매자상품DTO> Create판매자상품(Create판매자상품DTO 판매자상품)
        {
            return await _판매자상품APIService.Create판매자상품(판매자상품);
        }

        public async Task<Read판매자상품DTO> Update판매자상품(string id, Update판매자상품DTO updated판매자상품)
        {
            return await _판매자상품APIService.Update판매자상품(id, updated판매자상품);
        }

        public async Task<bool> Delete판매자상품(string id)
        {
            return await _판매자상품APIService.Delete판매자상품(id);
        }

        public async Task<List<Read주문DTO>> Get주문By판매자상품Id(string id)
        {
            return await _판매자상품APIService.Get주문By판매자상품Id(id);
        }

        public async Task<Read판매자DTO> Get판매자By판매자상품Id(string id)
        {
            return await _판매자상품APIService.Get판매자By판매자상품Id(id);
        }

        public async Task<Read판매자상품DTO> Get판매자상품WithDetails(string id)
        {
            return await _판매자상품APIService.Get판매자상품WithDetails(id);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceAbove(double price)
        {
            return await _판매자상품APIService.Get판매자상품ByPriceAbove(price);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceBelow(double price)
        {
            return await _판매자상품APIService.Get판매자상품ByPriceBelow(price);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceInRange(double minPrice, double maxPrice)
        {
            return await _판매자상품APIService.Get판매자상품ByPriceInRange(minPrice, maxPrice);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateBefore(string date)
        {
            return await _판매자상품APIService.Get판매자상품BySaleDateBefore(date);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateAfter(string date)
        {
            return await _판매자상품APIService.Get판매자상품BySaleDateAfter(date);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateRange(string startDate, string endDate)
        {
            return await _판매자상품APIService.Get판매자상품BySaleDateRange(startDate, endDate);
        }
    }
}
