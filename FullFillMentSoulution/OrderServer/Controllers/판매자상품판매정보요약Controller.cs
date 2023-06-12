using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.판매자상품판매정보요약;
using 주문Common.Model;

namespace 주문Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 판매자상품판매정보요약Controller : ControllerBase
    {
        private readonly 판매자상품판매정보요약Repository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<판매자상품판매정보요약Controller> _logger;

        public 판매자상품판매정보요약Controller(판매자상품판매정보요약Repository repository, IMapper mapper, ILogger<판매자상품판매정보요약Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create판매자상품판매정보요약DTO 판매자상품판매정보요약DTO)
        {
            _logger.LogInformation("Create called");

            if (판매자상품판매정보요약DTO == null)
                return BadRequest();

            var 판매자상품판매정보요약 = _mapper.Map<판매자상품판매정보요약>(판매자상품판매정보요약DTO);
            await _repository.AddAsync(판매자상품판매정보요약);

            var created판매자상품판매정보요약DTO = _mapper.Map<Read판매자상품판매정보요약DTO>(판매자상품판매정보요약);
            return CreatedAtAction(nameof(GetById), new { id = created판매자상품판매정보요약DTO.Id }, created판매자상품판매정보요약DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update판매자상품판매정보요약DTO updated판매자상품판매정보요약DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated판매자상품판매정보요약DTO == null || id != updated판매자상품판매정보요약DTO.Id)
                return BadRequest();

            var existing판매자상품판매정보요약 = await _repository.GetAsync(id);
            if (existing판매자상품판매정보요약 == null)
                return NotFound();

            _mapper.Map(updated판매자상품판매정보요약DTO, existing판매자상품판매정보요약);

            await _repository.UpdateAsync(existing판매자상품판매정보요약);

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation($"GetById called with ID: {id}");

            var 판매자상품판매정보요약 = await _repository.GetAsync(id);
            if (판매자상품판매정보요약 == null)
                return NotFound();

            var 판매자상품판매정보요약DTO = _mapper.Map<Read판매자상품판매정보요약DTO>(판매자상품판매정보요약);
            return Ok(판매자상품판매정보요약DTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing판매자상품판매정보요약 = await _repository.GetAsync(id);
            if (existing판매자상품판매정보요약 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdWith판매자And주문자구매요약(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자And주문자구매요약 called with ID: {id}");

            var 정보요약 = await _repository.GetByIdWith판매자And주문자구매요약(id);
            if (정보요약 == null)
                return NotFound();

            var 정보요약DTO = _mapper.Map<Read판매자상품판매정보요약DTO>(정보요약);
            return Ok(정보요약DTO);
        }

        [HttpGet("GetBy판매자Id/{판매자Id}")]
        public async Task<IActionResult> GetBy판매자Id(string 판매자Id)
        {
            _logger.LogInformation($"GetBy판매자Id called with 판매자Id: {판매자Id}");

            var 정보요약List = await _repository.GetToListBy판매자Id(판매자Id);
            var 정보요약DTOs = _mapper.Map<List<Read판매자상품판매정보요약DTO>>(정보요약List);
            return Ok(정보요약DTOs);
        }

        [HttpGet("GetByIdWith판매자상품/{id}")]
        public async Task<IActionResult> GetByIdWith판매자상품(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자상품 called with ID: {id}");

            var 정보요약 = await _repository.GetByIdWith판매자상품(id);
            if (정보요약 == null)
                return NotFound();

            var 정보요약DTO = _mapper.Map<Read판매자상품판매정보요약DTO>(정보요약);
            return Ok(정보요약DTO);
        }

        [HttpGet("GetByIdWith판매자상품And주문자구매요약/{id}")]
        public async Task<IActionResult> GetByIdWith판매자상품And주문자구매요약(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자상품And주문자구매요약 called with ID: {id}");

            var 정보요약 = await _repository.GetByIdWith판매자상품And주문자구매요약(id);
            if (정보요약 == null)
                return NotFound();

            var 정보요약DTO = _mapper.Map<Read판매자상품판매정보요약DTO>(정보요약);
            return Ok(정보요약DTO);
        }

        [HttpGet("GetBy판매자상품Id/{판매자상품Id}")]
        public async Task<IActionResult> GetBy판매자상품Id(string 판매자상품Id)
        {
            _logger.LogInformation($"GetBy판매자상품Id called with 판매자상품Id: {판매자상품Id}");

            var 정보요약List = await _repository.GetToListBy판매자상품Id(판매자상품Id);
            var 정보요약DTOs = _mapper.Map<List<Read판매자상품판매정보요약DTO>>(정보요약List);
            return Ok(정보요약DTOs);
        }
    }
}
