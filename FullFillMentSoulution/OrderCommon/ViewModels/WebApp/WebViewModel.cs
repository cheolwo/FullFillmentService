using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace 주문FrontCommon.ViewModels.WebApp
{
    public class BaseViewModel : ObservableObject
    {
        private readonly ILogger _logger;

        public BaseViewModel(ILogger<BaseViewModel> logger)
        {
            _logger = logger;
        }

        // 로깅을 위한 메서드나 속성 등을 추가할 수 있습니다.
    }
    public class WebViewModel : BaseViewModel
    {
        private readonly IConfiguration _configuration;
        private readonly IJSRuntime _jsRuntime;

        public WebViewModel(ILogger<WebViewModel> logger, IConfiguration configuration, IJSRuntime jsRuntime)
            : base(logger)
        {
            _configuration = configuration;
            _jsRuntime = jsRuntime;
        }
    }
}
