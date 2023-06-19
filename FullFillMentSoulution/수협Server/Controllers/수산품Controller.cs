using AutoMapper;
using KoreaCommon.Model;
using Microsoft.AspNetCore.Mvc;
using 수협Common.DTO;
using 수협Common.Repository;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산품Controller : ControllerBase
    {
        private readonly 수산품Repository _repository;
        private readonly IMapper _mapper;

        public 수산품Controller(수산품Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 수산품List = await _repository.ListAsync();
            var 수산품DTOList = _mapper.Map<List<Read수산품DTO>>(수산품List);
            return Ok(수산품DTOList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 수산품 = await _repository.GetAsync(id);
            if (수산품 == null)
                return NotFound();

            var 수산품DTO = _mapper.Map<Read수산품DTO>(수산품);
            return Ok(수산품DTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create수산품DTO 수산품DTO)
        {
            if (수산품DTO == null)
                return BadRequest();

            var 수산품 = _mapper.Map<수산품>(수산품DTO);

            await _repository.AddAsync(수산품);

            var created수산품DTO = _mapper.Map<Read수산품DTO>(수산품);
            return CreatedAtAction(nameof(GetById), new { id = created수산품DTO.Code }, created수산품DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update수산품DTO updated수산품DTO)
        {
            if (updated수산품DTO == null || id != updated수산품DTO.Code)
                return BadRequest();

            var existing수산품 = await _repository.GetAsync(id);
            if (existing수산품 == null)
                return NotFound();

            _mapper.Map(updated수산품DTO, existing수산품);

            await _repository.UpdateAsync(existing수산품);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing수산품 = await _repository.GetAsync(id);
            if (existing수산품 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
