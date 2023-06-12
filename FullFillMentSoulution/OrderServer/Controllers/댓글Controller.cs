using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.댓글;
using 주문Common.Model;

namespace 주문Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 댓글Controller : ControllerBase
    {
        private readonly 댓글Repository _repository;
        private readonly ILogger<댓글Controller> _logger;
        private readonly IMapper _mapper;

        public 댓글Controller(댓글Repository repository, IMapper mapper, ILogger<댓글Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("판매자상품/{판매자상품Id}")]
        public async Task<IActionResult> GetBy판매자상품Id(string 판매자상품Id)
        {
            _logger.LogInformation($"GetBy판매자상품Id called with 판매자상품Id: {판매자상품Id}");

            var 댓글들 = await _repository.GetToListBy판매자상품Id(판매자상품Id);
            var 댓글DTOs = _mapper.Map<List<Read댓글DTO>>(댓글들);
            return Ok(댓글DTOs);
        }
        [HttpGet("주문자/{주문자Id}")]
        public async Task<IActionResult> GetBy주문자Id(string 주문자Id)
        {
            _logger.LogInformation($"GetBy주문자Id called with 주문자Id: {주문자Id}");

            var 댓글들 = await _repository.GetToListBy주문자Id(주문자Id);
            var 댓글DTOs = _mapper.Map<List<Read댓글DTO>>(댓글들);
            return Ok(댓글DTOs);
        }

        [HttpGet("판매자상품/{판매자상품Id}/주문자")]
        public async Task<IActionResult> GetBy판매자상품IdWith주문자(string 판매자상품Id)
        {
            _logger.LogInformation($"GetBy판매자상품IdWith주문자 called with 판매자상품Id: {판매자상품Id}");

            var 댓글들 = await _repository.GetToListBy판매자상품IdWith주문자(판매자상품Id);
            var 댓글DTOs = _mapper.Map<List<Read댓글DTO>>(댓글들);
            return Ok(댓글DTOs);
        }

        [HttpGet("주문자/{주문자Id}/판매자상품")]
        public async Task<IActionResult> GetBy주문자IdWith판매자상품(string 주문자Id)
        {
            _logger.LogInformation($"GetBy주문자IdWith판매자상품 called with 주문자Id: {주문자Id}");

            var 댓글들 = await _repository.GetToListBy주문자IdWith판매자상품(주문자Id);
            var 댓글DTOs = _mapper.Map<List<Read댓글DTO>>(댓글들);
            return Ok(댓글DTOs);
        }

        [HttpGet("판매자상품/{판매자상품Id}/주문자And판매자")]
        public async Task<IActionResult> GetBy판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            _logger.LogInformation($"GetBy판매자상품IdWith주문자And판매자 called with 판매자상품Id: {판매자상품Id}");

            var 댓글들 = await _repository.GetToListBy판매자상품IdWith주문자And판매자(판매자상품Id);
            var 댓글DTOs = _mapper.Map<List<Read댓글DTO>>(댓글들);
            return Ok(댓글DTOs);
        }

        [HttpGet("주문자/{주문자Id}/판매자상품And주문자")]
        public async Task<IActionResult> GetBy주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            _logger.LogInformation($"GetBy주문자IdWith판매자상품And주문자 called with 주문자Id: {주문자Id}");

            var 댓글들 = await _repository.GetToListBy주문자IdWith판매자상품And주문자(주문자Id);
            var 댓글DTOs = _mapper.Map<List<Read댓글DTO>>(댓글들);
            return Ok(댓글DTOs);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create댓글DTO 댓글DTO)
        {
            _logger.LogInformation("Create called");

            if (댓글DTO == null)
                return BadRequest();

            var 댓글 = _mapper.Map<댓글>(댓글DTO);
            await _repository.AddAsync(댓글);

            var created댓글DTO = _mapper.Map<Read댓글DTO>(댓글);
            return CreatedAtAction(nameof(GetBy판매자상품Id), new { 판매자상품Id = 댓글.판매자상품Id }, created댓글DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update댓글DTO updated댓글DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated댓글DTO == null || id != updated댓글DTO.Id)
                return BadRequest();

            var existing댓글 = await _repository.GetAsync(id);
            if (existing댓글 == null)
                return NotFound();

            var updated댓글 = _mapper.Map<댓글>(updated댓글DTO);

            existing댓글.Content = updated댓글.Content;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing댓글);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing댓글 = await _repository.GetAsync(id);
            if (existing댓글 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
