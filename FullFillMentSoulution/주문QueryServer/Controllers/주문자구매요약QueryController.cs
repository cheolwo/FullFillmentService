using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.주문자구매요약;
using 주문Common.Model;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문자구매요약QueryController : EntityQueryController<주문자구매요약, Read주문자구매요약DTO>
    {
        private readonly I주문자구매요약QueryRepository _repository;

        public 주문자구매요약QueryController(IMapper mapper, I주문자구매요약QueryRepository repository,
            MemoryModule<주문자구매요약> memoryModule, ILogger<EntityQueryController<주문자구매요약, Read주문자구매요약DTO>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("{id}/with판매자상품판매정보요약")]
        public async Task<ActionResult<Read주문자구매요약DTO>> GetByIdWith판매자상품판매정보요약(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자상품판매정보요약(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문자구매요약 entity by Id '{id}' with 판매자상품판매정보요약 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자구매요약 entity by Id '{id}' with 판매자상품판매정보요약 from the cache.");
            }

            var dto = _mapper.Map<Read주문자구매요약DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자")]
        public async Task<ActionResult<Read주문자구매요약DTO>> GetByIdWith판매자(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문자구매요약 entity by Id '{id}' with 판매자 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자구매요약 entity by Id '{id}' with 판매자 from the cache.");
            }

            var dto = _mapper.Map<Read주문자구매요약DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자상품")]
        public async Task<ActionResult<Read주문자구매요약DTO>> GetByIdWith판매자상품(string id)
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
                _logger.LogInformation($"Fetched 주문자구매요약 entity by Id '{id}' with 판매자상품 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자구매요약 entity by Id '{id}' with 판매자상품 from the cache.");
            }

            var dto = _mapper.Map<Read주문자구매요약DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with주문자")]
        public async Task<ActionResult<Read주문자구매요약DTO>> GetByIdWith주문자(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith주문자(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문자구매요약 entity by Id '{id}' with 주문자 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자구매요약 entity by Id '{id}' with 주문자 from the cache.");
            }

            var dto = _mapper.Map<Read주문자구매요약DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/withRelatedData")]
        public async Task<ActionResult<Read주문자구매요약DTO>> GetByIdWithRelatedData(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWithRelatedData(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문자구매요약 entity by Id '{id}' with related data from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자구매요약 entity by Id '{id}' with related data from the cache.");
            }

            var dto = _mapper.Map<Read주문자구매요약DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("list/by판매자Id/{판매자Id}")]
        public async Task<ActionResult<List<Read주문자구매요약DTO>>> GetToListBy판매자Id(string 판매자Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자Id == 판매자Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자Id(판매자Id);
                _memoryModule.SetEntities(entities);
            }

            var dtos = _mapper.Map<List<Read주문자구매요약DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/by구매일시/{구매일시}")]
        public async Task<ActionResult<List<Read주문자구매요약DTO>>> GetToListBy구매일시(DateTime 구매일시)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.구매일시 == 구매일시).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy구매일시(구매일시);
                _memoryModule.SetEntities(entities);
            }

            var dtos = _mapper.Map<List<Read주문자구매요약DTO>>(entities);
            return Ok(dtos);
        }
    }
}
