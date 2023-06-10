using IdentityCommon.Models.ForApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using 계정Common.Models;

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
        private readonly ApplicationDbContext _applicationDbContext;

        public JwtTokenProvider(IOptions<JwtOptions> jwtOptions, UserManager<ApplicationUser> userManager, 
            ApplicationDbContext applicationDbContext)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);
            var domains = await _applicationDbContext.Set<UserRoleDomain>().FirstOrDefaultAsync(e => e.UserId == user.Id);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };
            if (domains != null)
            {
                claims.Add(new Claim(typeof(List<Domain>).ToString(), domains.DomainsJson));
            }

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
    }
}
