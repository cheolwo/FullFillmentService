using CommunityToolkit.Mvvm.ComponentModel;
using OrderCommon.Services.API;
using 주문Common.DTO.주문;
using 주문Common.DTO.주문자;

namespace 주문FrontCommon.ViewModels
{
    public class 주문자ViewModel : ObservableObject
    {
        private readonly 주문자ApiService _주문자ApiService;

        public 주문자ViewModel(주문자ApiService 주문자ApiService)
        {
            _주문자ApiService = 주문자ApiService;
        }

        private List<Read주문자DTO> _주문자List;
        public List<Read주문자DTO> 주문자List
        {
            get { return _주문자List; }
            set { SetProperty(ref _주문자List, value); }
        }

        public async Task Load주문자()
        {
            주문자List = await _주문자ApiService.GetAll주문자();
        }

        public async Task<Read주문자DTO> Get주문자ById(string id)
        {
            return await _주문자ApiService.Get주문자ById(id);
        }

        public async Task<List<Read주문DTO>> GetOrdersByCustomerId(string id)
        {
            return await _주문자ApiService.GetOrdersByCustomerId(id);
        }

        public async Task<Read주문자DTO> Create주문자(Create주문자DTO 주문자)
        {
            return await _주문자ApiService.Create주문자(주문자);
        }

        public async Task<Read주문자DTO> Update주문자(string id, Update주문자DTO updated주문자)
        {
            return await _주문자ApiService.Update주문자(id, updated주문자);
        }

        public async Task<bool> Delete주문자(string id)
        {
            return await _주문자ApiService.Delete주문자(id);
        }
    }
}
