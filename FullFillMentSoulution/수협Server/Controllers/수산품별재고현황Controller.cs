using KoreaCommon.Model.Repository;
using KoreaCommon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산품별재고현황Controller : ControllerBase
    {
        private readonly 수산품별재고현황Repository _repository;

        public 수산품별재고현황Controller(수산품별재고현황Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 수산품별재고현황List = await _repository.ListAsync();
            return Ok(수산품별재고현황List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 수산품별재고현황 = await _repository.GetAsync(id);
            if (수산품별재고현황 == null)
                return NotFound();

            return Ok(수산품별재고현황);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 수산품별재고현황 수산품별재고현황)
        {
            if (수산품별재고현황 == null)
                return BadRequest();

            await _repository.AddAsync(수산품별재고현황);

            return CreatedAtAction(nameof(GetById), new { id = 수산품별재고현황.Code }, 수산품별재고현황);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 수산품별재고현황 updated수산품별재고현황)
        {
            if (updated수산품별재고현황 == null || id != updated수산품별재고현황.Code)
                return BadRequest();

            var existing수산품별재고현황 = await _repository.GetAsync(id);
            if (existing수산품별재고현황 == null)
                return NotFound();

            existing수산품별재고현황.Name = updated수산품별재고현황.Name;
            // 필요한 다른 속성들 업데이트

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
