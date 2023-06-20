using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using 주문Common.DTO.판매자상품;

namespace 주문FrontCommon.ViewModels
{
    public class 판매자상품ViewModel : ObservableObject
    {
        private readonly 판매자상품APIService _판매자상품APIService;

        public ObservableCollection<Read판매자상품DTO> 판매자상품List { get; set; }

        public 판매자상품ViewModel(판매자상품APIService 판매자상품APIService)
        {
            _판매자상품APIService = 판매자상품APIService;
            판매자상품List = new ObservableCollection<Read판매자상품DTO>();
        }

        public async Task<Read판매자상품DTO> Create판매자상품(Create판매자상품DTO 판매자상품)
        {
            return await _판매자상품APIService.Create판매자상품Async(판매자상품);
        }

        public async Task Update판매자상품(string id, Update판매자상품DTO updated판매자상품)
        {
            await _판매자상품APIService.Update판매자상품Async(id, updated판매자상품);
        }

        public async Task Delete판매자상품(string id)
        {
            await _판매자상품APIService.Delete판매자상품Async(id);
        }

        public async Task<Read판매자상품DTO> Get판매자상품ById(string id)
        {
            return await _판매자상품APIService.Get판매자상품ByIdAsync(id);
        }

        public async Task<Read판매자상품DTO> Get판매자상품With주문(string id)
        {
            return await _판매자상품APIService.Get판매자상품With주문Async(id);
        }

        public async Task<Read판매자상품DTO> Get판매자상품With판매자(string id)
        {
            return await _판매자상품APIService.Get판매자상품With판매자Async(id);
        }

        public async Task<Read판매자상품DTO> Get판매자상품With판매자And주문(string id)
        {
            return await _판매자상품APIService.Get판매자상품With판매자And주문Async(id);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceAbove(double price)
        {
            return await _판매자상품APIService.Get판매자상품ByPriceAboveAsync(price);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceBelow(double price)
        {
            return await _판매자상품APIService.Get판매자상품ByPriceBelowAsync(price);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품ByPriceInRange(double minPrice, double maxPrice)
        {
            return await _판매자상품APIService.Get판매자상품ByPriceInRangeAsync(minPrice, maxPrice);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateBefore(string date)
        {
            return await _판매자상품APIService.Get판매자상품BySaleDateBeforeAsync(date);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateAfter(string date)
        {
            return await _판매자상품APIService.Get판매자상품BySaleDateAfterAsync(date);
        }

        public async Task<List<Read판매자상품DTO>> Get판매자상품BySaleDateRange(string startDate, string endDate)
        {
            return await _판매자상품APIService.Get판매자상품BySaleDateRangeAsync(startDate, endDate);
        }
    }

}
 