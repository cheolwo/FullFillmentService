using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Services;
using 수협Common.DTO;

namespace 수협FrontCommon.ViewModel
{
    public class 수산품별재고현황ViewModel : ObservableObject
    {
        private readonly 수산품별재고현황APIService _service;
        private List<Read수산품별재고현황DTO> _수산품별재고현황List;
        private Read수산품별재고현황DTO _selected수산품별재고현황;

        public List<Read수산품별재고현황DTO> 수산품별재고현황List
        {
            get { return _수산품별재고현황List; }
            set { SetProperty(ref _수산품별재고현황List, value); }
        }

        public Read수산품별재고현황DTO Selected수산품별재고현황
        {
            get { return _selected수산품별재고현황; }
            set { SetProperty(ref _selected수산품별재고현황, value); }
        }

        public 수산품별재고현황ViewModel(수산품별재고현황APIService service)
        {
            _service = service;
        }

        public async Task Load수산품별재고현황()
        {
            수산품별재고현황List = await _service.GetAll수산품별재고현황Async();
        }

        public async Task<List<Read수산품별재고현황DTO>> Get수산품별재고현황By창고번호(string 창고번호)
        {
            return await _service.Get수산품별재고현황By창고번호Async(창고번호);
        }

        public async Task<Read수산품별재고현황DTO> Get수산품별재고현황ById(string id)
        {
            return await _service.Get수산품별재고현황ByIdAsync(id);
        }

        public async Task<Read수산품별재고현황DTO> Create수산품별재고현황(Create수산품별재고현황DTO 수산품별재고현황)
        {
            return await _service.Create수산품별재고현황Async(수산품별재고현황);
        }

        public async Task Update수산품별재고현황(string id, Update수산품별재고현황DTO updated수산품별재고현황)
        {
            await _service.Update수산품별재고현황Async(id, updated수산품별재고현황);
        }

        public async Task Delete수산품별재고현황(string id)
        {
            await _service.Delete수산품별재고현황Async(id);
        }
    }

}
