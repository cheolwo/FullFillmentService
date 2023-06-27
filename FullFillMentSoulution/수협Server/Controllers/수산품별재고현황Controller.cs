using AutoMapper;
using KoreaCommon.Fish.해양수산부;
using Microsoft.AspNetCore.Mvc;
using 수협Common.DTO;
using 수협Common.Model;
using 수협Common.Repository;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산품별재고현황Controller : ControllerBase
    {
        private readonly I수협창고재고상품수집 _수협창고재고상품수집;
        private readonly 수산품별재고현황Repository _repository;
        private readonly IMapper _mapper;

        public 수산품별재고현황Controller(수산품별재고현황Repository repository, IMapper mapper,
            I수협창고재고상품수집 수협창고재고상품수집)
        {
            _repository = repository;
            _mapper = mapper;
            _수협창고재고상품수집 = 수협창고재고상품수집;
        }
        [HttpPost("재고데이터수집")]
        public async Task CollectingData()
        {
            await _수협창고재고상품수집.수협창고재고상품ToDb(DateTime.Now);
        }
        [HttpPost("창고/재고데이터수집/{창고id}")]
        public async Task CollectingDataBy창고Id(string 창고id)
        {
            await _수협창고재고상품수집.수협창고재고상품ToDb(창고id, DateTime.Now);
        }
        /// <summary>
        /// 재고존재 상품조회
        /// </summary>
        /// <param name="창고id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Read수산품별재고현황DTO>>> GetBy창고번호AndInventoryCount(string 창고id, string quantity)
        {
            var 수산품별재고현황List = await _repository.GetToListBy창고번호AndInventoryCount(창고id, quantity);
            var 수산품별재고현황DTOList = _mapper.Map<List<Read수산품별재고현황DTO>>(수산품별재고현황List);
            return Ok(수산품별재고현황DTOList);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 수산품별재고현황List = await _repository.ListAsync();
            var 수산품별재고현황DTOList = _mapper.Map<List<Read수산품별재고현황DTO>>(수산품별재고현황List);
            return Ok(수산품별재고현황DTOList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 수산품별재고현황 = await _repository.GetAsync(id);
            if (수산품별재고현황 == null)
                return NotFound();

            var 수산품별재고현황DTO = _mapper.Map<Read수산품별재고현황DTO>(수산품별재고현황);
            return Ok(수산품별재고현황DTO);
        }

        [HttpGet("by창고번호/{창고번호}")]
        public async Task<IActionResult> GetBy창고번호(string 창고번호)
        {
            var 수산품별재고현황List = await _repository.GetToListBy창고번호Async(창고번호);
            var 수산품별재고현황DTOList = _mapper.Map<List<Read수산품별재고현황DTO>>(수산품별재고현황List);
            return Ok(수산품별재고현황DTOList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create수산품별재고현황DTO 수산품별재고현황DTO)
        {
            if (수산품별재고현황DTO == null)
                return BadRequest();

            var 수산품별재고현황 = _mapper.Map<수산품별재고현황>(수산품별재고현황DTO);

            await _repository.AddAsync(수산품별재고현황);

            var created수산품별재고현황DTO = _mapper.Map<Read수산품별재고현황DTO>(수산품별재고현황);
            return CreatedAtAction(nameof(GetById), new { id = created수산품별재고현황DTO.Code }, created수산품별재고현황DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update수산품별재고현황DTO updated수산품별재고현황DTO)
        {
            if (updated수산품별재고현황DTO == null || id != updated수산품별재고현황DTO.Code)
                return BadRequest();

            var existing수산품별재고현황 = await _repository.GetAsync(id);
            if (existing수산품별재고현황 == null)
                return NotFound();

            _mapper.Map(updated수산품별재고현황DTO, existing수산품별재고현황);

            await _repository.UpdateAsync(existing수산품별재고현황);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing수산품별재고현황 = await _repository.GetAsync(id);
            if (existing수산품별재고현황 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
