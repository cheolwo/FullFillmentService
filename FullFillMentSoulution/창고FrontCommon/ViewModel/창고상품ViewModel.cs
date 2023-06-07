using CommunityToolkit.Mvvm.ComponentModel;
using WarehouseCommon.APIService;
using 창고Common.DTO.창고상품;

namespace 창고FrontCommon.ViewModel
{
    public class 창고상품ViewModel : ObservableObject
{
    private readonly 창고상품APIService _창고상품APIService;

    public 창고상품ViewModel(창고상품APIService 창고상품APIService)
    {
        _창고상품APIService = 창고상품APIService;
    }

    public async Task<List<Read창고상품DTO>> GetAll창고상품()
    {
        return await _창고상품APIService.GetAll창고상품();
    }

    public async Task<Read창고상품DTO> Get창고상품ById(string id)
    {
        return await _창고상품APIService.Get창고상품ById(id);
    }

    public async Task<Read창고상품DTO> Create창고상품(Create창고상품DTO 창고상품)
    {
        return await _창고상품APIService.Create창고상품(창고상품);
    }

    public async Task<Read창고상품DTO> Update창고상품(string id, Update창고상품DTO updated창고상품)
    {
        return await _창고상품APIService.Update창고상품(id, updated창고상품);
    }

    public async Task<bool> Delete창고상품(string id)
    {
        return await _창고상품APIService.Delete창고상품(id);
    }

    public async Task<Read창고상품DTO> Get창고상품ByIdWith입고상품(string id)
    {
        return await _창고상품APIService.Get창고상품ByIdWith입고상품(id);
    }

    public async Task<Read창고상품DTO> Get창고상품ByIdWith적재상품(string id)
    {
        return await _창고상품APIService.Get창고상품ByIdWith적재상품(id);
    }

    public async Task<Read창고상품DTO> Get창고상품ByIdWith출고상품(string id)
    {
        return await _창고상품APIService.Get창고상품ByIdWith출고상품(id);
    }

    public async Task<List<Read창고상품DTO>> Get창고상품ListBy창고Id(string 창고Id)
    {
        return await _창고상품APIService.Get창고상품ListBy창고Id(창고Id);
    }
}

}
