using IdentityModel.Client;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YourProject.Controllers
{
    public class TokenRequest
    {
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string[] Scopes { get; set; }
    }

    [ApiController]
    [Route("api/token")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IClientStore _clientStore;
        private readonly IResourceStore _resourceStore;
        private readonly IProfileService _profileService;
        private readonly IResourceOwnerPasswordValidator _resourceOwnerPasswordValidator;

        public TokenController(
            ITokenService tokenService,
            IClientStore clientStore,
            IResourceStore resourceStore,
            IProfileService profileService,
            IResourceOwnerPasswordValidator resourceOwnerPasswordValidator)
        {
            _tokenService = tokenService;
            _clientStore = clientStore;
            _resourceStore = resourceStore;
            _profileService = profileService;
            _resourceOwnerPasswordValidator = resourceOwnerPasswordValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] TokenRequest request)
        {
            var client = await _clientStore.FindClientByIdAsync(request.ClientId);
            if (client == null)
            {
                return BadRequest("Invalid client.");
            }
            
            var resources = await _resourceStore.FindEnabledResourcesByScopeAsync(request.Scopes);
            if (resources == null || resources.IdentityResources.Count == 0)
            {
                return BadRequest("Invalid scopes.");
            }

            var validationResult = await _resourceOwnerPasswordValidator.ValidateAsync(request.UserName, request.Password, _profileService, client);
            if (validationResult.IsError)
            {
                return BadRequest("Invalid username or password.");
            }

            var tokenResult = await _tokenService.CreateTokenAsync(new TokenCreationRequest
            {
                Subject = validationResult.Subject,
                ValidatedRequest = new ValidatedRequest
                {
                    Client = client,
                    Resources = resources,
                    Raw = request
                }
            });

            if (tokenResult.IsError)
            {
                return BadRequest(tokenResult.Error);
            }

            return Ok(tokenResult.TokenResponse);
        }
    }
}
