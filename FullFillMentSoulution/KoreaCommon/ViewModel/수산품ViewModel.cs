using CommunityToolkit.Mvvm.ComponentModel;
using 수협Common.APIServices;

namespace 수협Common.ViewModel
{
    public class 수산품ViewModel : ObservableObject
    {
        private readonly 수산품APIQueryService _수산품APIService;
        public 수산품ViewModel(수산품APIQueryService 수산품APIService)
        {
            _수산품APIService = 수산품APIService;
        }
    }
}
