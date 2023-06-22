using Common.DTO;
using IdentityCommon.Models;
using IdentityCommon.Models.ForApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IdentityServerSample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly PasswordValidator<ApplicationUser> _passwordValidator;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtTokenProvider _tokenProvider;

        public AccountController(UserManager<ApplicationUser> userManager, PasswordValidator<ApplicationUser> passwordValidator, 
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager,
            JwtTokenProvider jwtTokenProvider)
        {
            _userManager = userManager;
            _passwordValidator = passwordValidator;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenProvider = jwtTokenProvider;
        }
        /// <summary>
        /// 1. 로그인 인증
        /// 2. 토큰 발행
        /// 3. 토큰 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return BadRequest("Invalid username or password.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // 로그인 성공
                var token = await _tokenProvider.GenerateTokenAsync(user); // JwtTokenProvider를 사용하여 토큰 생성
                return Ok(token); // 토큰 반환
            }
            if (result.RequiresTwoFactor)
            {
                // 2단계 인증이 필요한 경우
                // 적절한 처리를 수행하거나 적절한 응답을 반환합니다.
            }
            if (result.IsLockedOut)
            {
                // 계정이 잠긴 경우
                // 적절한 처리를 수행하거나 적절한 응답을 반환합니다.
            }

            // 로그인 실패
            // 적절한 처리를 수행하거나 적절한 응답을 반환합니다.
            return BadRequest("Invalid username or password.");
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
        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] string token)
        {
            try
            {
                var refreshedToken = await _tokenProvider.RefreshToken(token);
                return Ok(refreshedToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserModel model)
        {
            // Id 중복검사 단계
            var user = await _userManager.FindByNameAsync(model.Id);
            if (user != null)
            {
                return BadRequest("이미 사용 중인 아이디입니다.");
            }

            // 비밀번호 유효성 검증 단계
            var passwordValidationResult = await _passwordValidator.ValidateAsync(_userManager, null, model.Password);

            if (!passwordValidationResult.Succeeded)
            {
                string errors = string.Join(", ", passwordValidationResult.Errors);
                return BadRequest($"비밀번호 유효성 검사 실패: {errors}");
            }

            // 역할 부여 단계
            string role = "일반사용자"; // 기본 역할은 일반 사용자로 설정
            if (model.IsAdmin)
            {
                role = "관리자";
            }

            // 아이디 생성 단계
            string userId = GenerateUserId(model.Name);

            // 회원 등록
            var newUser = new ApplicationUser { UserName = model.Id, Id = userId };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                // 회원가입 처리 또는 추가 작업
                // 역할 등록
                await AssignUserRole(newUser, role);

                return Ok("회원가입이 성공적으로 완료되었습니다.");
            }
            else
            {
                return BadRequest("회원가입에 실패했습니다.");
            }
        }

        private async Task AssignUserRole(ApplicationUser user, string role)
        {
            var existingRole = await _roleManager.FindByNameAsync(role);
            if (existingRole == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

            await _userManager.AddToRoleAsync(user, role);
        }
        private string GenerateUserId(string name)
        {
            // 아이디 생성 로직 구현
            // 사용자 이름 또는 기타 정보를 이용하여 고유한 아이디를 생성
            // 실제 구현에 맞게 변경해야 합니다.
            return $"{name.ToLower()}-{Guid.NewGuid().ToString("N")}";
        }
    }
}
