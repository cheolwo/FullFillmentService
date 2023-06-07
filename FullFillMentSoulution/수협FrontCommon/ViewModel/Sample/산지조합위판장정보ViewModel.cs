using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Fish.수협산지조합위판장.For산지조합위판장정보;

namespace 수협FrontCommon.ViewModel.Sample
{
    public class 산지조합위판장ViewModel : ObservableObject
    {
        private readonly 산지조합위판장API _산지조합위판장정보API;

        private List<Item> _items = new();
        public List<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public 산지조합위판장ViewModel(산지조합위판장API 산지조합위판장정보API)
        {
            _산지조합위판장정보API = 산지조합위판장정보API;
        }

        public async Task Load산지조합위판장정보()
        {
            산지조합위판장정보 response = await _산지조합위판장정보API.Get산지조합위판장정보();

            if (response != null && response.ResponseJson != null && response.ResponseJson.Body != null)
            {
                Items = response.ResponseJson.Body.Item;
            }
        }
    }
}
