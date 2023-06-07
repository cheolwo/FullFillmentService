using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Fish.해양수산부.For위판장별위탁판매현황;

namespace 수협FrontCommon.ViewModel.Sample
{
    public class 위판장별위탁판매현황ViewModel : ObservableObject
    {
        private readonly 위판장별위탁판매현황API _위판장별위탁판매현황API;

        private List<Item> _items = new();
        public List<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public 위판장별위탁판매현황ViewModel(위판장별위탁판매현황API 위판장별위탁판매현황API)
        {
            _위판장별위탁판매현황API = 위판장별위탁판매현황API;
        }

        public async Task Load위판장별위탁판매현황정보()
        {
            위판장별위탁판매현황정보 response = await _위판장별위탁판매현황API.Get위판장별위탁판매현황정보();

            if (response != null && response.ResponseJson != null && response.ResponseJson.Body != null)
            {
                Items = response.ResponseJson.Body.Item;
            }
        }
    }
}
