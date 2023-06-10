using AutoMapper;
using IdentityCommon.Models.ForApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrderCommon.Repository;
using 주문Common.DTO.주문;
using 주문Common.DTO.주문자;
using 주문Common.Model;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "주문자")]
    [ApiController]
    public class 주문자Controller : ControllerBase
    {
        private readonly 주문자Repository _repository;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public 주문자Controller(주문자Repository repository, IMemoryCache memoryCache, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// 로그인 시 다른 도메인분야 initialize API 들과 
        /// 비동기적으로 같이 호출되는 API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("initialize/{id}")]
        public async Task<IActionResult> GetByIdWithRelatedData(string id)
        {
            var cacheKey = $"주문자_{id}";
            if (_memoryCache.TryGetValue(cacheKey, out 주문자? 주문자Data))
            {
                var 주문자DTO = _mapper.Map<Read주문자DTO>(주문자Data);
                return Ok(주문자DTO);
            }
            else
            {
                var 주문자 = await _repository.GetByIdWith주문(id);
                if (주문자 == null)
                    return NotFound();

                // 주문자 역할 확인
                var isOrderer = CheckRole();
                if (!isOrderer)
                {
                    return Forbid(); // 주문자 역할이 아닌 경우 접근 거부
                }

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));
                _memoryCache.Set(cacheKey, 주문자, cacheOptions);

                var 주문자DTO = _mapper.Map<Read주문자DTO>(주문자);
                return Ok(주문자DTO);
            }
        }
        private bool CheckRole()
        {
            var user = _httpContextAccessor.HttpContext.User;          
            string roleString = DomainRole.Orderer.ToRoleString(); // "주문자"
            foreach (var claim in user.Claims)
            {
                if(claim.Value == roleString)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpGet("{id}/주문들")]
        public async Task<IActionResult> GetOrdersByCustomerId(string id)
        {
            var 주문자 = await _repository.GetByIdWith주문(id);
            if (주문자 == null)
                return NotFound();

            var 주문들 = 주문자.주문들;
            var 주문DTOs = _mapper.Map<List<Read주문DTO>>(주문들);
            return Ok(주문DTOs);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 주문자List = await _repository.ListAsync();
            var 주문자DTOs = _mapper.Map<List<Read주문자DTO>>(주문자List);
            return Ok(주문자DTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 주문자 = await _repository.GetAsync(id);
            if (주문자 == null)
                return NotFound();

            var 주문자DTO = _mapper.Map<Read주문자DTO>(주문자);
            return Ok(주문자DTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create주문자DTO 주문자DTO)
        {
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
