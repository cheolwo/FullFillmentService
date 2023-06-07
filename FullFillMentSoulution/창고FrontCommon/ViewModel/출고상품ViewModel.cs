using CommunityToolkit.Mvvm.ComponentModel;
using WarehouseCommon.APIService;
using 창고Common.DTO.출고상품;

namespace 창고FrontCommon.ViewModel
{
    public class 출고상품ViewModel : ObservableObject
    {
        private readonly 출고상품APIService _출고상품APIService;

        public 출고상품ViewModel(출고상품APIService 출고상품APIService)
        {
            _출고상품APIService = 출고상품APIService;
        }

        public async Task<List<Read출고상품DTO>> GetAll출고상품()
        {
            return await _출고상품APIService.GetAll출고상품();
        }

        public async Task<Read출고상품DTO> Get출고상품ById(string id)
        {
            return await _출고상품APIService.Get출고상품ById(id);
        }

        public async Task<Read출고상품DTO> Create출고상품(Create출고상품DTO 출고상품)
        {
            return await _출고상품APIService.Create출고상품(출고상품);
        }

        public async Task<Read출고상품DTO> Update출고상품(string id, Update출고상품DTO updated출고상품)
        {
            return await _출고상품APIService.Update출고상품(id, updated출고상품);
        }

        public async Task<bool> Delete출고상품(string id)
        {
            return await _출고상품APIService.Delete출고상품(id);
        }

        public async Task<List<Read출고상품DTO>> Get출고상품ListBy창고Id(string 창고Id)
        {
            return await _출고상품APIService.Get출고상품ListBy창고Id(창고Id);
        }

        public async Task<List<Read출고상품DTO>> Get출고상품ListBy창고상품Id(string 창고상품Id)
        {
            return await _출고상품APIService.Get출고상품ListBy창고상품Id(창고상품Id);
        }

        public async Task<List<Read출고상품DTO>> Get출고상품ListBy입고상품Id(string 입고상품Id)
        {
            return await _출고상품APIService.Get출고상품ListBy입고상품Id(입고상품Id);
        }

        public async Task<List<Read출고상품DTO>> Get출고상품ListBy적재상품Id(string 적재상품Id)
        {
            return await _출고상품APIService.Get출고상품ListBy적재상품Id(적재상품Id);
        }
    }
}
