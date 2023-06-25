using Common.DTO;
using IdentityServerTest.Repository;
using Microsoft.AspNetCore.Authorization;
using 계정Common.GateWayController;

namespace 창고관리자APIGateWay.Controllers
{
    [Authorize(Roles = "창고관리자")]
    public class 창고관리자GateWayController : ActorGateWayController
    {
        public 창고관리자GateWayController(ApplicationUserRepository applicationUserRepository)
            : base(applicationUserRepository)
        {
        }
    }
}
