using IdentityServerTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityUserController : ControllerBase
    {
        private readonly ApplicationUserRepository _applicationUserRepository;
        public IdentityUserController(ApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

    }
}
