using Common.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using 계정Common.Actor;

namespace 계정Common.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IActorLoginService _actorLoginService;
        private readonly IJSRuntime _jsRuntime;
        private const int _tokenRefreshThresholdSeconds = 300; // 5 minutes
        public AuthenticationService(
            AuthenticationStateProvider authenticationStateProvider,
            IActorLoginService actorLoginService,
            IJSRuntime jsRuntime)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _actorLoginService = actorLoginService;
            _jsRuntime = jsRuntime;
        }
        public async Task Login(LoginModel loginModel)
        {
            try
            {
                // 사용자 인증 요청
                var token = await _actorLoginService.Login(loginModel);
                if (!string.IsNullOrEmpty(token))
                {
                    // 토큰을 기반으로 사용자 정보를 가져옴
                    // 사용자 정보와 권한 정보를 포함하여 인증 상태 설정
                    await ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetAuthenticatedUser(token);
                }
                else
                {
                    // 로그인 실패 처리
                    throw new Exception("로그인에 실패하였습니다.");
                }
            }
            catch (Exception ex)
            {
                // 로그인 실패 처리
                // 적절한 예외 처리 또는 실패 처리 로직 수행
                // 예: 실패 메시지를 사용자에게 표시
                Console.WriteLine("로그인에 실패하였습니다. 오류: " + ex.Message);
            }
        }
        public async Task RefreshToken()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");

            if (!string.IsNullOrEmpty(token))
            {
                var claims = GetClaimsFromToken(token);
                var expiration = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;

                if (!string.IsNullOrEmpty(expiration) && long.TryParse(expiration, out var expirationUnixTime))
                {
                    var nowUnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    var timeRemaining = expirationUnixTime - nowUnixTime;

                    if (timeRemaining <= _tokenRefreshThresholdSeconds)
                    {
                        // 토큰 갱신 로직
                        var refreshedToken = await _actorLoginService.RefreshToken(token);

                        if (!string.IsNullOrEmpty(refreshedToken))
                        {
                            // 갱신된 토큰을 기반으로 사용자 정보를 가져옴
                            var refreshedClaims = GetClaimsFromToken(refreshedToken);

                            // 사용자 정보와 권한 정보를 포함하여 인증 상태 설정
                            await ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetAuthenticatedUser(refreshedToken);
                        }
                        else
                        {
                            // 토큰 갱신 실패 처리
                            // 적절한 예외 처리 또는 실패 처리 로직 수행
                            throw new Exception("토큰 갱신에 실패하였습니다.");
                        }
                    }
                }
            }
        }

        private List<Claim> GetClaimsFromToken(string token)
        {
            // 토큰 해석 및 필요한 정보를 추출하여 클레임 생성
            // 예: JWT 토큰의 클레임 정보 추출

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.ReadJwtToken(token);

            var claims = jwtToken.Claims.ToList();

            return claims;
        }

        public Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string scheme)
        {
            throw new NotImplementedException();
        }

        public Task ChallengeAsync(HttpContext context, string scheme, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task ForbidAsync(HttpContext context, string scheme, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task SignInAsync(HttpContext context, string scheme, ClaimsPrincipal principal, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync(HttpContext context, string scheme, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        // 나머지 인터페이스 메서드 구현
    }

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task SetAuthenticatedUser(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", token);
            var claims = GetClaimsFromToken(token);

            var identity = new ClaimsIdentity(claims, "CustomScheme");
            var principal = new ClaimsPrincipal(identity);

            // 새로운 AuthenticationState 객체 생성
            var authenticationState = new AuthenticationState(principal);
            
            // 인증 상태 업데이트
            NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
        }


        public List<Claim> GetClaimsFromToken(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.ReadJwtToken(token);

            var claims = new List<Claim>();

            foreach (var claim in jwtToken.Claims)
            {
                // 'role' claim type을 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'로 변환
                if (claim.Type == "role")
                {
                    claims.Add(new Claim(ClaimTypes.Role, claim.Value));
                }
                else
                {
                    claims.Add(claim);
                }
            }

            return claims;
        }
        public async Task Logout()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "token");

            var identity = new ClaimsIdentity();
            var principal = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(principal);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");

            if (!string.IsNullOrEmpty(token))
            {
                // 토큰이 존재하는 경우, 토큰을 기반으로 인증 상태 설정
                var claims = GetClaimsFromToken(token);
                var identity = new ClaimsIdentity(claims, "CustomScheme");
                var principal = new ClaimsPrincipal(identity);
                return new AuthenticationState(principal);
            }
            else
            {
                // 토큰이 없는 경우, 익명 사용자로 설정
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

    }
    public class CustomAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        private static readonly Task<AuthorizationPolicy> _anonymousPolicyTask = Task.FromResult(
            new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

        private readonly IJSRuntime _jsRuntime;

        public CustomAuthorizationPolicyProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => _anonymousPolicyTask;

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy>(null);

        public async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName == "Admin")
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");

                if (!string.IsNullOrEmpty(token))
                {
                    var claims = GetClaimsFromToken(token);

                    if (IsUserInRole(claims, "Admin"))
                    {
                        var policy = new AuthorizationPolicyBuilder()
                            .RequireRole("Admin")
                            .Build();

                        return policy;
                    }
                }
            }

            return null;
        }

        private List<Claim> GetClaimsFromToken(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.ReadJwtToken(token);

            var claims = jwtToken.Claims.ToList();

            return claims;
        }

        private bool IsUserInRole(List<Claim> claims, string role)
        {
            return claims.Any(c => c.Type == ClaimTypes.Role && c.Value == role);
        }
    }
}
