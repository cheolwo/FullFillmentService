using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using 수협Common.DTO;
using 수협Common.Model;
using 수협Common.Repository;

namespace 수협QueryServer.Controllers
{
    /// <summary>
    /// 수산조합과 창고는 데이터 특성상 Code가 Id임을 기억
    /// </summary>
    /// <param name="조합id"></param>
    /// <returns></returns>
    [Route("api/[controller]")]
    [ApiController]
    public class 수산창고QueryController : CenterQueryController<수산창고, Read수산창고DTO>
    {
        private readonly I수산창고QueryRepository _repository;
        public 수산창고QueryController(I수산창고QueryRepository repository, 
            IMapper mapper, 
            MemoryModule<수산창고> memoryModule, 
            ILogger<CenterQueryController<수산창고, 
            Read수산창고DTO>> logger) : base(repository, mapper, memoryModule, logger)
        {
            _repository = repository;
        }
        [HttpGet("list/수산창고With수산품목종류")]
        public async Task<ActionResult<List<Read수산창고DTO>>> GetToList수산창고With수산품목종류()
        {
            var entities = _memoryModule.GetEntities();
            if (!entities.Any())
            {
                entities = await _repository.GetToList수산창고With수산품목종류Async();
                _memoryModule.SetEntities(entities);

                _logger.LogInformation("Fetched 수산창고With수산품목종류 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation("Retrieved 수산창고With수산품목종류 from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산창고DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("{id}/with수산품별재고현황")]
        public async Task<ActionResult<Read수산창고DTO>> GetByIdWith수산품별재고현황(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith수산품별재고현황Async(id);

                if (entity == null)
                {
                    _logger.LogInformation($"수산창고 with ID '{id}' not found.");
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched and cached 수산창고 with ID '{id}'.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산창고 with ID '{id}' from the cache.");
            }

            var dto = _mapper.Map<Read수산창고DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("list/by조합Id/{조합id}")]
        public async Task<ActionResult<List<Read수산창고DTO>>> GetToListBy조합Id(string 조합id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.Code == 조합id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy조합IdAsync(조합id);
                _memoryModule.SetEntities(entities);

                _logger.LogInformation($"Fetched 수산창고 by 조합 ID '{조합id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산창고 by 조합 ID '{조합id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산창고DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("{id}/with수산조합")]
        public async Task<ActionResult<Read수산창고DTO>> GetByIdWith수산조합(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith수산조합(id);

                if (entity == null)
                {
                    _logger.LogInformation($"수산창고 with ID '{id}' not found.");
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched and cached 수산창고 with ID '{id}'.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산창고 with ID '{id}' from the cache.");
            }

            var dto = _mapper.Map<Read수산창고DTO>(entity);
            return Ok(dto);
        }
    }
}
