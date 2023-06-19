using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using 수협Common.Model;
using 수협Common.DTO;
using AutoMapper;
using Common.Cache;
using 수협Common.Repository;

namespace 수협QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산품QueryController : EntityQueryController<수산품, Read수산품DTO>
    {
        private readonly I수산품QueryRepository _repository;

        public 수산품QueryController(IMapper mapper, I수산품QueryRepository repository, MemoryModule<수산품> memoryModule, ILogger<EntityQueryController<수산품, Read수산품DTO>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("list/수산품By수산창고Id/{수산창고Id}")]
        public async Task<ActionResult<List<Read수산품DTO>>> GetToList수산품By수산창고Id(string 수산창고Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.Code == 수산창고Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToList수산품By수산창고IdAsync(수산창고Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품 by 수산창고 ID '{수산창고Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품 by 수산창고 ID '{수산창고Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/수산품By조합Id/{조합Id}")]
        public async Task<ActionResult<List<Read수산품DTO>>> GetToList수산품By조합Id(string 조합Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.수협Id == 조합Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToList수산품By조합IdAsync(조합Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품 by 조합 ID '{조합Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품 by 조합 ID '{조합Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/수산품이름ByDistinct")]
        public async Task<ActionResult<List<string?>>> GetToList수산품이름ByDistinct()
        {
            var distinctNames = await _repository.GetToList수산품이름ByDistinct();
            _logger.LogInformation("Fetched distinct 수산품 names from the repository.");

            return Ok(distinctNames);
        }
    }
}
