using DotNetCore.Repositories;
using MediatR;

namespace IdentityCommon.Models.ForApplicationUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ICommandRepository<ApplicationUser> _CommandRepository;

        public CreateUserCommandHandler(ICommandRepository<ApplicationUser> CommandRepository)
        {
            _CommandRepository = CommandRepository;
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var User = new ApplicationUser
            {

            };

            await _CommandRepository.AddAsync(User);
            return 1;
        }
    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationUser>
    {
        private readonly IQueryRepository<ApplicationUser> _QueryRepository;

        public GetUserQueryHandler(IQueryRepository<ApplicationUser> queryRepository)
        {
            _QueryRepository = queryRepository;
        }

        public async Task<ApplicationUser> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var User = await _QueryRepository.GetAsync(query.Id);
            return User;
        }
    }
}
