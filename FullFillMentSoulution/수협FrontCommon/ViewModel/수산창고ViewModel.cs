using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Services;
using 수협Common.DTO;

namespace 수협FrontCommon.ViewModel
{
    public class 수산창고ViewModel : ObservableObject
    {
        private readonly 수산창고APIService _service;
        private List<Read수산창고DTO> _수산창고List;
        private Read수산창고DTO _selected수산창고;

        public List<Read수산창고DTO> 수산창고List
        {
            get { return _수산창고List; }
            set { SetProperty(ref _수산창고List, value); }
        }

        public Read수산창고DTO Selected수산창고
        {
            get { return _selected수산창고; }
            set { SetProperty(ref _selected수산창고, value); }
        }

        public 수산창고ViewModel(수산창고APIService service)
        {
            _service = service;
        }

        public async Task Load수산창고()
        {
            수산창고List = await _service.GetAll수산창고Async();
        }

        public async Task Load수산창고With수산품목종류()
        {
            수산창고List = await _service.Get수산창고With수산품목종류Async();
        }

        public async Task<Read수산창고DTO> Get수산창고ById(string id)
        {
            return await _service.Get수산창고ByIdAsync(id);
        }

        public async Task<Read수산창고DTO> Get수산창고With수산품별재고현황(string 수산창고Id)
        {
            return await _service.Get수산창고With수산품별재고현황Async(수산창고Id);
        }

        public async Task<Read수산창고DTO> Create수산창고(Create수산창고DTO 수산창고)
        {
            return await _service.Create수산창고Async(수산창고);
        }

        public async Task<Read수산창고DTO> Update수산창고(string id, Update수산창고DTO updated수산창고)
        {
            return await _service.Update수산창고Async(id, updated수산창고);
        }

        public async Task Delete수산창고(string id)
        {
            await _service.Delete수산창고Async(id);
        }
    }

}
