using Microsoft.AspNetCore.Mvc;
using 창고Common;
using 창고Common.Repository;

namespace WarehouseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 입고상품Controller : ControllerBase
    {
        private readonly 입고상품Repository _repository;

        public 입고상품Controller(입고상품Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 입고상품List = await _repository.ListAsync();
            Console.Write(입고상품List.Count());
            return Ok(입고상품List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 입고상품 = await _repository.GetAsync(id);
            if (입고상품 == null)
                return NotFound();

            return Ok(입고상품);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 입고상품 입고상품)
        {
            if (입고상품 == null)
                return BadRequest();

            await _repository.AddAsync(입고상품);

            return CreatedAtAction(nameof(GetById), new { id = 입고상품.Id }, 입고상품);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 입고상품 updated입고상품)
        {
            if (updated입고상품 == null || id != updated입고상품.Id)
                return BadRequest();

            var existing입고상품 = await _repository.GetAsync(id);
            if (existing입고상품 == null)
                return NotFound();

            existing입고상품.Name = updated입고상품.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing입고상품);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing입고상품 = await _repository.GetAsync(id);
            if (existing입고상품 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id}/with적재상품")]
        public async Task<IActionResult> GetByIdWith적재상품(string id)
        {
            var 입고상품 = await _repository.GetByIdWith적재상품(id);
            if (입고상품 == null)
                return NotFound();

            return Ok(입고상품);
        }

        [HttpGet("{id}/with출고상품")]
        public async Task<IActionResult> GetByIdWith출고상품(string id)
        {
            var 입고상품 = await _repository.GetByIdWith출고상품(id);
            if (입고상품 == null)
                return NotFound();

            return Ok(입고상품);
        }

        [HttpGet("창고/{창고Id}")]
        public async Task<IActionResult> GetToListBy창고Id(string 창고Id)
        {
            var 입고상품List = await _repository.GetToListBy창고Id(창고Id);
            return Ok(입고상품List);
        }

        [HttpGet("창고상품/{창고상품Id}")]
        public async Task<IActionResult> GetToListBy창고상품Id(string 창고상품Id)
        {
            var 입고상품List = await _repository.GetToListBy창고상품Id(창고상품Id);
            return Ok(입고상품List);
        }
    }
}
