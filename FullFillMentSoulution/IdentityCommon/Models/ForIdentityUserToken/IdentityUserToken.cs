using IdentityCommon.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForIdentityUserToken
{
    public class CreateUserTokenCommand : IRequest<int>, IEvent
    {
    }
    public class UpdateUserTokenCommand : IRequest<int>, IEvent
    {
    }
    public class DeleteUserTokenCommand : IRequest<int>, IEvent
    {
    }
    public class GetUserTokenQuery : IRequest<IdentityUserToken<string>>, IEvent
    {
        public string Id {get; set;}
    }
}
