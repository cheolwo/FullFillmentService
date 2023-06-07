using CommunityToolkit.Mvvm.ComponentModel;
using 해양수산부.API.For조합창고품목별재고현황;

namespace 수협FrontCommon.ViewModel.Sample
{
    public class 조합창고품목별재고현황ViewModel : ObservableObject
    {
        private readonly 조합창고품목별재고현황API _조합창고품목별재고현황API;

        private List<Item> _items = new();
        public List<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public 조합창고품목별재고현황ViewModel(조합창고품목별재고현황API 조합창고품목별재고현황API)
        {
            _조합창고품목별재고현황API = 조합창고품목별재고현황API;
        }

        public async Task Load조합창고품목별재고현황정보()
        {
            조합창고품목별재고현황정보 response = await _조합창고품목별재고현황API.Get조합창고품목별재고현황정보();

            if (response != null && response.ResponseJson != null && response.ResponseJson.Body != null)
            {
                Items = response.ResponseJson.Body.Item;
            }
        }
    }
}
