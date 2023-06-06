using KoreaCommon.Model;
using KoreaCommon.Model.Repository;
using Microsoft.AspNetCore.Mvc;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산창고Controller : ControllerBase
    {
        private readonly 수산창고Repository _repository;

        public 수산창고Controller(수산창고Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 수산창고List = await _repository.ListAsync();
            Console.WriteLine(수산창고List.Count());
            return Ok(수산창고List);
        }
        [HttpGet("With수산품목종류")]
        public async Task<IActionResult> Get수산창고With수산품목종류Async()
        {
            var 수산창고List = await _repository.GetToList수산창고With수산품목종류Async();
            if (수산창고List == null || 수산창고List.Count == 0)
                return NotFound();

            return Ok(수산창고List);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 수산창고 = await _repository.GetAsync(id);
            if (수산창고 == null)
                return NotFound();

            return Ok(수산창고);
        }
        [HttpGet("{id}/수산품별재고현황")]
        public async Task<IActionResult> GetWith수산품별재고현황(string id)
        {
            var 수산창고 = await _repository.GetByIdWith수산품별재고현황Async(id);
            if (수산창고 == null)
                return NotFound();

            return Ok(수산창고);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 수산창고 수산창고)
        {
            if (수산창고 == null)
                return BadRequest();

            await _repository.AddAsync(수산창고);

            return CreatedAtAction(nameof(GetById), new { id = 수산창고.Code }, 수산창고);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 수산창고 updated수산창고)
        {
            if (updated수산창고 == null || id != updated수산창고.Code)
                return BadRequest();

            var existing수산창고 = await _repository.GetAsync(id);
            if (existing수산창고 == null)
                return NotFound();

            existing수산창고.Name = updated수산창고.Name;
            //existing수산창고.Description = updated수산창고.Description;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing수산창고);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing수산창고 = await _repository.GetAsync(id);
            if (existing수산창고 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }

    }
}
