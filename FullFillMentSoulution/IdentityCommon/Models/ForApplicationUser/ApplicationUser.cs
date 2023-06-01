using IdentityCommon.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForApplicationUser
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        
    }
    public class CreateUserCommand : IRequest<int>, IEvent
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
    public class UpdateUserCommand : IRequest<int>, IEvent
    {

    }
    public class DeleteUserCommand : IRequest<int>, IEvent
    {

    }
    public class GetUserQuery : IRequest<ApplicationUser>, IEvent
    {
        public string Id { get; set; }
    }
}
