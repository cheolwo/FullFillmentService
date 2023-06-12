using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.주문자구매요약;
using 주문Common.Model;

namespace 주문Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문자구매요약Controller : ControllerBase
    {
        private readonly 주문자구매요약Repository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<주문자구매요약Controller> _logger;

        public 주문자구매요약Controller(주문자구매요약Repository repository, IMapper mapper, ILogger<주문자구매요약Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create주문자구매요약DTO 주문자구매요약DTO)
        {
            _logger.LogInformation("Create called");

            if (주문자구매요약DTO == null)
                return BadRequest();

            var 주문자구매요약 = _mapper.Map<주문자구매요약>(주문자구매요약DTO);
            await _repository.AddAsync(주문자구매요약);

            var created주문자구매요약DTO = _mapper.Map<Read주문자구매요약DTO>(주문자구매요약);
            return CreatedAtAction(nameof(GetById), new { id = created주문자구매요약DTO.Id }, created주문자구매요약DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update주문자구매요약DTO updated주문자구매요약DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated주문자구매요약DTO == null || id != updated주문자구매요약DTO.Id)
                return BadRequest();

            var existing주문자구매요약 = await _repository.GetAsync(id);
            if (existing주문자구매요약 == null)
                return NotFound();

            _mapper.Map(updated주문자구매요약DTO, existing주문자구매요약);

            await _repository.UpdateAsync(existing주문자구매요약);

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation($"GetById called with ID: {id}");

            var 주문자구매요약 = await _repository.GetAsync(id);
            if (주문자구매요약 == null)
                return NotFound();

            var 주문자구매요약DTO = _mapper.Map<Read주문자구매요약DTO>(주문자구매요약);
            return Ok(주문자구매요약DTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing주문자구매요약 = await _repository.GetAsync(id);
            if (existing주문자구매요약 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("GetByIdWith판매자상품판매정보요약/{id}")]
        public async Task<IActionResult> GetByIdWith판매자상품판매정보요약(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자상품판매정보요약 called with ID: {id}");

            var 요약 = await _repository.GetByIdWith판매자상품판매정보요약(id);
            if (요약 == null)
                return NotFound();

            var 요약DTO = _mapper.Map<Read주문자구매요약DTO>(요약);
            return Ok(요약DTO);
        }

        [HttpGet("GetByIdWith판매자/{id}")]
        public async Task<IActionResult> GetByIdWith판매자(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자 called with ID: {id}");

            var 요약 = await _repository.GetByIdWith판매자(id);
            if (요약 == null)
                return NotFound();

            var 요약DTO = _mapper.Map<Read주문자구매요약DTO>(요약);
            return Ok(요약DTO);
        }

        [HttpGet("GetByIdWith판매자상품/{id}")]
        public async Task<IActionResult> GetByIdWith판매자상품(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자상품 called with ID: {id}");

            var 요약 = await _repository.GetByIdWith판매자상품(id);
            if (요약 == null)
                return NotFound();

            var 요약DTO = _mapper.Map<Read주문자구매요약DTO>(요약);
            return Ok(요약DTO);
        }

        [HttpGet("GetByIdWith주문자/{id}")]
        public async Task<IActionResult> GetByIdWith주문자(string id)
        {
            _logger.LogInformation($"GetByIdWith주문자 called with ID: {id}");

            var 요약 = await _repository.GetByIdWith주문자(id);
            if (요약 == null)
                return NotFound();

            var 요약DTO = _mapper.Map<Read주문자구매요약DTO>(요약);
            return Ok(요약DTO);
        }

        [HttpGet("GetByIdWithRelatedData/{id}")]
        public async Task<IActionResult> GetByIdWithRelatedData(string id)
        {
            _logger.LogInformation($"GetByIdWithRelatedData called with ID: {id}");

            var 요약 = await _repository.GetByIdWithRelatedData(id);
            if (요약 == null)
                return NotFound();

            var 요약DTO = _mapper.Map<Read주문자구매요약DTO>(요약);
            return Ok(요약DTO);
        }

        [HttpGet("GetBy판매자Id/{판매자Id}")]
        public async Task<IActionResult> GetBy판매자Id(string 판매자Id)
        {
            _logger.LogInformation($"GetBy판매자Id called with 판매자Id: {판매자Id}");

            var 요약List = await _repository.GetToListBy판매자Id(판매자Id);
            var 요약DTOs = _mapper.Map<List<Read주문자구매요약DTO>>(요약List);
            return Ok(요약DTOs);
        }

        [HttpGet("GetBy구매일시/{구매일시}")]
        public async Task<IActionResult> GetBy구매일시(DateTime 구매일시)
        {
            _logger.LogInformation($"GetBy구매일시 called with 구매일시: {구매일시}");

            var 요약List = await _repository.GetToListBy구매일시(구매일시);
            var 요약DTOs = _mapper.Map<List<Read주문자구매요약DTO>>(요약List);
            return Ok(요약DTOs);
        }
    }
}
