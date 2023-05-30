//using IdentityCommon.Models;
//using IdentityServerTest.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//namespace IdentityServerSample.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class RegisterController : ControllerBase
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly PasswordValidator<ApplicationUser> _passwordValidator;

//        public RegisterController(UserManager<ApplicationUser> userManager, PasswordValidator<ApplicationUser> passwordValidator, RoleManager<IdentityRole> roleManager)
//        {
//            _userManager = userManager;
//            _passwordValidator = passwordValidator;
//            _roleManager = roleManager;
//        }

//        [HttpPost]
//        public async Task<IActionResult> RegisterUser(RegisterUserModel model)
//        {
//            // Id 중복검사 단계
//            var user = await _userManager.FindByNameAsync(model.Id);
//            if (user != null)
//            {
//                return BadRequest("이미 사용 중인 아이디입니다.");
//            }

//            // 비밀번호 유효성 검증 단계
//            var passwordValidationResult = await _passwordValidator.ValidateAsync(_userManager, null, model.Password);

//            if (!passwordValidationResult.Succeeded)
//            {
//                string errors = string.Join(", ", passwordValidationResult.Errors);
//                return BadRequest($"비밀번호 유효성 검사 실패: {errors}");
//            }

//            // 역할 부여 단계
//            string role = "일반사용자"; // 기본 역할은 일반 사용자로 설정
//            if (model.IsAdmin)
//            {
//                role = "관리자";
//            }

//            // 아이디 생성 단계
//            string userId = GenerateUserId(model.Name);

//            // 회원 등록
//            var newUser = new ApplicationUser { UserName = model.Id, Id = userId };
//            var result = await _userManager.CreateAsync(newUser, model.Password);

//            if (result.Succeeded)
//            {
//                // 회원가입 처리 또는 추가 작업
//                // 역할 등록
//                await AssignUserRole(newUser, role);

//                return Ok("회원가입이 성공적으로 완료되었습니다.");
//            }
//            else
//            {
//                return BadRequest("회원가입에 실패했습니다.");
//            }
//        }

//        private async Task AssignUserRole(ApplicationUser user, string role)
//        {
//            var existingRole = await _roleManager.FindByNameAsync(role);
//            if (existingRole == null)
//            {
//                await _roleManager.CreateAsync(new IdentityRole(role));
//            }

//            await _userManager.AddToRoleAsync(user, role);
//        }
//        private string GenerateUserId(string name)
//        {
//            // 아이디 생성 로직 구현
//            // 사용자 이름 또는 기타 정보를 이용하여 고유한 아이디를 생성
//            // 실제 구현에 맞게 변경해야 합니다.
//            return $"{name.ToLower()}-{Guid.NewGuid().ToString("N")}";
//        }
//    }
//}
