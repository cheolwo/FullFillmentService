using CommunityToolkit.Mvvm.ComponentModel;
using OrderCommon.Services.API;
using System.Collections.ObjectModel;
using 주문Common.DTO.판매자;

namespace 주문FrontCommon.ViewModels
{
    public class 판매자ViewModel : ObservableObject
    {
        private readonly 판매자APIService _판매자APIService;

        public ObservableCollection<Read판매자DTO> 판매자List { get; set; }

        public 판매자ViewModel(판매자APIService 판매자APIService)
        {
            _판매자APIService = 판매자APIService;
            판매자List = new ObservableCollection<Read판매자DTO>();
        }

        public async Task<Read판매자DTO> Create판매자(Create판매자DTO 판매자)
        {
            return await _판매자APIService.Create판매자(판매자);
        }

        public async Task Update판매자(string id, Update판매자DTO updated판매자)
        {
            await _판매자APIService.Update판매자(id, updated판매자);
        }

        public async Task Delete판매자(string id)
        {
            await _판매자APIService.Delete판매자(id);
        }

        public async Task<Read판매자DTO> Get판매자ById(string id)
        {
            return await _판매자APIService.Get판매자ById(id);
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith판매자상품(string id)
        {
            return await _판매자APIService.Get판매자ByIdWith판매자상품(id);
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith주문(string id)
        {
            return await _판매자APIService.Get판매자ByIdWith주문(id);
        }

        public async Task<Read판매자DTO> Get판매자ByIdWithRelatedData(string id)
        {
            return await _판매자APIService.Get판매자ByIdWithRelatedData(id);
        }

        public async Task<List<Read판매자DTO>> GetAll판매자With판매자상품()
        {
            return await _판매자APIService.GetAll판매자With판매자상품();
        }

        public async Task<List<Read판매자DTO>> GetAll판매자With주문()
        {
            return await _판매자APIService.GetAll판매자With주문();
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith상품문의(string id)
        {
            return await _판매자APIService.Get판매자ByIdWith상품문의(id);
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith댓글(string id)
        {
            return await _판매자APIService.Get판매자ByIdWith댓글(id);
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith할일목록(string id)
        {
            return await _판매자APIService.Get판매자ByIdWith할일목록(id);
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith주문자구매요약(string id)
        {
            return await _판매자APIService.Get판매자ByIdWith주문자구매요약(id);
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith판매자상품판매정보요약(string id)
        {
            return await _판매자APIService.Get판매자ByIdWith판매자상품판매정보요약(id);
        }

        public async Task<Read판매자DTO> Get판매자ByIdWith판매자판매정보요약(string id)
        {
            return await _판매자APIService.Get판매자ByIdWith판매자판매정보요약(id);
        }
    }
}
