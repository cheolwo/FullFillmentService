using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.판매자;
using 주문Common.Model;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 판매자Controller : ControllerBase
    {
        private readonly 판매자Repository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<판매자Controller> _logger;

        public 판매자Controller(판매자Repository repository, IMapper mapper, ILogger<판매자Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create판매자DTO 판매자DTO)
        {
            _logger.LogInformation("Create called");

            if (판매자DTO == null)
                return BadRequest();

            var 판매자 = _mapper.Map<판매자>(판매자DTO);
            await _repository.AddAsync(판매자);

            var created판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return CreatedAtAction(nameof(GetById), new { id = created판매자DTO.Id }, created판매자DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update판매자DTO updated판매자DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated판매자DTO == null || id != updated판매자DTO.Id)
                return BadRequest();

            var existing판매자 = await _repository.GetAsync(id);
            if (existing판매자 == null)
                return NotFound();

            _mapper.Map(updated판매자DTO, existing판매자);

            await _repository.UpdateAsync(existing판매자);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing판매자 = await _repository.GetAsync(id);
            if (existing판매자 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation($"GetById called with ID: {id}");

            var 판매자 = await _repository.GetAsync(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }
        [HttpGet("GetByIdWith판매자상품/{id}")]
        public async Task<IActionResult> GetByIdWith판매자상품(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자상품 called with ID: {id}");

            var 판매자 = await _repository.GetByIdWith판매자상품(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }

        [HttpGet("GetByIdWith주문/{id}")]
        public async Task<IActionResult> GetByIdWith주문(string id)
        {
            _logger.LogInformation($"GetByIdWith주문 called with ID: {id}");

            var 판매자 = await _repository.GetByIdWith주문(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }

        [HttpGet("GetByIdWithRelatedData/{id}")]
        public async Task<IActionResult> GetByIdWithRelatedData(string id)
        {
            _logger.LogInformation($"GetByIdWithRelatedData called with ID: {id}");

            var 판매자 = await _repository.GetByIdWithRelatedData(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }

        [HttpGet("GetAllWith판매자상품")]
        public async Task<IActionResult> GetAllWith판매자상품()
        {
            _logger.LogInformation("GetAllWith판매자상품 called");

            var 판매자List = await _repository.GetAllWith판매자상품();
            var 판매자DTOs = _mapper.Map<List<Read판매자DTO>>(판매자List);
            return Ok(판매자DTOs);
        }

        [HttpGet("GetAllWith주문")]
        public async Task<IActionResult> GetAllWith주문()
        {
            _logger.LogInformation("GetAllWith주문 called");

            var 판매자List = await _repository.GetAllWith주문();
            var 판매자DTOs = _mapper.Map<List<Read판매자DTO>>(판매자List);
            return Ok(판매자DTOs);
        }

        [HttpGet("GetByIdWith상품문의/{id}")]
        public async Task<IActionResult> GetByIdWith상품문의(string id)
        {
            _logger.LogInformation($"GetByIdWith상품문의 called with ID: {id}");

            var 판매자 = await _repository.GetByIdWith상품문의(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }

        [HttpGet("GetByIdWith댓글/{id}")]
        public async Task<IActionResult> GetByIdWith댓글(string id)
        {
            _logger.LogInformation($"GetByIdWith댓글 called with ID: {id}");

            var 판매자 = await _repository.GetByIdWith댓글(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }

        [HttpGet("GetByIdWith할일목록/{id}")]
        public async Task<IActionResult> GetByIdWith할일목록(string id)
        {
            _logger.LogInformation($"GetByIdWith할일목록 called with ID: {id}");

            var 판매자 = await _repository.GetByIdWith할일목록(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }

        [HttpGet("GetByIdWith주문자구매요약/{id}")]
        public async Task<IActionResult> GetByIdWith주문자구매요약(string id)
        {
            _logger.LogInformation($"GetByIdWith주문자구매요약 called with ID: {id}");

            var 판매자 = await _repository.GetByIdWith주문자구매요약(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }

        [HttpGet("GetByIdWith판매자상품판매정보요약/{id}")]
        public async Task<IActionResult> GetByIdWith판매자상품판매정보요약(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자상품판매정보요약 called with ID: {id}");

            var 판매자 = await _repository.GetByIdWith판매자상품판매정보요약(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }

        [HttpGet("GetByIdWith판매자판매정보요약/{id}")]
        public async Task<IActionResult> GetByIdWith판매자판매정보요약(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자판매정보요약 called with ID: {id}");

            var 판매자 = await _repository.GetByIdWith판매자판매정보요약(id);
            if (판매자 == null)
                return NotFound();

            var 판매자DTO = _mapper.Map<Read판매자DTO>(판매자);
            return Ok(판매자DTO);
        }
    }
}
