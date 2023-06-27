using MediatR;
using Microsoft.AspNetCore.Mvc;
using 수협비즈니스APIGateWay.Handlr;
using 주문Common.DTO.For주문;

namespace 수협비즈니스APIGateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문자비즈니스통합CommandAPIController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<주문자비즈니스통합CommandAPIController> _logger;
        public 주문자비즈니스통합CommandAPIController(IMediator mediator, ILogger<주문자비즈니스통합CommandAPIController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create주문(Create주문DTO dto)
        {
            try
            {
                var command = new Create주문Command { Dto = dto };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "주문 생성에 실패했습니다.");
                return StatusCode(500, "주문 생성에 실패했습니다.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update주문(Update주문DTO dto)
        {
            try
            {
                var command = new Update주문Command { Dto = dto };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "주문 업데이트에 실패했습니다.");
                return StatusCode(500, "주문 업데이트에 실패했습니다.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete주문(Delete주문DTO dto)
        {
            try
            {
                var command = new Delete주문Command { Dto = dto };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "주문 삭제에 실패했습니다.");
                return StatusCode(500, "주문 삭제에 실패했습니다.");
            }
        }
    }
}
