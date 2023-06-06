using KoreaCommon.Model;
using KoreaCommon.Model.Repository;
using Microsoft.AspNetCore.Mvc;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산협동조합Controller : ControllerBase
    {
        private readonly 수산협동조합Repository _repository;

        public 수산협동조합Controller(수산협동조합Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 수산협동조합List = await _repository.ListAsync();
            Console.Write(수산협동조합List.Count());
            return Ok(수산협동조합List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 수산협동조합 = await _repository.GetAsync(id);
            if (수산협동조합 == null)
                return NotFound();

            return Ok(수산협동조합);
        }
        [HttpGet("{id}/수산창고")]
        public async Task<IActionResult> Get수산협동조합With수산창고(string id)
        {
            var 수산협동조합 = await _repository.GetByIdWith수산창고Async(id);
            if (수산협동조합 == null)
                return NotFound();

            return Ok(수산협동조합);
        }

        [HttpGet("With수산창고")]
        public async Task<IActionResult> GetAll수산협동조합With수산창고()
        {
            var 수산협동조합List = await _repository.GetToListWith수산창고Async();
            return Ok(수산협동조합List);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 수산협동조합 수산협동조합)
        {
            if (수산협동조합 == null)
                return BadRequest();

            await _repository.AddAsync(수산협동조합);

            return CreatedAtAction(nameof(GetById), new { id = 수산협동조합.Code }, 수산협동조합);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 수산협동조합 updated수산협동조합)
        {
            if (updated수산협동조합 == null || id != updated수산협동조합.Code)
                return BadRequest();

            var existing수산협동조합 = await _repository.GetAsync(id);
            if (existing수산협동조합 == null)
                return NotFound();

            existing수산협동조합.Name = updated수산협동조합.Name;
            // 필요한 다른 속성들 업데이트

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
