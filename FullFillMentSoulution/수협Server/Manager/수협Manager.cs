using IdentityCommon.Models.ForApplicationUser;
using KoreaCommon.Model.Repository;
using Microsoft.AspNetCore.Identity;

namespace 수협Server.Manager
{
    public class 수협Manager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly 수산협동조합Repository _수산협동조합Repostiroy;
        private readonly 수산품Repository _수산품Repsotiroy;
        private readonly 수산품별재고현황Repository _수산품별재고현황Repostiroy;
        private readonly 수산창고Repository _수산창고Repository;

        private const string 조합장역할 = "조합장";
        private const string 창고장역할 = "창고장";

        public 수협Manager(UserManager<ApplicationUser> userManager, 수산협동조합Repository 수산협동조합Repostiroy, 
            수산품Repository 수산품Repsotiroy, 수산품별재고현황Repository 수산품별재고현황Repostiroy, 수산창고Repository 수산창고Repository, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _수산협동조합Repostiroy = 수산협동조합Repostiroy;
            _수산품Repsotiroy = 수산품Repsotiroy;
            _수산품별재고현황Repostiroy = 수산품별재고현황Repostiroy;
            _수산창고Repository = 수산창고Repository;
            _roleManager = roleManager;
        }
        public async Task InitializeAccount()
        {
            await CreateRoles();

            var 수산협동조합들 = await _수산협동조합Repostiroy.ListAsync();
            var 수산창고들 = await _수산창고Repository.ListAsync();

            foreach (var 협동조합 in 수산협동조합들)
            {
                // 수산협동조합 계정 생성
                string username = 협동조합.Code;
                string password = 협동조합.Code + 협동조합.Name;
                await CreateUserAccount(username, password, 조합장역할);
            }

            foreach (var 창고 in 수산창고들)
            {
                // 수산창고 계정 생성
                string username = 창고.Code;
                string password = 창고.Code + 창고.Name;
                await CreateUserAccount(username, password, 창고장역할);
            }
        }

        private async Task CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync(조합장역할))
            {
                await _roleManager.CreateAsync(new IdentityRole(조합장역할));
            }

            if (!await _roleManager.RoleExistsAsync(창고장역할))
            {
                await _roleManager.CreateAsync(new IdentityRole(창고장역할));
            }
        }

        private async Task CreateUserAccount(string username, string password, string role)
        {
            var user = new ApplicationUser { UserName = username };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            else
            {
            }
        }
    }
}
