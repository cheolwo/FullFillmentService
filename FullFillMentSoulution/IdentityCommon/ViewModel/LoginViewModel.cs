using CommunityToolkit.Mvvm.ComponentModel;
using 계정Common.DTO;
using 계정Common.Service;

namespace 수협Common.ViewModel.수협.Login
{
    public class LoginViewModel : ObservableObject
    {
        protected LoginModel _loginModel;
        private string _token = "";

        private bool _isLogin;
        public bool IsLogin
        {
            get => _isLogin;
            set => _isLogin = value;
        }
        public string Token
        {
            get => _token;
            set => SetProperty(ref _token, value);
        }
        public string Username
        {
            get => _loginModel.Username;
            set => _loginModel.Username = value;
        }

        public string Password
        {
            get => _loginModel.Password;
            set => _loginModel.Password = value;
        }

        public bool RememberMe
        {
            get => _loginModel.RememberMe;
            set => _loginModel.RememberMe = value;
        }
        public LoginViewModel()
        {
            _loginModel = new LoginModel();
        }
    }
    public class WebLoginViewModel : LoginViewModel
    {
        private readonly AuthenticationService _authenticationService;

        public WebLoginViewModel(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public virtual async Task ExecuteLoginCommand()
        {
            await _authenticationService.Login(_loginModel);
        }
    }
}
