using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.For주문;
using 주문Common.Model;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문QueryController : CommodityQueryController<주문, Read주문DTO>
    {
        private readonly I주문QueryRepository _repository;

        public 주문QueryController(I주문QueryRepository repository, IMapper mapper,
            MemoryModule<주문> memoryModule, ILogger<CommodityQueryController<주문, Read주문DTO>> logger)
            : base(repository, mapper, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("{id}/with판매자상품")]
        public async Task<ActionResult<Read주문DTO>> GetByIdWith판매자상품(string id)
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
                _logger.LogInformation($"Fetched 주문 entity by Id '{id}' with 판매자상품 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문 entity by Id '{id}' with 판매자상품 from the cache.");
            }

            var dto = _mapper.Map<Read주문DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with주문자")]
        public async Task<ActionResult<Read주문DTO>> GetByIdWith주문자(string id)
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
                _logger.LogInformation($"Fetched 주문 entity by Id '{id}' with 주문자 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문 entity by Id '{id}' with 주문자 from the cache.");
            }

            var dto = _mapper.Map<Read주문DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자")]
        public async Task<ActionResult<Read주문DTO>> GetByIdWith판매자(string id)
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
                _logger.LogInformation($"Fetched 주문 entity by Id '{id}' with 판매자 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문 entity by Id '{id}' with 판매자 from the cache.");
            }

            var dto = _mapper.Map<Read주문DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자And판매자상품")]
        public async Task<ActionResult<Read주문DTO>> GetByIdWith판매자And판매자상품(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자And판매자상품(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문 entity by Id '{id}' with 판매자 and 판매자상품 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문 entity by Id '{id}' with 판매자 and 판매자상품 from the cache.");
            }

            var dto = _mapper.Map<Read주문DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자And판매자상품And주문자")]
        public async Task<ActionResult<Read주문DTO>> GetByIdWith판매자And판매자상품And주문자(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자And판매자상품And주문자(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문 entity by Id '{id}' with 판매자, 판매자상품, and 주문자 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문 entity by Id '{id}' with 판매자, 판매자상품, and 주문자 from the cache.");
            }

            var dto = _mapper.Map<Read주문DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("price/above/{price}")]
        public async Task<ActionResult<List<Read주문DTO>>> GetByPriceAbove(double price)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.Price > price).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetByPriceAbove(price);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 주문 entities with price above '{price}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문 entities with price above '{price}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read주문DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("price/below/{price}")]
        public async Task<ActionResult<List<Read주문DTO>>> GetByPriceBelow(double price)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.Price < price).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetByPriceBelow(price);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 주문 entities with price below '{price}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문 entities with price below '{price}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read주문DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("price/range/{minPrice}/{maxPrice}")]
        public async Task<ActionResult<List<Read주문DTO>>> GetByPriceInRange(double minPrice, double maxPrice)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.Price >= minPrice && e.Price <= maxPrice).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetByPriceInRange(minPrice, maxPrice);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 주문 entities with price in the range '{minPrice}' to '{maxPrice}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문 entities with price in the range '{minPrice}' to '{maxPrice}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read주문DTO>>(entities);
            return Ok(dtos);
        }
    }
}
