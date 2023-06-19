using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using 수협Common.DTO;
using 수협Common.Model;
using 수협Common.Repository;

namespace 수협QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산품별재고현황QueryController : EntityQueryController<수산품별재고현황, Read수산품별재고현황DTO>
    {
        private readonly I수산품별재고현황QueryRepository _repository;

        public 수산품별재고현황QueryController(I수산품별재고현황QueryRepository repository, IMapper mapper, MemoryModule<수산품별재고현황> memoryModule, ILogger<CommodityQueryController<수산품별재고현황, Read수산품별재고현황DTO>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("list/By창고번호AndInventoryCount/{창고id}/{quantity}")]
        public async Task<ActionResult<List<Read수산품별재고현황DTO>>> GetToListBy창고번호AndInventoryCount(string 창고id, string quantity)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.창고Id == 창고id && int.Parse(e.Quantity) >= int.Parse(quantity)).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy창고번호AndInventoryCount(창고id, quantity);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품별재고현황 by 창고번호 '{창고id}' and inventory count from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품별재고현황 by 창고번호 '{창고id}' and inventory count from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품별재고현황DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/By창고번호/{창고id}")]
        public async Task<ActionResult<List<Read수산품별재고현황DTO>>> GetToListBy창고번호(string 창고id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.창고Id == 창고id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy창고번호Async(창고id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품별재고현황 by 창고번호 '{창고id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품별재고현황 by 창고번호 '{창고id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품별재고현황DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/By조합번호/{조합id}")]
        public async Task<ActionResult<List<Read수산품별재고현황DTO>>> GetToListBy조합번호(string 조합id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.수협Id == 조합id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy조합번호Async(조합id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품별재고현황 by 조합번호 '{조합id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품별재고현황 by 조합번호 '{조합id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품별재고현황DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/By품목번호/{수산품id}")]
        public async Task<ActionResult<List<Read수산품별재고현황DTO>>> GetToListBy품목번호(string 수산품id)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.수산품Id == 수산품id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy품목번호Async(수산품id);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품별재고현황 by 품목번호 '{수산품id}' from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품별재고현황 by 품목번호 '{수산품id}' from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품별재고현황DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/By창고번호/{창고id}/Quantity")]
        public async Task<ActionResult<List<Read수산품별재고현황DTO>>> GetToListBy창고번호(string 창고id, int? quantityMin, int? quantityMax)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.창고Id == 창고id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy창고번호Async(창고id, quantityMin, quantityMax);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품별재고현황 by 창고번호 '{창고id}' and quantity range from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품별재고현황 by 창고번호 '{창고id}' and quantity range from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품별재고현황DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/By조합번호/{조합id}/Quantity")]
        public async Task<ActionResult<List<Read수산품별재고현황DTO>>> GetToListBy조합번호(string 조합id, int? quantityMin, int? quantityMax)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.수협Id == 조합id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy조합번호Async(조합id, quantityMin, quantityMax);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품별재고현황 by 조합번호 '{조합id}' and quantity range from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품별재고현황 by 조합번호 '{조합id}' and quantity range from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품별재고현황DTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("list/By품목번호/{수산품id}/Quantity")]
        public async Task<ActionResult<List<Read수산품별재고현황DTO>>> GetToListBy품목번호(string 수산품id, int? quantityMin, int? quantityMax)
        {
            var entities = _memoryModule.GetEntities().Where(e => e.수산품Id == 수산품id).ToList();
            if (!entities.Any())
            {
                entities = await _repository.GetToListBy품목번호Async(수산품id, quantityMin, quantityMax);
                _memoryModule.SetEntities(entities);
                _logger.LogInformation($"Fetched 수산품별재고현황 by 품목번호 '{수산품id}' and quantity range from the repository and cached the entities.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 수산품별재고현황 by 품목번호 '{수산품id}' and quantity range from the cache.");
            }

            var dtos = _mapper.Map<List<Read수산품별재고현황DTO>>(entities);
            return Ok(dtos);
        }
    }

}
