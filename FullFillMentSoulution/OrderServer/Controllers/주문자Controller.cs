using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using 주문Common.DTO.For주문;
using 주문Common.DTO.댓글;
using 주문Common.DTO.상품문의;
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

        [HttpGet("{id}/주문들")]
        public async Task<IActionResult> GetOrdersByCustomerId(string id)
        {
            _logger.LogInformation($"GetOrdersByCustomerId called with ID: {id}");

            var 주문자 = await _repository.GetByIdWith주문(id);
            if (주문자 == null)
            {
                _logger.LogInformation($"주문자 ID '{id}'에 해당하는 주문자를 찾을 수 없습니다.");
                return NotFound();
            }

            var 주문들 = 주문자.주문들;
            var 주문DTOs = _mapper.Map<List<Read주문DTO>>(주문들);
            return Ok(주문DTOs);
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create주문자DTO 주문자DTO)
        {
            _logger.LogInformation("Create called");

            if (주문자DTO == null)
                return BadRequest();

            var 주문자 = _mapper.Map<주문자>(주문자DTO);
            await _repository.AddAsync(주문자);

            // 주문자와 관련된 데이터를 가져오는 API 호출
            var 관련데이터 = await _repository.GetByIdWithRelatedData(주문자.Id);

            // 관련데이터를 캐시에 저장
            var cacheKey = $"주문자_{주문자.Id}";
            _memoryCache.Set(cacheKey, 관련데이터);

            // 주문자 DTO로 변환
            var created주문자DTO = _mapper.Map<Read주문자DTO>(주문자);
            return CreatedAtAction(nameof(GetById), new { id = created주문자DTO.Id }, created주문자DTO);
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
        [HttpGet("{id}/댓글들")]
        public async Task<IActionResult> GetCommentsByCustomerId(string id)
        {
            var 주문자 = await _repository.GetByIdWith댓글(id);
            if (주문자 == null)
            {
                _logger.LogInformation($"주문자 ID '{id}'에 해당하는 주문자를 찾을 수 없습니다.");
                return NotFound();
            }

            var 댓글들 = 주문자.댓글들;
            var 댓글DTOs = _mapper.Map<List<Read댓글DTO>>(댓글들);
            return Ok(댓글DTOs);
        }

        [HttpGet("{id}/상품문의들")]
        public async Task<IActionResult> GetInquiriesByCustomerId(string id)
        {
            var 주문자 = await _repository.GetByIdWith상품문의(id);
            if (주문자 == null)
            {
                _logger.LogInformation($"주문자 ID '{id}'에 해당하는 주문자를 찾을 수 없습니다.");
                return NotFound();
            }

            var 상품문의들 = 주문자.상품문의들;
            var 상품문의DTOs = _mapper.Map<List<Read상품문의DTO>>(상품문의들);
            return Ok(상품문의DTOs);
        }
    }
}
