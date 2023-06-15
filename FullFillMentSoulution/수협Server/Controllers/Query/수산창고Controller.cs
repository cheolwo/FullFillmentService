using AutoMapper;
using KoreaCommon.Model;
using Microsoft.AspNetCore.Mvc;
using 수협Common.DTO;
using 수협Common.Repository;

namespace 수협Server.Controllers.Query
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산창고Controller : ControllerBase
    {
        private readonly 수산창고Repository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<수산창고Controller> _logger;

        public 수산창고Controller(수산창고Repository repository, IMapper mapper, ILogger<수산창고Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 수산창고List = await _repository.ListAsync();
            var 수산창고DTOList = _mapper.Map<List<Read수산창고DTO>>(수산창고List);
            return Ok(수산창고DTOList);
        }

        [HttpGet("With수산품목종류")]
        public async Task<IActionResult> Get수산창고With수산품목종류Async()
        {
            var 수산창고List = await _repository.GetToList수산창고With수산품목종류Async();
            if (수산창고List == null || 수산창고List.Count == 0)
                return NotFound();

            var 수산창고DTOList = _mapper.Map<List<Read수산창고DTO>>(수산창고List);
            return Ok(수산창고DTOList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 수산창고 = await _repository.GetAsync(id);
            if (수산창고 == null)
                return NotFound();

            var 수산창고DTO = _mapper.Map<Read수산창고DTO>(수산창고);
            return Ok(수산창고DTO);
        }

        [HttpGet("{id}/수산품별재고현황")]
        public async Task<IActionResult> GetWith수산품별재고현황(string id)
        {
            var 수산창고 = await _repository.GetByIdWith수산품별재고현황Async(id);
            if (수산창고 == null)
                return NotFound();

            var 수산창고DTO = _mapper.Map<Read수산창고DTO>(수산창고);
            return Ok(수산창고DTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create수산창고DTO 수산창고DTO)
        {
            if (수산창고DTO == null)
                return BadRequest();

            var 수산창고 = _mapper.Map<수산창고>(수산창고DTO);
            await _repository.AddAsync(수산창고);

            var created수산창고DTO = _mapper.Map<Read수산창고DTO>(수산창고);
            return CreatedAtAction(nameof(GetById), new { id = created수산창고DTO.Id }, created수산창고DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update수산창고DTO updated수산창고DTO)
        {
            if (updated수산창고DTO == null || id != updated수산창고DTO.Id)
                return BadRequest();

            var existing수산창고 = await _repository.GetAsync(id);
            if (existing수산창고 == null)
                return NotFound();

            _mapper.Map(updated수산창고DTO, existing수산창고);
            await _repository.UpdateAsync(existing수산창고);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing수산창고 = await _repository.GetAsync(id);
            if (existing수산창고 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
