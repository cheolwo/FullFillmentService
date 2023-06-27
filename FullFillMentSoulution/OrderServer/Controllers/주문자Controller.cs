using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using 주문Common.DTO.주문자;
using 주문Common.Model;
using 주문Common.Model.Repository;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문자Controller : ControllerBase
    {
        private readonly 주문자Repository _repository;
        private readonly ILogger<주문자Controller> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public 주문자Controller(주문자Repository repository, IMemoryCache memoryCache, 
            IMapper mapper, ILogger<주문자Controller> logger)
        {
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GetAll called");

            var 주문자List = await _repository.ListAsync();
            var 주문자DTOs = _mapper.Map<List<Read주문자DTO>>(주문자List);
            return Ok(주문자DTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation($"GetById called with ID: {id}");

            var 주문자 = await _repository.GetAsync(id);
            if (주문자 == null)
            {
                _logger.LogInformation($"주문자 ID '{id}'에 해당하는 주문자를 찾을 수 없습니다.");
                return NotFound();
            }

            var 주문자DTO = _mapper.Map<Read주문자DTO>(주문자);
            return Ok(주문자DTO);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update주문자DTO updated주문자DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated주문자DTO == null || id != updated주문자DTO.Id)
                return BadRequest();

            var existing주문자 = await _repository.GetAsync(id);
            if (existing주문자 == null)
                return NotFound();

            var updated주문자 = _mapper.Map<주문자>(updated주문자DTO);

            existing주문자.Name = updated주문자.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing주문자);

            // MemoryCache에서 해당 주문자 데이터 업데이트
            var cacheKey = $"주문자_{id}";
            _memoryCache.Set(cacheKey, existing주문자);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing주문자 = await _repository.GetAsync(id);
            if (existing주문자 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            // MemoryCache에서 해당 주문자 데이터 제거
            var cacheKey = $"주문자_{id}";
            _memoryCache.Remove(cacheKey);

            return NoContent();
        }
    }
}
