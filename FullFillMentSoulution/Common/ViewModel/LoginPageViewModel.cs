using Common.Actor;
using Common.DTO;
using Common.ViewService;
using FrontCommon.Actor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Common.ViewModel
{
    public class LoginPageViewModel : ActorWebPageViewModel
    {
        public LoginPageViewModel(IConfiguration configuration, IWebHostEnvironment webHostEnvironment,
            ActorCommandContext commandContext, ActorQueryContext queryContext, ITokenStorage tokenStoage) : base(configuration, webHostEnvironment, commandContext, queryContext, tokenStoage)
        {
        }
        public virtual async Task Login(LoginModel loginModel)
        {
            var response = await _actorCommandContext.Set<LoginModel>().PostAsync(loginModel);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(token))
                {
                    await _tokenStorage.SetToken(token);
                }
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"서버 응답: {errorMessage}");
            }
        }
    }
}
