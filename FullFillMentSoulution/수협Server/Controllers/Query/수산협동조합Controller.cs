using AutoMapper;
using Common.Model;
using KoreaCommon.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using 수협Common.DTO;
using 수협Common.Repository;

namespace 수협Server.Controllers.Query
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
        [HttpGet("address/{address}")]
        public async Task<ActionResult<TEntity>> GetByAddress(string address)
        {
            var entity = await _repository.GetByAddress(address);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<TEntity>> GetByEmail(string email)
        {
            var entity = await _repository.GetByEmail(email);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("faxNumber/{faxNumber}")]
        public async Task<ActionResult<TEntity>> GetByFaxNumber(string faxNumber)
        {
            var entity = await _repository.GetByFaxNumber(faxNumber);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("phoneNumber/{phoneNumber}")]
        public async Task<ActionResult<TEntity>> GetByPhoneNumber(string phoneNumber)
        {
            var entity = await _repository.GetByPhoneNumber(phoneNumber);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
    }

}
