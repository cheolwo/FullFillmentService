using CommunityToolkit.Mvvm.ComponentModel;
using WarehouseCommon.APIService;
using 창고Common.DTO.창고;

namespace 창고FrontCommon.ViewModel
{
    public class 창고ViewModel : ObservableObject
{
    private readonly 창고APIService _창고APIService;

    public 창고ViewModel(창고APIService 창고APIService)
    {
        _창고APIService = 창고APIService;
    }

    public async Task<List<Read창고DTO>> GetAll창고()
    {
        return await _창고APIService.GetAll창고();
    }

    public async Task<Read창고DTO> Get창고ById(string id)
    {
        return await _창고APIService.Get창고ById(id);
    }

    public async Task<Read창고DTO> Create창고(Create창고DTO 창고)
    {
        return await _창고APIService.Create창고(창고);
    }

    public async Task<Read창고DTO> Update창고(string id, Update창고DTO updated창고)
    {
        return await _창고APIService.Update창고(id, updated창고);
    }

    public async Task<bool> Delete창고(string id)
    {
        return await _창고APIService.Delete창고(id);
    }

    public async Task<Read창고DTO> Get창고ByAddress(string address)
    {
        return await _창고APIService.Get창고ByAddress(address);
    }

    public async Task<Read창고DTO> Get창고ByEmail(string email)
    {
        return await _창고APIService.Get창고ByEmail(email);
    }

    public async Task<Read창고DTO> Get창고ByFaxNumber(string faxNumber)
    {
        return await _창고APIService.Get창고ByFaxNumber(faxNumber);
    }

    public async Task<Read창고DTO> Get창고ByPhoneNumber(string phoneNumber)
    {
        return await _창고APIService.Get창고ByPhoneNumber(phoneNumber);
    }

    public async Task<Read창고DTO> Get창고ByCode(string code)
    {
        return await _창고APIService.Get창고ByCode(code);
    }

    public async Task<Read창고DTO> Get창고ByName(string name)
    {
        return await _창고APIService.Get창고ByName(name);
    }

    public async Task<Read창고DTO> Get창고ByIdWith창고상품(string id)
    {
        return await _창고APIService.Get창고ByIdWith창고상품(id);
    }

    public async Task<Read창고DTO> Get창고ByIdWith입고상품(string id)
    {
        return await _창고APIService.Get창고ByIdWith입고상품(id);
    }

    public async Task<Read창고DTO> Get창고ByIdWith적재상품(string id)
    {
        return await _창고APIService.Get창고ByIdWith적재상품(id);
    }

    public async Task<Read창고DTO> Get창고ByIdWith출고상품(string id)
    {
        return await _창고APIService.Get창고ByIdWith출고상품(id);
    }
}

}
