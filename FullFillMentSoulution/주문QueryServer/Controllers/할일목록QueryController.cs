using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.할일목록;
using 주문Common.Model;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 할일목록QueryController : EntityQueryController<할일목록, Read할일목록DTO>
    {
        private readonly I할일목록QueryRepository _repository;
        public 할일목록QueryController(IMapper mapper, I할일목록QueryRepository repository, MemoryModule<할일목록> memoryModule, ILogger<EntityQueryController<할일목록, Read할일목록DTO>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("by판매자IdAnd주문Id")]
        public async Task<ActionResult<List<Read할일목록DTO>>> GetToListBy판매자IdAnd주문Id(string 판매자Id, string 주문Id)
        {
            var entities = _memoryModule.GetEntities();

            if (entities == null)
            {
                entities = await _repository.GetToListBy판매자IdAnd주문Id(판매자Id, 주문Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 할일목록 entities by 판매자Id '{판매자Id}' and 주문Id '{주문Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 할일목록 entities by 판매자Id '{판매자Id}' and 주문Id '{주문Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read할일목록DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("by판매자IdWithPriorityDescending/{판매자Id}")]
        public async Task<ActionResult<List<Read할일목록DTO>>> GetToListBy판매자IdWithPriorityDescending(string 판매자Id)
        {
            var entities = _memoryModule.GetEntities();

            if (entities == null)
            {
                entities = await _repository.GetToListBy판매자IdWithPriorityDescending(판매자Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 할일목록 entities by 판매자Id '{판매자Id}' with priority descending from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 할일목록 entities by 판매자Id '{판매자Id}' with priority descending from the cache.");
            }

            var dtos = _mapper.Map<List<Read할일목록DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("by주문IdAndStatus")]
        public async Task<ActionResult<List<Read할일목록DTO>>> GetToListBy주문IdAndStatus(string 주문Id, string 상태)
        {          
            var entities = _memoryModule.GetEntities();

            if (entities == null)
            {
                entities = await _repository.GetToListBy주문IdAndStatus(주문Id, 상태);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 할일목록 entities by 주문Id '{주문Id}' and 상태 '{상태}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 할일목록 entities by 주문Id '{주문Id}' and 상태 '{상태}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read할일목록DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("by판매자IdAndStatus")]
        public async Task<ActionResult<List<Read할일목록DTO>>> GetToListBy판매자IdAndStatus(string 판매자Id, string 상태)
        {
            var entities = _memoryModule.GetEntities();

            if (entities == null)
            {
                entities = await _repository.GetToListBy판매자IdAndStatus(판매자Id, 상태);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 할일목록 entities by 판매자Id '{판매자Id}' and 상태 '{상태}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 할일목록 entities by 판매자Id '{판매자Id}' and 상태 '{상태}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read할일목록DTO>>(entities);
            return Ok(dtos);
        }
    }
}
