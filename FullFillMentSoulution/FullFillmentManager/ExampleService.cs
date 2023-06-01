using Microsoft.AspNetCore.Components.Authorization;

namespace FullFillmentManager
{
    public class ExampleService
    {
        public async Task<string> ExampleMethod(AuthenticationStateProvider authStateProvider)
        {
            var authState = await authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                return $"{user.Identity.Name} is authenticated.";
            }
            else
            {
                return "The user is NOT authenticated.";
            }
        }
    }
}
