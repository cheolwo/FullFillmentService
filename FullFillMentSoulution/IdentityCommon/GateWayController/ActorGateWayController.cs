using Common.DTO;
using Common.ForCommand;
using IdentityServerTest.Repository;
using Microsoft.AspNetCore.Mvc;
using 계정Common.Extensions;

namespace 계정Common.GateWayController
{
    public class ActorGateWayController<T> : ControllerBase where T : CudDTO
    {
        protected readonly ApplicationUserRepository _applicationUserRepository;

        public ActorGateWayController(ApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
        public async Task<CudCommand<T>> Set(T t)
        {
            // 헤더에서 토큰 추출
            var token = Request.Headers["Authorization"].ToString()?.Replace("Bearer ", "");

            // 토큰을 사용하여 사용자 ID 해석
            if (token == null)
            {
                throw new ArgumentNullException(token);
            }

            var userId = token.GetUserIdFromToken();

            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(userId);
            }

            var userOptions = await _applicationUserRepository.GetCommandOptionByName(userId, typeof(T).Name);
            var command = t.Mapping(userOptions);

            return command;
        }
    }
}
