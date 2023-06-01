using IdentityCommon.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForIdentityUserLogin
{
    public class CreateUserLoginCommand : IRequest<int>, IEvent
    {

    }
    public class UpdateUserLoginCommand : IRequest<int>, IEvent
    {

    }
    public class DeleteUserLoginCommand : IRequest<int>, IEvent
    {

    }
    public class GetUserLoginQuery : IRequest<IdentityUserLogin<string>>, IEvent
    {
        public string Id {get; set;}
    }
}
