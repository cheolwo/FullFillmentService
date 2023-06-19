using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.판매자상품판매정보요약;
using 주문Common.Model;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 판매자상품판매정보요약QueryController : EntityQueryController<판매자상품판매정보요약, Read판매자상품판매정보요약DTO>
    {
        private readonly I판매자상품판매정보요약QueryRepository _repository;

        public 판매자상품판매정보요약QueryController(IMapper mapper, I판매자상품판매정보요약QueryRepository repository,
            MemoryModule<판매자상품판매정보요약> memoryModule, ILogger<EntityQueryController<판매자상품판매정보요약, Read판매자상품판매정보요약DTO>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("{id}/with판매자And주문자구매요약")]
        public async Task<ActionResult<Read판매자상품판매정보요약DTO>> GetByIdWith판매자And주문자구매요약(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자And주문자구매요약(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자상품판매정보요약 entity by Id '{id}' with 판매자 and 주문자구매요약 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품판매정보요약 entity by Id '{id}' with 판매자 and 주문자구매요약 from the cache.");
            }

            var dto = _mapper.Map<Read판매자상품판매정보요약DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("by판매자Id/{판매자Id}")]
        public async Task<ActionResult<List<Read판매자상품판매정보요약DTO>>> GetToListBy판매자Id(string 판매자Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자Id == 판매자Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자Id(판매자Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품판매정보요약 entities by 판매자Id '{판매자Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품판매정보요약 entities by 판매자Id '{판매자Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품판매정보요약DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("{id}/with판매자상품")]
        public async Task<ActionResult<Read판매자상품판매정보요약DTO>> GetByIdWith판매자상품(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자상품(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자상품판매정보요약 entity by Id '{id}' with 판매자상품 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품판매정보요약 entity by Id '{id}' with 판매자상품 from the cache.");
            }

            var dto = _mapper.Map<Read판매자상품판매정보요약DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자상품And주문자구매요약")]
        public async Task<ActionResult<Read판매자상품판매정보요약DTO>> GetByIdWith판매자상품And주문자구매요약(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자상품And주문자구매요약(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자상품판매정보요약 entity by Id '{id}' with 판매자상품 and 주문자구매요약 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품판매정보요약 entity by Id '{id}' with 판매자상품 and 주문자구매요약 from the cache.");
            }

            var dto = _mapper.Map<Read판매자상품판매정보요약DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("by판매자상품Id/{판매자상품Id}")]
        public async Task<ActionResult<List<Read판매자상품판매정보요약DTO>>> GetToListBy판매자상품Id(string 판매자상품Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자상품Id == 판매자상품Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자상품Id(판매자상품Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품판매정보요약 entities by 판매자상품Id '{판매자상품Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품판매정보요약 entities by 판매자상품Id '{판매자상품Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품판매정보요약DTO>>(entities);
            return Ok(dtos);
        }
    }
}
