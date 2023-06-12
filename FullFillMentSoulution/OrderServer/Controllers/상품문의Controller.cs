using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.상품문의;
using 주문Common.Model;

namespace 주문Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 상품문의Controller : ControllerBase
    {
        private readonly 상품문의Repository _repository;
        private readonly ILogger<상품문의Controller> _logger;
        private readonly IMapper _mapper;

        public 상품문의Controller(상품문의Repository repository, IMapper mapper, ILogger<상품문의Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create상품문의DTO 상품문의DTO)
        {
            _logger.LogInformation("Create called");

            if (상품문의DTO == null)
                return BadRequest();

            var 상품문의 = _mapper.Map<상품문의>(상품문의DTO);
            await _repository.AddAsync(상품문의);

            var created상품문의DTO = _mapper.Map<Read상품문의DTO>(상품문의);
            return CreatedAtAction(nameof(GetBy판매자상품Id), new { 상품문의.판매자상품Id }, created상품문의DTO);
        }
        [HttpGet("{판매자상품Id}")]
        public async Task<IActionResult> GetBy판매자상품Id(string 판매자상품Id)
        {
            _logger.LogInformation($"GetBy판매자상품Id called with 판매자상품Id: {판매자상품Id}");

            var 상품문의List = await _repository.GetToListBy판매자상품Id(판매자상품Id);
            var 상품문의DTOs = _mapper.Map<List<Read상품문의DTO>>(상품문의List);
            return Ok(상품문의DTOs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update상품문의DTO updated상품문의DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated상품문의DTO == null || id != updated상품문의DTO.Id)
                return BadRequest();

            var existing상품문의 = await _repository.GetAsync(id);
            if (existing상품문의 == null)
                return NotFound();

            var updated상품문의 = _mapper.Map<상품문의>(updated상품문의DTO);

            existing상품문의.Content = updated상품문의.Content;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing상품문의);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing상품문의 = await _repository.GetAsync(id);
            if (existing상품문의 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("판매자상품/{판매자상품Id}")]
        public async Task<IActionResult> GetBy판매자상품Id(string 판매자상품Id)
        {
            _logger.LogInformation($"GetBy판매자상품Id called with 판매자상품Id: {판매자상품Id}");

            var 상품문의List = await _repository.GetToListBy판매자상품Id(판매자상품Id);
            var 상품문의DTOs = _mapper.Map<List<Read상품문의DTO>>(상품문의List);
            return Ok(상품문의DTOs);
        }

        [HttpGet("주문자/{주문자Id}")]
        public async Task<IActionResult> GetBy주문자Id(string 주문자Id)
        {
            _logger.LogInformation($"GetBy주문자Id called with 주문자Id: {주문자Id}");

            var 상품문의List = await _repository.GetToListBy주문자Id(주문자Id);
            var 상품문의DTOs = _mapper.Map<List<Read상품문의DTO>>(상품문의List);
            return Ok(상품문의DTOs);
        }

        [HttpGet("판매자상품/{판매자상품Id}/with판매자")]
        public async Task<IActionResult> GetBy판매자상품IdWith판매자(string 판매자상품Id)
        {
            _logger.LogInformation($"GetBy판매자상품IdWith판매자 called with 판매자상품Id: {판매자상품Id}");

            var 상품문의List = await _repository.GetToListBy판매자상품IdWith판매자(판매자상품Id);
            var 상품문의DTOs = _mapper.Map<List<Read상품문의DTO>>(상품문의List);
            return Ok(상품문의DTOs);
        }

        [HttpGet("주문자/{주문자Id}/with주문자")]
        public async Task<IActionResult> GetBy주문자IdWith주문자(string 주문자Id)
        {
            _logger.LogInformation($"GetBy주문자IdWith주문자 called with 주문자Id: {주문자Id}");

            var 상품문의List = await _repository.GetToListBy주문자IdWith주문자(주문자Id);
            var 상품문의DTOs = _mapper.Map<List<Read상품문의DTO>>(상품문의List);
            return Ok(상품문의DTOs);
        }

        [HttpGet("판매자상품/{판매자상품Id}/with주문자And판매자")]
        public async Task<IActionResult> GetBy판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            _logger.LogInformation($"GetBy판매자상품IdWith주문자And판매자 called with 판매자상품Id: {판매자상품Id}");

            var 상품문의List = await _repository.GetToListBy판매자상품IdWith주문자And판매자(판매자상품Id);
            var 상품문의DTOs = _mapper.Map<List<Read상품문의DTO>>(상품문의List);
            return Ok(상품문의DTOs);
        }

        [HttpGet("주문자/{주문자Id}/with판매자상품And주문자")]
        public async Task<IActionResult> GetBy주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            _logger.LogInformation($"GetBy주문자IdWith판매자상품And주문자 called with 주문자Id: {주문자Id}");

            var 상품문의List = await _repository.GetToListBy주문자IdWith판매자상품And주문자(주문자Id);
            var 상품문의DTOs = _mapper.Map<List<Read상품문의DTO>>(상품문의List);
            return Ok(상품문의DTOs);
        }
    }
}
