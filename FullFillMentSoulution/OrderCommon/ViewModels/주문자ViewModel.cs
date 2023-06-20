using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using 주문Common.DTO.For주문;
using 주문Common.DTO.댓글;
using 주문Common.DTO.상품문의;
using 주문Common.DTO.주문자;

namespace 주문FrontCommon.ViewModels
{
    public class 주문자ViewModel : ObservableObject
    {
        private readonly 주문자ApiService _주문자ApiService;

        public ObservableCollection<Read주문자DTO> 주문자List { get; set; }

        public 주문자ViewModel(주문자ApiService 주문자ApiService)
        {
            _주문자ApiService = 주문자ApiService;
            주문자List = new ObservableCollection<Read주문자DTO>();
        }

        public async Task LoadAll주문자()
        {
            var 주문자List = await _주문자ApiService.GetAll주문자();
            주문자List.Clear();
            foreach (var 주문자 in 주문자List)
            {
                주문자List.Add(주문자);
            }
        }

        public async Task<Read주문자DTO> Get주문자ById(string id)
        {
            return await _주문자ApiService.Get주문자ById(id);
        }

        public async Task<Read주문자DTO> Create주문자(Create주문자DTO 주문자)
        {
            return await _주문자ApiService.Create주문자(주문자);
        }

        public async Task Update주문자(string id, Update주문자DTO updated주문자)
        {
            await _주문자ApiService.Update주문자(id, updated주문자);
        }

        public async Task Delete주문자(string id)
        {
            await _주문자ApiService.Delete주문자(id);
        }

        public async Task<List<Read주문DTO>> GetOrdersByCustomerId(string id)
        {
            return await _주문자ApiService.GetOrdersByCustomerId(id);
        }

        public async Task<List<Read댓글DTO>> GetCommentsByCustomerId(string id)
        {
            return await _주문자ApiService.GetCommentsByCustomerId(id);
        }

        public async Task<List<Read상품문의DTO>> GetInquiriesByCustomerId(string id)
        {
            return await _주문자ApiService.GetInquiriesByCustomerId(id);
        }
    }
}
