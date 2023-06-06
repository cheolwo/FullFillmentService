using IdentityCommon.Models.ForApplicationUser;
using KoreaCommon.Model;
using KoreaCommon.Model.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using 수협Server.Manager;
using 해양수산부.API.For산지조합;
using 해양수산부.API.For산지조합창고;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수협AccountController : Controller
    {
        private readonly 수협Manager _수협Manager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly 산지조합창고API _산지조합창고API;
        private readonly 수산창고Repository _수산창고Repository;
        private readonly 산지조합API _산지조합API;
        private readonly 수산협동조합Repository _수산협동조합Repository;

        public 수협AccountController(UserManager<ApplicationUser> userManager, 
            산지조합창고API 산지조합창고API, 산지조합API 산지조합API
            ,수산창고Repository 수산창고Repository, 수산협동조합Repository 수산협동조합Repository, 수협Manager 수협Manager)
        {
            _userManager = userManager;
            _산지조합창고API = 산지조합창고API;
            _수산창고Repository = 수산창고Repository;
            _산지조합API = 산지조합API;
            _수산협동조합Repository = 수산협동조합Repository;
            _수협Manager = 수협Manager;
        }
        [HttpPost("initialize")]
        public async Task<IActionResult> InitializeAccount()
        {
            try
            {
                await _수협Manager.InitializeAccount();
                return Ok("계정 초기화가 완료되었습니다.");
            }
            catch (Exception ex)
            {
                // 예외 처리
                return StatusCode(500, "계정 초기화 중 오류가 발생했습니다.");
            }
        }
        [HttpGet("load-merge-hyup")]
        public async Task<IActionResult> LoadAndMergeHyup()
        {
            try
            {
                var merged수산협동조합들 = await LoadMergeFetch수산협동조합정보();
                return Ok(merged수산협동조합들);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("load-merge-changgo")]
        public async Task<IActionResult> LoadAndMergeChanggo()
        {
            try
            {
                var merged수산창고들 = await LoadMergeFetch수산창고정보();
                return Ok(merged수산창고들);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private async Task<IEnumerable<수산창고>> LoadMergeFetch수산창고정보()
        {
            // 산지조합창고정보 로드
            IEnumerable<수산창고> api수산창고들 = await _산지조합창고API.LoadAll수산창고정보();

            // 수산창고 Repository에서 로드
            IEnumerable<수산창고> repository수산창고들 = await _수산창고Repository.ListAsync();

            // 중복된 수산창고 필터링하여 병합
            IEnumerable<수산창고> merged수산창고들 = AddRange수산창고(api수산창고들, repository수산창고들);

            // 수산창고 Repository에 저장
            _수산창고Repository.AddRange(merged수산창고들);
            await _수산창고Repository.SaveChangesAsync();

            return merged수산창고들;
        }

        private IEnumerable<수산창고> AddRange수산창고(IEnumerable<수산창고> api수산창고들, IEnumerable<수산창고> repository수산창고들)
        {
            List<수산창고> AddRange수산창고들 = new List<수산창고>();


            // 중복된 수산창고 필터링하여 병합
            foreach (var api수산창고 in api수산창고들)
            {
                if (!repository수산창고들.Any(c => c.Code == api수산창고.Code))
                {
                    AddRange수산창고들.Add(api수산창고);
                }
            }

            return AddRange수산창고들;
        }
        private async Task<IEnumerable<수산협동조합>> LoadMergeFetch수산협동조합정보()
        {
            // 산지조합창고정보 로드
            IEnumerable<수산협동조합> api수산협동조합들 = await _산지조합API.LoadAll수산협동조합정보();

            // 수산협동조합 Repository에서 로드
            IEnumerable<수산협동조합> repository수산협동조합들 = await _수산협동조합Repository.ListAsync();

            // 중복된 수산협동조합 필터링하여 병합
            IEnumerable<수산협동조합> AddRange수산협동조합들 = AddRange수산협동조합(api수산협동조합들, repository수산협동조합들);

            // 수산협동조합 Repository에 저장
            _수산협동조합Repository.AddRange(AddRange수산협동조합들);
            await _수산협동조합Repository.SaveChangesAsync();

            return AddRange수산협동조합들;
        }

        private IEnumerable<수산협동조합> AddRange수산협동조합(IEnumerable<수산협동조합> api수산협동조합들, IEnumerable<수산협동조합> repository수산협동조합들)
        {
            List<수산협동조합> AddRange수산협동조합들 = new List<수산협동조합>();

 
            // 중복된 수산협동조합 필터링하여 병합
            foreach (var api수산협동조합 in api수산협동조합들)
            {
                if (!repository수산협동조합들.Any(c => c.Code == api수산협동조합.Code))
                {
                    AddRange수산협동조합들.Add(api수산협동조합);
                }
            }

            return AddRange수산협동조합들;
        }
    }
}
