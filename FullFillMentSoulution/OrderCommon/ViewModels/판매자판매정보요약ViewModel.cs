using CommunityToolkit.Mvvm.ComponentModel;
using 주문Common.APIService;
using 주문Common.DTO.할일목록;

namespace 주문Common.ViewModels
{
    public class 할일목록ViewModel : ObservableObject
    {
        private readonly 할일목록APIService _할일목록APIService;

        public 할일목록ViewModel(할일목록APIService 할일목록APIService)
        {
            _할일목록APIService = 할일목록APIService;
        }

        public async Task<HttpResponseMessage> Create할일목록(Create할일목록DTO 할일목록)
        {
            return await _할일목록APIService.Create할일목록Async(할일목록);
        }

        public async Task<HttpResponseMessage> Update할일목록(string id, Update할일목록DTO updated할일목록)
        {
            return await _할일목록APIService.Update할일목록Async(id, updated할일목록);
        }

        public async Task<HttpResponseMessage> Delete할일목록(string id)
        {
            return await _할일목록APIService.Delete할일목록Async(id);
        }

        public async Task<Read할일목록DTO> Get할일목록ById(string id)
        {
            return await _할일목록APIService.Get할일목록ByIdAsync(id);
        }

        public async Task<List<Read할일목록DTO>> Get할일목록By판매자IdAnd주문Id(string 판매자Id, string 주문Id)
        {
            return await _할일목록APIService.Get할일목록By판매자IdAnd주문IdAsync(판매자Id, 주문Id);
        }

        public async Task<List<Read할일목록DTO>> Get할일목록By판매자IdWithPriorityDescending(string 판매자Id)
        {
            return await _할일목록APIService.Get할일목록By판매자IdWithPriorityDescendingAsync(판매자Id);
        }

        public async Task<List<Read할일목록DTO>> Get할일목록By주문IdAndStatus(string 주문Id, string 상태)
        {
            return await _할일목록APIService.Get할일목록By주문IdAndStatusAsync(주문Id, 상태);
        }

        public async Task<List<Read할일목록DTO>> Get할일목록By판매자IdAndStatus(string 판매자Id, string 상태)
        {
            return await _할일목록APIService.Get할일목록By판매자IdAndStatusAsync(판매자Id, 상태);
        }
    }
}
