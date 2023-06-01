using IdentityCommon.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace IdentityCommon.Models.ForIdentityUserRole
{
    public class CreateUserRoleCommand : IRequest<int>, IEvent
    {
    }
    public class UpdateUserRoleCommand : IRequest<int>, IEvent
    {
    }
    public class DeleteUserRoleCommand : IRequest<int>, IEvent
    {
    }
    public class GetUserRoleQuery : IRequest<IdentityUserRole<string>>, IEvent
    {
        public string Id {get; set;}
    }
}
