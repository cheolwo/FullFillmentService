using CommunityToolkit.Mvvm.ComponentModel;
using 해양수산부.API.For산지조합창고;

namespace 수협FrontCommon.ViewModel.Sample
{
    public class 산지조합창고ViewModel : ObservableObject
    {
        private readonly 산지조합창고API _산지조합창고API;

        private List<Item> _items = new();
        public List<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public 산지조합창고ViewModel(산지조합창고API 산지조합창고API)
        {
            _산지조합창고API = 산지조합창고API;
        }

        public async Task Load산지조합창고정보()
        {
            산지조합창고정보 response = await _산지조합창고API.Get산지조합창고정보();

            if (response != null && response.ResponseJson != null && response.ResponseJson.Body != null)
            {
                Items = response.ResponseJson.Body.Item;
            }
        }
    }
}
