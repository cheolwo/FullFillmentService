using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using 주문Common.APIService;
using 주문Common.DTO.주문자구매요약;

namespace 주문Common.ViewModels
{
    public class 주문자구매요약ViewModel : ObservableObject
    {
        private readonly 주문자구매요약APIService _주문자구매요약APIService;

        public ObservableCollection<Read주문자구매요약DTO> 주문자구매요약List { get; set; }

        public 주문자구매요약ViewModel(주문자구매요약APIService 주문자구매요약APIService)
        {
            _주문자구매요약APIService = 주문자구매요약APIService;
            주문자구매요약List = new ObservableCollection<Read주문자구매요약DTO>();
        }

        public async Task<Read주문자구매요약DTO> Create주문자구매요약(Create주문자구매요약DTO 주문자구매요약)
        {
            return await _주문자구매요약APIService.Create주문자구매요약(주문자구매요약);
        }

        public async Task Update주문자구매요약(string id, Update주문자구매요약DTO updated주문자구매요약)
        {
            await _주문자구매요약APIService.Update주문자구매요약(id, updated주문자구매요약);
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ById(string id)
        {
            return await _주문자구매요약APIService.Get주문자구매요약ById(id);
        }

        public async Task Delete주문자구매요약(string id)
        {
            await _주문자구매요약APIService.Delete주문자구매요약(id);
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자상품판매정보요약(string id)
        {
            return await _주문자구매요약APIService.Get주문자구매요약ByIdWith판매자상품판매정보요약(id);
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자(string id)
        {
            return await _주문자구매요약APIService.Get주문자구매요약ByIdWith판매자(id);
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith판매자상품(string id)
        {
            return await _주문자구매요약APIService.Get주문자구매요약ByIdWith판매자상품(id);
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWith주문자(string id)
        {
            return await _주문자구매요약APIService.Get주문자구매요약ByIdWith주문자(id);
        }

        public async Task<Read주문자구매요약DTO> Get주문자구매요약ByIdWithRelatedData(string id)
        {
            return await _주문자구매요약APIService.Get주문자구매요약ByIdWithRelatedData(id);
        }

        public async Task<List<Read주문자구매요약DTO>> Get주문자구매요약By판매자Id(string 판매자Id)
        {
            return await _주문자구매요약APIService.Get주문자구매요약By판매자Id(판매자Id);
        }

        public async Task<List<Read주문자구매요약DTO>> Get주문자구매요약By구매일시(DateTime 구매일시)
        {
            return await _주문자구매요약APIService.Get주문자구매요약By구매일시(구매일시);
        }
    }
}
