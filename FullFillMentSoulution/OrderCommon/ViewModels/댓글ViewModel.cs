using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using 주문Common.APIService;
using 주문Common.DTO.댓글;

namespace 주문Common.ViewModels
{
    public class 댓글ViewModel : ObservableObject
    {
        private readonly 댓글APIService _댓글APIService;

        public ObservableCollection<Read댓글DTO> 댓글List { get; set; }

        public 댓글ViewModel(댓글APIService 댓글APIService)
        {
            _댓글APIService = 댓글APIService;
            댓글List = new ObservableCollection<Read댓글DTO>();
        }

        public async Task Load댓글By판매자상품Id(string 판매자상품Id)
        {
            var 댓글DTOs = await _댓글APIService.Get댓글By판매자상품Id(판매자상품Id);
            댓글List.Clear();
            foreach (var 댓글DTO in 댓글DTOs)
            {
                댓글List.Add(댓글DTO);
            }
        }

        public async Task Load댓글By주문자Id(string 주문자Id)
        {
            var 댓글DTOs = await _댓글APIService.Get댓글By주문자Id(주문자Id);
            댓글List.Clear();
            foreach (var 댓글DTO in 댓글DTOs)
            {
                댓글List.Add(댓글DTO);
            }
        }

        public async Task Load댓글By판매자상품IdWith주문자(string 판매자상품Id)
        {
            var 댓글DTOs = await _댓글APIService.Get댓글By판매자상품IdWith주문자(판매자상품Id);
            댓글List.Clear();
            foreach (var 댓글DTO in 댓글DTOs)
            {
                댓글List.Add(댓글DTO);
            }
        }

        public async Task Load댓글By주문자IdWith판매자상품(string 주문자Id)
        {
            var 댓글DTOs = await _댓글APIService.Get댓글By주문자IdWith판매자상품(주문자Id);
            댓글List.Clear();
            foreach (var 댓글DTO in 댓글DTOs)
            {
                댓글List.Add(댓글DTO);
            }
        }

        public async Task Load댓글By판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            var 댓글DTOs = await _댓글APIService.Get댓글By판매자상품IdWith주문자And판매자(판매자상품Id);
            댓글List.Clear();
            foreach (var 댓글DTO in 댓글DTOs)
            {
                댓글List.Add(댓글DTO);
            }
        }

        public async Task Load댓글By주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            var 댓글DTOs = await _댓글APIService.Get댓글By주문자IdWith판매자상품And주문자(주문자Id);
            댓글List.Clear();
            foreach (var 댓글DTO in 댓글DTOs)
            {
                댓글List.Add(댓글DTO);
            }
        }

        public async Task<Read댓글DTO> Create댓글(Create댓글DTO 댓글DTO)
        {
            return await _댓글APIService.Create댓글(댓글DTO);
        }

        public async Task Update댓글(string id, Update댓글DTO updated댓글DTO)
        {
            await _댓글APIService.Update댓글(id, updated댓글DTO);
        }

        public async Task Delete댓글(string id)
        {
            await _댓글APIService.Delete댓글(id);
        }
    }
}
