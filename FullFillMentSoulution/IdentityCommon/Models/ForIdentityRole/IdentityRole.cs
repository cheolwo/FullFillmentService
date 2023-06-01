using IdentityCommon.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForIdentityRole
{
    public class CreateRoleCommand: IRequest<int>, IEvent
    {

    }
    public class UpdateRoleCommand: IRequest<int>, IEvent
    {

    }
    public class DeleteRoleCommand: IRequest<int>, IEvent
    {

    }
    public class GetRoleQuery: IRequest<IdentityRole>, IEvent
    {
        public string Id {get; set;}
    }
}
