using CommunityToolkit.Mvvm.ComponentModel;
using KoreaCommon.Fish.해양수산부.For품목별물류센터재고현황;

namespace 수협FrontCommon.ViewModel.Sample
{
    public class 품목별물류센터재고현황ViewModel : ObservableObject
    {
        private readonly 품목별물류센터재고현황API _품목별물류센터재고현황API;

        private List<Item> _items = new();
        public List<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public 품목별물류센터재고현황ViewModel(품목별물류센터재고현황API 품목별물류센터재고현황API)
        {
            _품목별물류센터재고현황API = 품목별물류센터재고현황API;
        }

        public async Task Load품목별물류센터재고현황정보()
        {
            품목별물류센터재고현황정보 response = await _품목별물류센터재고현황API.Get품목별물류센터재고현황정보();

            if (response != null && response.ResponseJson != null && response.ResponseJson.Body != null)
            {
                Items = response.ResponseJson.Body.Item;
            }
        }
    }
}
