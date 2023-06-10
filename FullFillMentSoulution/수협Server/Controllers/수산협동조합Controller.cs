using AutoMapper;
using KoreaCommon.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using 수협Common.DTO;
using 수협Common.Repository;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산협동조합Controller : ControllerBase
    {
        private readonly 수산협동조합Repository _repository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public 수산협동조합Controller(수산협동조합Repository repository, IMapper mapper, IDistributedCache distributedCache)
        {
            _repository = repository;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }
        [HttpGet("Text")]
        public async Task<List<string>> GetStringItems()
        {
            string cacheKey = "redisCacheKey";
            string serializedStringItems;
            List<string> stringItemsList;

            var encodedStringItems = await _distributedCache.GetAsync(cacheKey);
            if (encodedStringItems != null)
            {
                serializedStringItems = Encoding.UTF8.GetString(encodedStringItems);
                stringItemsList = JsonConvert.DeserializeObject<List<string>>(serializedStringItems);
            }
            else
            {
                stringItemsList = new List<string>() { "John wick", "La La Land", "It" };
                serializedStringItems = JsonConvert.SerializeObject(stringItemsList);
                encodedStringItems = Encoding.UTF8.GetBytes(serializedStringItems);
                var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(6));
                await _distributedCache.SetAsync(cacheKey, encodedStringItems, options);

            }
            return stringItemsList;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 수산협동조합List = await _repository.ListAsync();
            var 수산협동조합DTOList = _mapper.Map<List<Read수산협동조합DTO>>(수산협동조합List);

            return Ok(수산협동조합DTOList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 수산협동조합 = await _repository.GetAsync(id);
            if (수산협동조합 == null)
                return NotFound();

            var 수산협동조합DTO = _mapper.Map<Read수산협동조합DTO>(수산협동조합);

            return Ok(수산협동조합DTO);
        }

        [HttpGet("{id}/수산창고")]
        public async Task<IActionResult> Get수산협동조합With수산창고(string id)
        {
            var 수산협동조합 = await _repository.GetByIdWith수산창고Async(id);
            if (수산협동조합 == null)
                return NotFound();

            var 수산협동조합DTO = _mapper.Map<Read수산협동조합DTO>(수산협동조합);

            return Ok(수산협동조합DTO);
        }

        [HttpGet("With수산창고")]
        public async Task<IActionResult> GetAll수산협동조합With수산창고()
        {
            var 수산협동조합List = await _repository.GetToListWith수산창고Async();
            var 수산협동조합DTOList = _mapper.Map<List<Read수산협동조합DTO>>(수산협동조합List);

            return Ok(수산협동조합DTOList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create수산협동조합DTO 수산협동조합DTO)
        {
            if (수산협동조합DTO == null)
                return BadRequest();

            var 수산협동조합 = _mapper.Map<수산협동조합>(수산협동조합DTO);
            await _repository.AddAsync(수산협동조합);

            var created수산협동조합DTO = _mapper.Map<Read수산협동조합DTO>(수산협동조합);

            return CreatedAtAction(nameof(GetById), new { id = created수산협동조합DTO.Id }, created수산협동조합DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update수산협동조합DTO updated수산협동조합DTO)
        {
            if (updated수산협동조합DTO == null || id != updated수산협동조합DTO.Id)
                return BadRequest();

            var existing수산협동조합 = await _repository.GetAsync(id);
            if (existing수산협동조합 == null)
                return NotFound();

            _mapper.Map(updated수산협동조합DTO, existing수산협동조합);

            await _repository.UpdateAsync(existing수산협동조합);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing수산협동조합 = await _repository.GetAsync(id);
            if (existing수산협동조합 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }

}
