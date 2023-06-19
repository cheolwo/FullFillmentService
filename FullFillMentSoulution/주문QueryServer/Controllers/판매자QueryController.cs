using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.판매자;
using 주문Common.Model;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 판매자QueryController : CenterQueryController<판매자, Read판매자DTO>
    {
        private readonly I판매자QueryRepository _repository;

        public 판매자QueryController(I판매자QueryRepository repository, IMapper mapper, MemoryModule<판매자> memoryModule, ILogger<CenterQueryController<판매자, Read판매자DTO>> logger)
            : base(repository, mapper, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("{id}/with판매자상품")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWith판매자상품(string id)
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
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with 판매자상품 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with 판매자상품 from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with주문")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWith주문(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith주문(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with 주문 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with 주문 from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/withRelatedData")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWithRelatedData(string id)
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
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with related data from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with related data from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("with판매자상품")]
        public async Task<ActionResult<List<Read판매자DTO>>> GetAllWith판매자상품()
        {
            var entities = _memoryModule.GetEntities();
            if (!entities.Any())
            {
                entities = await _repository.GetAllWith판매자상품();
                _memoryModule.SetEntities(entities);
                _logger.LogInformation("Fetched all 판매자 entities with 판매자상품 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation("Retrieved all 판매자 entities with 판매자상품 from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("with주문")]
        public async Task<ActionResult<List<Read판매자DTO>>> GetAllWith주문()
        {
            var entities = _memoryModule.GetEntities();
            if (!entities.Any())
            {
                entities = await _repository.GetAllWith주문();
                _memoryModule.SetEntities(entities);
                _logger.LogInformation("Fetched all 판매자 entities with 주문 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation("Retrieved all 판매자 entities with 주문 from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("{id}/with상품문의")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWith상품문의(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith상품문의(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with 상품문의 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with 상품문의 from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with댓글")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWith댓글(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith댓글(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with 댓글 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with 댓글 from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with할일목록")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWith할일목록(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith할일목록(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with 할일목록 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with 할일목록 from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with주문자구매요약")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWith주문자구매요약(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith주문자구매요약(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with 주문자구매요약 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with 주문자구매요약 from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자상품판매정보요약")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWith판매자상품판매정보요약(string id)
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
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with 판매자상품판매정보요약 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with 판매자상품판매정보요약 from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자판매정보요약")]
        public async Task<ActionResult<Read판매자DTO>> GetByIdWith판매자판매정보요약(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자판매정보요약(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자 entity by Id '{id}' with 판매자판매정보요약 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자 entity by Id '{id}' with 판매자판매정보요약 from the cache.");
            }

            var dto = _mapper.Map<Read판매자DTO>(entity);
            return Ok(dto);
        }
    }

}
