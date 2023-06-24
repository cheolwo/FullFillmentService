using Common.ForCommand;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForApplicationUser
{
    public class ApplicationUser : IdentityUser
    {
        public List<CommandOption> commandOptions { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
    }
    
}
