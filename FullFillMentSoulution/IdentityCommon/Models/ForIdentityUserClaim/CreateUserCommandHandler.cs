using DotNetCore.Repositories;
using IdentityCommon.Models.ForIdentityUserClaim;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityCommon.Models.ForIdentityRole
{
    public class CreateUserClaimCommandHandler : IRequestHandler<CreateUserClaimCommand, int>
    {
        private readonly ICommandRepository<IdentityRole> _CommandRepository;

        public CreateUserClaimCommandHandler(ICommandRepository<IdentityRole> CommandRepository)
        {
            _CommandRepository = CommandRepository;
        }

        public async Task<int> Handle(CreateUserClaimCommand command, CancellationToken cancellationToken)
        {
            var Role = new IdentityRole
            {

            };

            await _CommandRepository.AddAsync(Role);
            return 1;
        }
    }
}
