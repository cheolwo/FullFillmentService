using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace 계정Common.Extensions
{
    public static class JwtTokenExtensions
    {
        public static string GetUserIdFromToken(this string token)
        {
            // 토큰을 해석하여 사용자 ID 추출 로직 구현
            // 필요에 따라 JWT 토큰을 검증하고 사용자 ID를 추출하는 작업을 수행

            // 예시: JWT 토큰을 검증하고 사용자 ID를 추출하는 작업
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken != null && jwtToken.ValidTo > DateTime.UtcNow)
            {
                var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                return userId;
            }

            return null; // 토큰이 유효하지 않은 경우에 대한 처리
        }
    }
}
