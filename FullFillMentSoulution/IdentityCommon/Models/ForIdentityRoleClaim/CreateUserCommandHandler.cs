using DotNetCore.Repositories;
using IdentityCommon.Models.ForIdentityRoleClaim;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForIdentityRole
{
    public class CreateRoleClaimCommandHandler : IRequestHandler<CreateRoleClaimCommand, int>
    {
        private readonly ICommandRepository<IdentityRoleClaim<int>> _CommandRepository;

        public CreateRoleClaimCommandHandler(ICommandRepository<IdentityRoleClaim<int>> CommandRepository)
        {
            _CommandRepository = CommandRepository;
        }

        public async Task<int> Handle(CreateRoleClaimCommand command, CancellationToken cancellationToken)
        {
            var Role = new IdentityRoleClaim<int>
            {

            };

            await _CommandRepository.AddAsync(Role);
            return 1;
        }
    }
    public class GetRoleClaimQueryHandler : IRequestHandler<GetRoleClaimQuery, IdentityRoleClaim<int>>
    {
        private readonly IQueryRepository<IdentityRoleClaim<int>> _QueryRepository;

        public GetRoleClaimQueryHandler(IQueryRepository<IdentityRoleClaim<int>> queryRepository)
        {
            _QueryRepository = queryRepository;
        }

        public async Task<IdentityRoleClaim<int>> Handle(GetRoleClaimQuery query, CancellationToken cancellationToken)
        {
            var Role = await _QueryRepository.GetAsync(query.Id);
            return Role;
        }
    }
}
