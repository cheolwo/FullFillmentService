using Common.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace 마켓Common.ViewModel.Web
{
    public class 마켓WebViewModel : WebViewModel
    {
        public 마켓WebViewModel(ILogger<WebViewModel> logger, IConfiguration configuration, IJSRuntime jsRuntime) : 
            base(logger, configuration, jsRuntime)
        {
        }
    }
    
}
