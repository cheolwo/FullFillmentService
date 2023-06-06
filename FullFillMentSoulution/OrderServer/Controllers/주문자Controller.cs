using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.Model;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문자Controller : ControllerBase
    {
        private readonly 주문자Repository _repository;

        public 주문자Controller(주문자Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 주문자List = await _repository.ListAsync();
            Console.Write(주문자List.Count());
            return Ok(주문자List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 주문자 = await _repository.GetAsync(id);
            if (주문자 == null)
                return NotFound();

            return Ok(주문자);
        }
        [HttpGet("{id}/주문들")]
        public async Task<IActionResult> GetOrdersByCustomerId(string id)
        {
            var 주문자 = await _repository.GetByIdWith주문(id);
            if (주문자 == null)
                return NotFound();

            var 주문들 = 주문자.주문들;
            return Ok(주문들);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 주문자 주문자)
        {
            if (주문자 == null)
                return BadRequest();

            await _repository.AddAsync(주문자);

            return CreatedAtAction(nameof(GetById), new { id = 주문자.Id }, 주문자);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 주문자 updated주문자)
        {
            if (updated주문자 == null || id != updated주문자.Id)
                return BadRequest();

            var existing주문자 = await _repository.GetAsync(id);
            if (existing주문자 == null)
                return NotFound();

            existing주문자.Name = updated주문자.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing주문자);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing주문자 = await _repository.GetAsync(id);
            if (existing주문자 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
