using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.Model;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 판매자Controller : ControllerBase
    {
        private readonly 판매자Repository _repository;

        public 판매자Controller(판매자Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 판매자List = await _repository.ListAsync();
            return Ok(판매자List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 판매자 = await _repository.GetAsync(id);
            if (판매자 == null)
                return NotFound();

            return Ok(판매자);
        }
        [HttpGet("{id}/판매자상품들")]
        public async Task<IActionResult> GetByIdWith판매자상품들(string id)
        {
            var 판매자 = await _repository.GetByIdWith판매자상품(id);
            if (판매자 == null)
                return NotFound();

            return Ok(판매자.판매자상품들);
        }

        [HttpGet("{id}/주문된것들")]
        public async Task<IActionResult> GetByIdWith주문(string id)
        {
            var 판매자 = await _repository.GetByIdWith주문(id);
            if (판매자 == null)
                return NotFound();

            return Ok(판매자.주문된것들);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 판매자 판매자)
        {
            if (판매자 == null)
                return BadRequest();

            await _repository.AddAsync(판매자);

            return CreatedAtAction(nameof(GetById), new { id = 판매자.Id }, 판매자);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 판매자 updated판매자)
        {
            if (updated판매자 == null || id != updated판매자.Id)
                return BadRequest();

            var existing판매자 = await _repository.GetAsync(id);
            if (existing판매자 == null)
                return NotFound();

            existing판매자.Name = updated판매자.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing판매자);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing판매자 = await _repository.GetAsync(id);
            if (existing판매자 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
