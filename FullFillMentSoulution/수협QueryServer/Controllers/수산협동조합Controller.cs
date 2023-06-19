using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using 수협Common.DTO;
using 수협Common.Model;
using 수협Common.Repository;

namespace 수협QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산협동조합QueryController : CenterQueryController<수산협동조합, Read수산협동조합DTO>
    {
        protected readonly I수산협동조합QueryRepository _repository;
        public 수산협동조합QueryController(I수산협동조합QueryRepository repository, IMapper mapper, 
            MemoryModule<수산협동조합> memoryModule, ILogger<CenterQueryController<수산협동조합, Read수산협동조합DTO>> logger) : base(repository, mapper, memoryModule, logger)
        {
            _repository = repository;
        }
        [HttpGet("{id}/with수산창고")]
        public async Task<ActionResult<Read수산협동조합DTO>> GetByIdWith수산창고(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith수산창고Async(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 수산협동조합 with 수산창고 by Id '{id}' from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산협동조합 with 수산창고 by Id '{id}' from the cache.");
            }

            var dto = _mapper.Map<Read수산협동조합DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("list/with수산창고")]
        public async Task<ActionResult<List<Read수산협동조합DTO>>> GetToListWith수산창고()
        {
            var entities = _memoryModule.GetEntities();
            if (!entities.Any())
            {
                entities = await _repository.GetToListWith수산창고Async();
                _memoryModule.SetEntities(entities);
                _logger.LogInformation("Fetched 수산협동조합 with 수산창고 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation("Retrieved 수산협동조합 with 수산창고 from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산협동조합DTO>>(entities);
            return Ok(dtos);
        }
    }
}
