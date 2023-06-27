using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using 수협Common.DTO;
using 수협Common.Model;
using 수협Common.Repository;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산협동조합Controller : ControllerBase
    {
        private readonly 수산협동조합Repository _repository;
        private readonly IMapper _mapper;

        public 수산협동조합Controller(수산협동조합Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Read수산협동조합DTO>> Get수산협동조합(string id)
        {
            var 수산협동조합 = await _repository.GetByCode(id);

            if (수산협동조합 == null)
            {
                return NotFound();
            }

            var 수산협동조합DTO = _mapper.Map<Read수산협동조합DTO>(수산협동조합);
            return Ok(수산협동조합DTO);
        }

        [HttpGet("with-창고")]
        public async Task<ActionResult<List<Read수산협동조합DTO>>> GetToList수산협동조합With창고()
        {
            var 수산협동조합List = await _repository.GetToListWith수산창고Async();
            var 수산협동조합DTOList = _mapper.Map<List<Read수산협동조합DTO>>(수산협동조합List);
            return Ok(수산협동조합DTOList);
        }

        [HttpPost]
        public async Task<ActionResult> Create수산협동조합(Create수산협동조합DTO 수산협동조합DTO)
        {
            var 수산협동조합 = _mapper.Map<수산협동조합>(수산협동조합DTO);
            await _repository.AddAsync(수산협동조합);
            var created수산협동조합DTO = _mapper.Map<Read수산협동조합DTO>(수산협동조합);
            return Ok(created수산협동조합DTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update수산협동조합(string id, Update수산협동조합DTO updated수산협동조합DTO)
        {
            var existing수산협동조합 = await _repository.GetByCode(id);

            if (existing수산협동조합 == null)
            {
                return NotFound();
            }

            var model = _mapper.Map(updated수산협동조합DTO, existing수산협동조합);
            await _repository.UpdateAsync(existing수산협동조합);
            var DTO = _mapper.Map<Read수산협동조합DTO>(existing수산협동조합);
            return Ok(DTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete수산협동조합(string id)
        {
            var existing수산협동조합 = await _repository.GetByCode(id);

            if (existing수산협동조합 == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(existing수산협동조합);
            return NoContent();
        }
    }

}
