using Microsoft.AspNetCore.Identity;
using IdentityCommon.Services;
using MediatR;

namespace IdentityCommon.Models.ForIdentityRoleClaim
{
    public class CreateRoleClaimCommand : IRequest<int>, IEvent
    {

    }
    public class UpdateRoleClaimCommand : IRequest<int>, IEvent
    {

    }
    public class DeleteRoleClaimCommand : IRequest<int>, IEvent
    {

    }
    public class GetRoleClaimQuery : IRequest<IdentityRoleClaim<int>>, IEvent
    {   
        public int Id {get; set;}
    }
}
