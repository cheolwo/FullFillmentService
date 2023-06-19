using CommunityToolkit.Mvvm.ComponentModel;
using 주문Common.APIService;
using 주문Common.DTO.판매자상품판매정보요약;

namespace 주문Common.ViewModels
{
    public class 판매자상품판매정보요약ViewModel : ObservableObject
    {
        private readonly 판매자상품판매정보요약APIQueryService _판매자상품판매정보요약APIService;

        public 판매자상품판매정보요약ViewModel(판매자상품판매정보요약APIQueryService 판매자상품판매정보요약APIService)
        {
            _판매자상품판매정보요약APIService = 판매자상품판매정보요약APIService;
        }
        public async Task<Read판매자상품판매정보요약DTO> Get판매자상품판매정보요약ById(string id)
        {
            return await _판매자상품판매정보요약APIService.Get판매자상품판매정보요약ByIdAsync(id);
        }

        public async Task<List<Read판매자상품판매정보요약DTO>> Get판매자상품판매정보요약By판매자Id(string 판매자Id)
        {
            return await _판매자상품판매정보요약APIService.Get판매자상품판매정보요약By판매자IdAsync(판매자Id);
        }

        public async Task<Read판매자상품판매정보요약DTO> Get판매자상품판매정보요약ByIdWith판매자And주문자구매요약(string id)
        {
            return await _판매자상품판매정보요약APIService.Get판매자상품판매정보요약ByIdWith판매자And주문자구매요약Async(id);
        }

        public async Task<List<Read판매자상품판매정보요약DTO>> Get판매자상품판매정보요약By판매자상품Id(string 판매자상품Id)
        {
            return await _판매자상품판매정보요약APIService.Get판매자상품판매정보요약By판매자상품IdAsync(판매자상품Id);
        }
    }
}
