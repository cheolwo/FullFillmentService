using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.판매자상품;
using 주문Common.Model;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 판매자상품QueryController : CommodityQueryController<판매자상품, Read판매자상품DTO>
    {
        private readonly I판매자상품QueryRepository _repository;

        public 판매자상품QueryController(I판매자상품QueryRepository repository, IMapper mapper,
            MemoryModule<판매자상품> memoryModule, ILogger<CommodityQueryController<판매자상품, Read판매자상품DTO>> logger)
            : base(repository, mapper, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("{id}/with상품문의")]
        public async Task<ActionResult<Read판매자상품DTO>> GetByIdWith상품문의(string id)
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
                _logger.LogInformation($"Fetched 판매자상품 entity by Id '{id}' with 상품문의 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entity by Id '{id}' with 상품문의 from the cache.");
            }

            var dto = _mapper.Map<Read판매자상품DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with주문")]
        public async Task<ActionResult<Read판매자상품DTO>> GetByIdWith주문(string id)
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
                _logger.LogInformation($"Fetched 판매자상품 entity by Id '{id}' with 주문 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entity by Id '{id}' with 주문 from the cache.");
            }

            var dto = _mapper.Map<Read판매자상품DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자")]
        public async Task<ActionResult<Read판매자상품DTO>> GetByIdWith판매자(string id)
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
                _logger.LogInformation($"Fetched 판매자상품 entity by Id '{id}' with 판매자 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entity by Id '{id}' with 판매자 from the cache.");
            }

            var dto = _mapper.Map<Read판매자상품DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with판매자And주문")]
        public async Task<ActionResult<Read판매자상품DTO>> GetByIdWith판매자And주문(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith판매자And주문(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 판매자상품 entity by Id '{id}' with 판매자 and 주문 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entity by Id '{id}' with 판매자 and 주문 from the cache.");
            }

            var dto = _mapper.Map<Read판매자상품DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("price/above/{price}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetByPriceAbove(double price)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.Price > price).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetByPriceAbove(price);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with price above '{price}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with price above '{price}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("price/below/{price}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetByPriceBelow(double price)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.Price < price).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetByPriceBelow(price);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with price below '{price}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with price below '{price}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("price/range/{minPrice}/{maxPrice}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetByPriceInRange(double minPrice, double maxPrice)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.Price >= minPrice && e.Price <= maxPrice).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetByPriceInRange(minPrice, maxPrice);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with price in the range '{minPrice}' to '{maxPrice}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with price in the range '{minPrice}' to '{maxPrice}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("saleDate/before/{date}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetBySaleDateBefore(string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "yyyyMMdd", null);
            var entities = _memoryModule.GetEntities().Where(e => e.판매개시일자 < date).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetBySaleDateBefore(date);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with sale date before '{date}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with sale date before '{date}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("saleDate/after/{date}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetBySaleDateAfter(string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "yyyyMMdd", null);
            var entities = _memoryModule.GetEntities().Where(e => e.판매개시일자 > date).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetBySaleDateAfter(date);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with sale date after '{date}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with sale date after '{date}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("saleDate/{startDate}/{endDate}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetBySaleDate(string startDateString, string endDateString)
        {
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyyMMdd", null);
            DateTime endDate = DateTime.ParseExact(endDateString, "yyyyMMdd", null);
            var entities = _memoryModule.GetEntities().Where(e => e.판매개시일자 >= startDate && e.판매개시일자 <= endDate).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetBySaleDate(startDateString, endDateString);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with sale date in the range '{startDate}' to '{endDate}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with sale date in the range '{startDate}' to '{endDate}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("saleDate/before/{saleDate}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetBySaleDateBefore(DateTime saleDate)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매개시일자 < saleDate).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetBySaleDateBefore(saleDate);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with sale date before '{saleDate}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with sale date before '{saleDate}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("saleDate/after/{saleDate}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetBySaleDateAfter(DateTime saleDate)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매개시일자 > saleDate).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetBySaleDateAfter(saleDate);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with sale date after '{saleDate}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with sale date after '{saleDate}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("saleDate/{startDate}/{endDate}")]
        public async Task<ActionResult<List<Read판매자상품DTO>>> GetBySaleDateRange(DateTime startDate, DateTime endDate)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매개시일자 >= startDate && e.판매개시일자 <= endDate).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetBySaleDateRange(startDate, endDate);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 판매자상품 entities with sale date in the range '{startDate}' to '{endDate}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 판매자상품 entities with sale date in the range '{startDate}' to '{endDate}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read판매자상품DTO>>(entities);
            return Ok(dtos);
        }
    }
}
