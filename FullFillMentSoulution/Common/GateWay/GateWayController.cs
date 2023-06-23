using AutoMapper;
using Common.Command;
using Common.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Common.GateWay
{
    // 1. DTO를 AutoMapper를 이용해서 Command로 매핑하는 단계
    // 2. Command를 Mediator를 통해 중재받아 핸들러로 전달하는 단계
    // 3. 핸들러에서 Command에 대한 구성을 파악하여 적합한 이벤트 큐를 선택하는 단계
    // 4. 이벤트 큐에 Command, DTO, DTO Options을 큐에 Enque하는 단계
    public class GateWayController<T> : ControllerBase where T : CudDTO
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        public GateWayController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T model)
        {
            var createCommand = new CreateCommand<T> { Model = model };
            var result = await _mediator.Send(createCommand);

            // Handle the result and return an appropriate IActionResult
            // ...
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] T model)
        {
            var updateCommand = new UpdateCommand<T> { Id = id, Model = model };
            var result = await _mediator.Send(updateCommand);

            // Handle the result and return an appropriate IActionResult
            // ...
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteCommand = new DeleteCommand { Id = id };
            var result = await _mediator.Send(deleteCommand);

            // Handle the result and return an appropriate IActionResult
            // ...
        }
    }
}
