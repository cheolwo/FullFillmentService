using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.할일목록;
using 주문Common.Model;

namespace 주문Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 할일목록Controller : ControllerBase
    {
        private readonly 할일목록Repository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<할일목록Controller> _logger;

        public 할일목록Controller(할일목록Repository repository, IMapper mapper, ILogger<할일목록Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create할일목록DTO 할일목록DTO)
        {
            _logger.LogInformation("Create called");

            if (할일목록DTO == null)
                return BadRequest();

            var 할일목록 = _mapper.Map<할일목록>(할일목록DTO);
            await _repository.AddAsync(할일목록);

            var created할일목록DTO = _mapper.Map<Read할일목록DTO>(할일목록);
            return CreatedAtAction(nameof(GetById), new { id = created할일목록DTO.Id }, created할일목록DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update할일목록DTO updated할일목록DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated할일목록DTO == null || id != updated할일목록DTO.Id)
                return BadRequest();

            var existing할일목록 = await _repository.GetAsync(id);
            if (existing할일목록 == null)
                return NotFound();

            _mapper.Map(updated할일목록DTO, existing할일목록);

            await _repository.UpdateAsync(existing할일목록);

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation($"GetById called with ID: {id}");

            var 할일목록 = await _repository.GetAsync(id);
            if (할일목록 == null)
                return NotFound();

            var 할일목록DTO = _mapper.Map<Read할일목록DTO>(할일목록);
            return Ok(할일목록DTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing할일목록 = await _repository.GetAsync(id);
            if (existing할일목록 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("GetBy판매자IdAnd주문Id/{판매자Id}/{주문Id}")]
        public async Task<IActionResult> GetBy판매자IdAnd주문Id(string 판매자Id, string 주문Id)
        {
            _logger.LogInformation($"GetBy판매자IdAnd주문Id called with 판매자Id: {판매자Id}, 주문Id: {주문Id}");

            var 할일목록List = await _repository.GetToListBy판매자IdAnd주문Id(판매자Id, 주문Id);
            var 할일목록DTOs = _mapper.Map<List<Read할일목록DTO>>(할일목록List);
            return Ok(할일목록DTOs);
        }

        [HttpGet("GetBy판매자IdWithPriorityDescending/{판매자Id}")]
        public async Task<IActionResult> GetBy판매자IdWithPriorityDescending(string 판매자Id)
        {
            _logger.LogInformation($"GetBy판매자IdWithPriorityDescending called with 판매자Id: {판매자Id}");

            var 할일목록List = await _repository.GetToListBy판매자IdWithPriorityDescending(판매자Id);
            var 할일목록DTOs = _mapper.Map<List<Read할일목록DTO>>(할일목록List);
            return Ok(할일목록DTOs);
        }

        [HttpGet("GetBy주문IdAndStatus/{주문Id}/{상태}")]
        public async Task<IActionResult> GetBy주문IdAndStatus(string 주문Id, string 상태)
        {
            _logger.LogInformation($"GetBy주문IdAndStatus called with 주문Id: {주문Id}, 상태: {상태}");

            var 할일목록List = await _repository.GetToListBy주문IdAndStatus(주문Id, 상태);
            var 할일목록DTOs = _mapper.Map<List<Read할일목록DTO>>(할일목록List);
            return Ok(할일목록DTOs);
        }

        [HttpGet("GetBy판매자IdAndStatus/{판매자Id}/{상태}")]
        public async Task<IActionResult> GetBy판매자IdAndStatus(string 판매자Id, string 상태)
        {
            _logger.LogInformation($"GetBy판매자IdAndStatus called with 판매자Id: {판매자Id}, 상태: {상태}");

            var 할일목록List = await _repository.GetToListBy판매자IdAndStatus(판매자Id, 상태);
            var 할일목록DTOs = _mapper.Map<List<Read할일목록DTO>>(할일목록List);
            return Ok(할일목록DTOs);
        }
    }
}
