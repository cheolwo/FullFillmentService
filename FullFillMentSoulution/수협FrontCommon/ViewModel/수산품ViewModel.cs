using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Services;
using 수협Common.DTO;

namespace 수협FrontCommon.ViewModel
{
    public class 수산품ViewModel : ObservableObject
    {
        private readonly 수산품APIService _service;
        private List<Read수산품DTO> _수산품List;
        private Read수산품DTO _selected수산품;

        public List<Read수산품DTO> 수산품List
        {
            get { return _수산품List; }
            set { SetProperty(ref _수산품List, value); }
        }

        public Read수산품DTO Selected수산품
        {
            get { return _selected수산품; }
            set { SetProperty(ref _selected수산품, value); }
        }

        public 수산품ViewModel(수산품APIService service)
        {
            _service = service;
        }

        public async Task Load수산품()
        {
            수산품List = await _service.GetAll수산품Async();
        }

        public async Task<Read수산품DTO> Get수산품ById(string id)
        {
            return await _service.Get수산품ByIdAsync(id);
        }

        public async Task<Read수산품DTO> Create수산품(Create수산품DTO 수산품)
        {
            return await _service.Create수산품Async(수산품);
        }

        public async Task<Read수산품DTO> Update수산품(string id, Update수산품DTO updated수산품)
        {
            return await _service.Update수산품Async(id, updated수산품);
        }

        public async Task Delete수산품(string id)
        {
            await _service.Delete수산품Async(id);
        }
    }

}
