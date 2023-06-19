using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.상품문의;
using 주문Common.Model;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 상품문의QueryController : EntityQueryController<상품문의, Read상품문의DTO>
    {
        private readonly I상품문의QueryRepository _repository;

        public 상품문의QueryController(IMapper mapper, I상품문의QueryRepository repository,
            MemoryModule<상품문의> memoryModule, ILogger<EntityQueryController<상품문의, Read상품문의DTO>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("판매자상품/{판매자상품Id}")]
        public async Task<ActionResult<List<Read상품문의DTO>>> GetToListBy판매자상품Id(string 판매자상품Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자상품Id == 판매자상품Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자상품Id(판매자상품Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 상품문의 entities by 판매자상품Id '{판매자상품Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 상품문의 entities by 판매자상품Id '{판매자상품Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read상품문의DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("주문자/{주문자Id}")]
        public async Task<ActionResult<List<Read상품문의DTO>>> GetToListBy주문자Id(string 주문자Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.주문자Id == 주문자Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy주문자Id(주문자Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 상품문의 entities by 주문자Id '{주문자Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 상품문의 entities by 주문자Id '{주문자Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read상품문의DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("판매자상품/{판매자상품Id}/with판매자")]
        public async Task<ActionResult<List<Read상품문의DTO>>> GetToListBy판매자상품IdWith판매자(string 판매자상품Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자상품Id == 판매자상품Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자상품IdWith판매자(판매자상품Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 상품문의 entities by 판매자상품Id '{판매자상품Id}' with 판매자 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 상품문의 entities by 판매자상품Id '{판매자상품Id}' with 판매자 from the cache.");
            }

            var dtos = _mapper.Map<List<Read상품문의DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("주문자/{주문자Id}/with주문자")]
        public async Task<ActionResult<List<Read상품문의DTO>>> GetToListBy주문자IdWith주문자(string 주문자Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.주문자Id == 주문자Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy주문자IdWith주문자(주문자Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 상품문의 entities by 주문자Id '{주문자Id}' with 주문자 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 상품문의 entities by 주문자Id '{주문자Id}' with 주문자 from the cache.");
            }

            var dtos = _mapper.Map<List<Read상품문의DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("판매자상품/{판매자상품Id}/with주문자And판매자")]
        public async Task<ActionResult<List<Read상품문의DTO>>> GetToListBy판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자상품Id == 판매자상품Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자상품IdWith주문자And판매자(판매자상품Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 상품문의 entities by 판매자상품Id '{판매자상품Id}' with 주문자 and 판매자 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 상품문의 entities by 판매자상품Id '{판매자상품Id}' with 주문자 and 판매자 from the cache.");
            }

            var dtos = _mapper.Map<List<Read상품문의DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("주문자/{주문자Id}/with판매자상품And주문자")]
        public async Task<ActionResult<List<Read상품문의DTO>>> GetToListBy주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.주문자Id == 주문자Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy주문자IdWith판매자상품And주문자(주문자Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 상품문의 entities by 주문자Id '{주문자Id}' with 판매자상품 and 주문자 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 상품문의 entities by 주문자Id '{주문자Id}' with 판매자상품 and 주문자 from the cache.");
            }

            var dtos = _mapper.Map<List<Read상품문의DTO>>(entities);
            return Ok(dtos);
        }
    }
}
