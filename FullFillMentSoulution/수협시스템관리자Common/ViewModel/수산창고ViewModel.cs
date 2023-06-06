using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Model;
using KoreaCommon.Services;

namespace 수협시스템관리자Common.ViewModel
{
    public class 수산창고ViewModel : ObservableObject
    {
        private readonly 수산창고Service _service;
        private List<수산창고> _수산창고List;
        private List<수산창고> _수산창고With수산품목종류List;

        public List<수산창고> 수산창고List
        {
            get { return _수산창고List; }
            set
            {
                _수산창고List = value;
                OnPropertyChanged();
            }
        }

        public List<수산창고> 수산창고With수산품목종류List
        {
            get { return _수산창고With수산품목종류List; }
            set
            {
                _수산창고With수산품목종류List = value;
                OnPropertyChanged();
            }
        }

        public 수산창고ViewModel(수산창고Service service)
        {
            _service = service;
            수산창고List = new List<수산창고>();
            수산창고With수산품목종류List = new List<수산창고>();
        }

        public async Task Load수산창고Async()
        {
            수산창고List = await _service.GetAll수산창고Async();
        }

        public async Task Load수산창고With수산품목종류Async()
        {
            수산창고With수산품목종류List = await _service.Get수산창고With수산품목종류Async();
        }
    }

}
