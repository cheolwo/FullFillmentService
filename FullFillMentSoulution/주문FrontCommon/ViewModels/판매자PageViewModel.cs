using CommunityToolkit.Mvvm.ComponentModel;
using OrderCommon.Services.API;
using 주문Common.DTO.판매자;

namespace 주문FrontCommon.ViewModels
{
    public class 판매자PageViewModel : ObservableObject
    {
        private readonly 판매자APIService _판매자APIService;

        public 판매자PageViewModel(판매자APIService 판매자APIService)
        {
            _판매자APIService = 판매자APIService;
        }

        private List<Read판매자DTO> _판매자List;
        public List<Read판매자DTO> 판매자List
        {
            get { return _판매자List; }
            set { SetProperty(ref _판매자List, value); }
        }

        //public async Task Load판매자()
        //{
        //    판매자List = await _판매자APIService.GetAll판매자();
        //}

        //public async Task<Read판매자DTO> Get판매자ById(string id)
        //{
        //    return await _판매자APIService.Get판매자ById(id);
        //}

        //public async Task<List<Read판매자상품DTO>> Get판매자상품들By판매자Id(string id)
        //{
        //    return await _판매자APIService.Get판매자상품들By판매자Id(id);
        //}

        //public async Task<List<Read주문DTO>> Get주문된것들By판매자Id(string id)
        //{
        //    return await _판매자APIService.Get주문된것들By판매자Id(id);
        //}

        //public async Task<Read판매자DTO> Create판매자(Create판매자DTO 판매자)
        //{
        //    return await _판매자APIService.Create판매자(판매자);
        //}

        //public async Task<Read판매자DTO> Update판매자(string id, Update판매자DTO updated판매자)
        //{
        //    return await _판매자APIService.Update판매자(id, updated판매자);
        //}

        //public async Task<bool> Delete판매자(string id)
        //{
        //    return await _판매자APIService.Delete판매자(id);
        //}
    }
}
