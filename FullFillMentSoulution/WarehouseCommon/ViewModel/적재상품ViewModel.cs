using CommunityToolkit.Mvvm.ComponentModel;
using WarehouseCommon.APIService;
using 창고Common.DTO.적재상품;

namespace 창고FrontCommon.ViewModel
{
    public class 적재상품ViewModel : ObservableObject
    {
        private readonly 적재상품APIService _적재상품APIService;

        public 적재상품ViewModel(적재상품APIService 적재상품APIService)
        {
            _적재상품APIService = 적재상품APIService;
        }

        public async Task<List<Read적재상품DTO>> GetAll적재상품()
        {
            return await _적재상품APIService.GetAll적재상품();
        }

        public async Task<Read적재상품DTO> Get적재상품ById(string id)
        {
            return await _적재상품APIService.Get적재상품ById(id);
        }

        public async Task<Read적재상품DTO> Create적재상품(Create적재상품DTO 적재상품)
        {
            return await _적재상품APIService.Create적재상품(적재상품);
        }

        public async Task Update적재상품(string id, Update적재상품DTO updated적재상품)
        {
            await _적재상품APIService.Update적재상품(id, updated적재상품);
        }

        public async Task Delete적재상품(string id)
        {
            await _적재상품APIService.Delete적재상품(id);
        }

        public async Task<Read적재상품DTO> Get적재상품ByIdWith출고상품(string id)
        {
            return await _적재상품APIService.Get적재상품ByIdWith출고상품(id);
        }

        public async Task<List<Read적재상품DTO>> Get적재상품By창고Id(string 창고Id)
        {
            return await _적재상품APIService.Get적재상품By창고Id(창고Id);
        }

        public async Task<List<Read적재상품DTO>> Get적재상품By창고상품Id(string 창고상품Id)
        {
            return await _적재상품APIService.Get적재상품By창고상품Id(창고상품Id);
        }

        public async Task<List<Read적재상품DTO>> Get적재상품By입고상품Id(string 입고상품Id)
        {
            return await _적재상품APIService.Get적재상품By입고상품Id(입고상품Id);
        }
    }
}
