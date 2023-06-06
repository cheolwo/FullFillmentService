using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Model;
using KoreaCommon.Services;

namespace 수협시스템관리자Common.ViewModel
{
    public class 수산협동조합ViewModel : ObservableObject
    {
        private readonly 수산협동조합APIService _service;
        private List<수산협동조합> _수산협동조합List;

        public List<수산협동조합> 수산협동조합List
        {
            get { return _수산협동조합List; }
            set
            {
                _수산협동조합List = value;
                OnPropertyChanged();
            }
        }

        public 수산협동조합ViewModel(수산협동조합APIService service)
        {
            _service = service;
            수산협동조합List = new List<수산협동조합>();
        }

        public async Task Load수산협동조합Async()
        {
            수산협동조합List = await _service.GetAll수산협동조합Async();
        }
    }
}
