using CommunityToolkit.Mvvm.ComponentModel;
using WarehouseCommon.APIService;
using 창고Common.DTO.입고상품;

namespace 창고FrontCommon.ViewModel
{
    public class 입고상품ViewModel : ObservableObject
    {
        private readonly 입고상품APIService _입고상품APIService;

        public 입고상품ViewModel(입고상품APIService 입고상품APIService)
        {
            _입고상품APIService = 입고상품APIService;
        }

        public async Task<List<Read입고상품DTO>> GetAll입고상품()
        {
            return await _입고상품APIService.GetAll입고상품();
        }

        public async Task<Read입고상품DTO> Get입고상품ById(string id)
        {
            return await _입고상품APIService.Get입고상품ById(id);
        }

        public async Task<Read입고상품DTO> Create입고상품(Create입고상품DTO 입고상품)
        {
            return await _입고상품APIService.Create입고상품(입고상품);
        }

        public async Task Update입고상품(string id, Update입고상품DTO updated입고상품)
        {
            await _입고상품APIService.Update입고상품(id, updated입고상품);
        }

        public async Task Delete입고상품(string id)
        {
            await _입고상품APIService.Delete입고상품(id);
        }

        public async Task<List<Read입고상품DTO>> Get입고상품By창고Id(string 창고Id)
        {
            return await _입고상품APIService.Get입고상품By창고Id(창고Id);
        }

        public async Task<List<Read입고상품DTO>> Get입고상품By창고상품Id(string 창고상품Id)
        {
            return await _입고상품APIService.Get입고상품By창고상품Id(창고상품Id);
        }
    }
}
