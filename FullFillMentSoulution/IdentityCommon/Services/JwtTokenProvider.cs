using IdentityCommon.Models.ForApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityServerSample
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; }
    }
    public class JwtTokenProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<ApplicationUser> _userManager;

        public JwtTokenProvider(IOptions<JwtOptions> jwtOptions, UserManager<ApplicationUser> userManager
            )
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }

            //var domains = await _applicationDbContext.Set<UserRoleDomain>().FirstOrDefaultAsync(e => e.UserId == user.Id);
        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        public async Task<string> RefreshToken(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            // 토큰을 해석하여 클레임 정보 가져오기
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken validatedToken;
            var claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

            if (validatedToken is JwtSecurityToken jwtSecurityToken &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                // 토큰 유효성 검사 및 만료 시간 확인
                var expiryUnixTimestamp = long.Parse(jwtSecurityToken.Payload.Exp.ToString());
                var expiryDateTimeUtc = DateTimeOffset.FromUnixTimeSeconds(expiryUnixTimestamp).UtcDateTime;
                var currentDateTimeUtc = DateTime.UtcNow;

                if (expiryDateTimeUtc > currentDateTimeUtc)
                {
                    // 토큰이 유효한 경우, 기존 클레임 정보 가져오기
                    var claims = claimsPrincipal.Claims.ToList();

                    // 새로운 토큰 생성
                    var user = await _userManager.GetUserAsync(claimsPrincipal);
                    var newToken = await GenerateTokenAsync(user);

                    return newToken;
                }
            }

            throw new SecurityTokenException("Invalid token or expired token.");
        }
    }
}
