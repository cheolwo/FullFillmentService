using Common.GateWay;
using IdentityServerTest.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using 창고Common.Command;
using 창고Common.DTO.창고;

namespace 창고관리자APIGateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 창고GateWayController : 창고관리자GateWayController
    {
        private readonly IMediator _mediator;
        public 창고GateWayController(ApplicationUserRepository applicationUserRepository,
            IMediator mediator) 
                        : base(applicationUserRepository)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create창고DTO create창고Dto)
        {
            var options = await Set<Create창고DTO>();
            Create창고Command command = new(create창고Dto, token, ServerSubject.물류, options);
            await _mediator.Send(command);
            
            return Ok(); // 작업이 성공적으로 완료되었을 경우 200 OK 응답을 반환합니다.
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Update창고DTO update창고Dto)
        {
            var options = await Set<Update창고DTO>();
            Update창고Command command = new(update창고Dto, token, ServerSubject.물류, options);
            await _mediator.Send(command);
            return Ok(); // 작업이 성공적으로 완료되었을 경우 200 OK 응답을 반환합니다.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] Delete창고DTO delete창고Dto)
        {
            var options = await Set<Delete창고DTO>();
            Delete창고Command command = new(delete창고Dto, token, ServerSubject.물류, options);
            await _mediator.Send(command);
            return Ok(); // 작업이 성공적으로 완료되었을 경우 200 OK 응답을 반환합니다.
        }
    }
}
