using KoreaCommon.Model;
using Microsoft.AspNetCore.Mvc;
using 수협Common.Repository;

namespace 수협Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 수산품Controller : ControllerBase
    {
        private readonly 수산품Repository _repository;

        public 수산품Controller(수산품Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 수산품List = await _repository.ListAsync();
            return Ok(수산품List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 수산품 = await _repository.GetAsync(id);
            if (수산품 == null)
                return NotFound();

            return Ok(수산품);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 수산품 수산품)
        {
            if (수산품 == null)
                return BadRequest();

            await _repository.AddAsync(수산품);

            return CreatedAtAction(nameof(GetById), new { id = 수산품.Code }, 수산품);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 수산품 updated수산품)
        {
            if (updated수산품 == null || id != updated수산품.Code)
                return BadRequest();

            var existing수산품 = await _repository.GetAsync(id);
            if (existing수산품 == null)
                return NotFound();

            existing수산품.Name = updated수산품.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing수산품);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing수산품 = await _repository.GetAsync(id);
            if (existing수산품 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }

}
