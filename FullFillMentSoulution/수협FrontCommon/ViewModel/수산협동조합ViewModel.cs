using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Services;
using 수협Common.DTO;

namespace 수협FrontCommon.ViewModel
{
    public class 수산협동조합ViewModel : ObservableObject
    {
        private readonly 수산협동조합APIService _service;
        private List<Read수산협동조합DTO> _수산협동조합List;
        private Read수산협동조합DTO _selected수산협동조합;

        public List<Read수산협동조합DTO> 수산협동조합List
        {
            get { return _수산협동조합List; }
            set { SetProperty(ref _수산협동조합List, value); }
        }

        public Read수산협동조합DTO Selected수산협동조합
        {
            get { return _selected수산협동조합; }
            set { SetProperty(ref _selected수산협동조합, value); }
        }

        public 수산협동조합ViewModel(수산협동조합APIService service)
        {
            _service = service;
        }

        public async Task Load수산협동조합()
        {
            수산협동조합List = await _service.GetAll수산협동조합Async();
        }

        public async Task<Read수산협동조합DTO> Get수산협동조합ById(string id)
        {
            return await _service.Get수산협동조합ByIdAsync(id);
        }

        public async Task<Read수산협동조합DTO> Get수산창고With수산품별재고현황(string 수산협동조합Id)
        {
            return await _service.Get수산창고With수산품별재고현황Async(수산협동조합Id);
        }

        public async Task<List<Read수산협동조합DTO>> GetAll수산협동조합With수산창고()
        {
            return await _service.GetAll수산협동조합With수산창고Async();
        }

        public async Task<Read수산협동조합DTO> Create수산협동조합(Create수산협동조합DTO 수산협동조합)
        {
            return await _service.Create수산협동조합Async(수산협동조합);
        }

        public async Task<Read수산협동조합DTO> Update수산협동조합(string id, Update수산협동조합DTO updated수산협동조합)
        {
            return await _service.Update수산협동조합Async(id, updated수산협동조합);
        }

        public async Task Delete수산협동조합(string id)
        {
            await _service.Delete수산협동조합Async(id);
        }
    }
}