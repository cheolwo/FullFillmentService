using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.댓글;
using 주문Common.Model;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 댓글QueryController : EntityQueryController<댓글, Read댓글DTO>
    {
        private readonly I댓글QueryRepository _repository;

        public 댓글QueryController(IMapper mapper, I댓글QueryRepository repository, MemoryModule<댓글> memoryModule, ILogger<EntityQueryController<댓글, Read댓글DTO>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("판매자상품/{판매자상품Id}")]
        public async Task<ActionResult<List<Read댓글DTO>>> GetToListBy판매자상품Id(string 판매자상품Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자상품Id == 판매자상품Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자상품Id(판매자상품Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 댓글 entities by 판매자상품Id '{판매자상품Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 댓글 entities by 판매자상품Id '{판매자상품Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read댓글DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("주문자/{주문자Id}")]
        public async Task<ActionResult<List<Read댓글DTO>>> GetToListBy주문자Id(string 주문자Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.주문자Id == 주문자Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy주문자Id(주문자Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 댓글 entities by 주문자Id '{주문자Id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 댓글 entities by 주문자Id '{주문자Id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read댓글DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("판매자상품/{판매자상품Id}/with주문자")]
        public async Task<ActionResult<List<Read댓글DTO>>> GetToListBy판매자상품IdWith주문자(string 판매자상품Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자상품Id == 판매자상품Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자상품IdWith주문자(판매자상품Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 댓글 entities by 판매자상품Id '{판매자상품Id}' with 주문자 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 댓글 entities by 판매자상품Id '{판매자상품Id}' with 주문자 from the cache.");
            }

            var dtos = _mapper.Map<List<Read댓글DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("주문자/{주문자Id}/with판매자상품")]
        public async Task<ActionResult<List<Read댓글DTO>>> GetToListBy주문자IdWith판매자상품(string 주문자Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.주문자Id == 주문자Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy주문자IdWith판매자상품(주문자Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 댓글 entities by 주문자Id '{주문자Id}' with 판매자상품 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 댓글 entities by 주문자Id '{주문자Id}' with 판매자상품 from the cache.");
            }

            var dtos = _mapper.Map<List<Read댓글DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("판매자상품/{판매자상품Id}/with주문자And판매자")]
        public async Task<ActionResult<List<Read댓글DTO>>> GetToListBy판매자상품IdWith주문자And판매자(string 판매자상품Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.판매자상품Id == 판매자상품Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy판매자상품IdWith주문자And판매자(판매자상품Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 댓글 entities by 판매자상품Id '{판매자상품Id}' with 주문자 and 판매자 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 댓글 entities by 판매자상품Id '{판매자상품Id}' with 주문자 and 판매자 from the cache.");
            }

            var dtos = _mapper.Map<List<Read댓글DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("주문자/{주문자Id}/with판매자상품And주문자")]
        public async Task<ActionResult<List<Read댓글DTO>>> GetToListBy주문자IdWith판매자상품And주문자(string 주문자Id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.주문자Id == 주문자Id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy주문자IdWith판매자상품And주문자(주문자Id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 댓글 entities by 주문자Id '{주문자Id}' with 판매자상품 and 주문자 from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 댓글 entities by 주문자Id '{주문자Id}' with 판매자상품 and 주문자 from the cache.");
            }

            var dtos = _mapper.Map<List<Read댓글DTO>>(entities);
            return Ok(dtos);
        }
    }
}
