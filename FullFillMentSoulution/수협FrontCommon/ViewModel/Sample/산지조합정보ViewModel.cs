using CommunityToolkit.Mvvm.ComponentModel;
using 해양수산부.API.For산지조합;

namespace 수협FrontCommon.ViewModel.Sample
{
    public class 산지조합ViewModel : ObservableObject
    {
        private readonly 산지조합API _산지조합API;

        private List<Item> _items = new();
        public List<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public 산지조합ViewModel(산지조합API 산지조합API)
        {
            _산지조합API = 산지조합API;
        }

        public async Task Load산지조합정보()
        {
            산지조합정보 response = await _산지조합API.Get산지조합정보();

            if (response != null && response.ResponseJson != null && response.ResponseJson.Body != null)
            {
                Items = response.ResponseJson.Body.Item;
            }
        }
    }
}
