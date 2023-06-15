using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using 주문Common.APIService;
using 주문Common.DTO.상품문의;

namespace 주문Common.ViewModels
{
    public class 상품문의ViewModel : ObservableObject
    {
        private readonly 상품문의APIService _상품문의APIService;

        public ObservableCollection<Read상품문의DTO> 상품문의List { get; set; }

        public 상품문의ViewModel(상품문의APIService 상품문의APIService)
        {
            _상품문의APIService = 상품문의APIService;
            상품문의List = new ObservableCollection<Read상품문의DTO>();
        }

        public async Task Load상품문의By판매자상품Id(string 판매자상품Id)
        {
            var 상품문의DTOs = await _상품문의APIService.Get상품문의By판매자상품Id(판매자상품Id);
            상품문의List.Clear();
            foreach (var 상품문의DTO in 상품문의DTOs)
            {
                상품문의List.Add(상품문의DTO);
            }
        }

        public async Task<Read상품문의DTO> Create상품문의(Create상품문의DTO 상품문의DTO)
        {
            return await _상품문의APIService.Create상품문의(상품문의DTO);
        }

        public async Task Update상품문의(string id, Update상품문의DTO updated상품문의DTO)
        {
            await _상품문의APIService.Update상품문의(id, updated상품문의DTO);
        }

        public async Task Delete상품문의(string id)
        {
            await _상품문의APIService.Delete상품문의(id);
        }

        public async Task Load상품문의By판매자상품IdWith판매자(string 판매자상품Id)
        {
            var 상품문의DTOs = await _상품문의APIService.Get상품문의By판매자상품IdWith판매자(판매자상품Id);
            상품문의List.Clear();
            foreach (var 상품문의DTO in 상품문의DTOs)
            {
                상품문의List.Add(상품문의DTO);
            }
        }

        public async Task Load상품문의By주문자Id(string 주문자Id)
        {
            var 상품문의DTOs = await _상품문의APIService.Get상품문의By주문자Id(주문자Id);
            상품문의List.Clear();
            foreach (var 상품문의DTO in 상품문의DTOs)
            {
                상품문의List.Add(상품문의DTO);
            }
        }


        public async Task Load상품문의By주문자IdWith주문자(string 주문자Id)
        {
            var 상품문의DTOs = await _상품문의APIService.Get상품문의By주문자IdWith주문자(주문자Id);
            상품문의List.Clear();
            foreach (var 상품문의DTO in 상품문의DTOs)
            {
                상품문의List.Add(상품문의DTO);
            }
        }

        public async Task Load상품문의By판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            var 상품문의DTOs = await _상품문의APIService.Get상품문의By판매자상품IdWith주문자And판매자(판매자상품Id);
            상품문의List.Clear();
            foreach (var 상품문의DTO in 상품문의DTOs)
            {
                상품문의List.Add(상품문의DTO);
            }
        }

        public async Task Load상품문의By주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            var 상품문의DTOs = await _상품문의APIService.Get상품문의By주문자IdWith판매자상품And주문자(주문자Id);
            상품문의List.Clear();
            foreach (var 상품문의DTO in 상품문의DTOs)
            {
                상품문의List.Add(상품문의DTO);
            }
        }
    }
}
