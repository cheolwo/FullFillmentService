using IdentityCommon.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForIdentityUserClaim
{
    public class CreateUserClaimCommand : IRequest<int>, IEvent
    {

    }
    public class UpdateUserClaimCommand : IRequest<int>, IEvent
    {

    }
    public class DeleteUserClaimCommand : IRequest<int>, IEvent
    {

    }
    public class GetUserClaimQuery : IRequest<IdentityUserClaim<int>>, IEvent
    {
        public int Id {get; set;}
    }
}
