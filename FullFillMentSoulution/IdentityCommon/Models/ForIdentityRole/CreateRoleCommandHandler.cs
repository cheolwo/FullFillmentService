using DotNetCore.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForIdentityRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
    {
        private readonly ICommandRepository<IdentityRole> _CommandRepository;

        public CreateRoleCommandHandler(ICommandRepository<IdentityRole> CommandRepository)
        {
            _CommandRepository = CommandRepository;
        }

        public async Task<int> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var Role = new IdentityRole
            {

            };

            await _CommandRepository.AddAsync(Role);
            return 1;
        }
    }
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, IdentityRole>
    {
        private readonly IQueryRepository<IdentityRole> _QueryRepository;

        public GetRoleQueryHandler(IQueryRepository<IdentityRole> queryRepository)
        {
            _QueryRepository = queryRepository;
        }

        public async Task<IdentityRole> Handle(GetRoleQuery query, CancellationToken cancellationToken)
        {
            var Role = await _QueryRepository.GetAsync(query.Id);
            return Role;
        }
    }
}
