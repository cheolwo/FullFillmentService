using Microsoft.AspNetCore.Mvc;
using 창고Common;
using 창고Common.Repository;

namespace WarehouseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 적재상품Controller : ControllerBase
    {
        private readonly 적재상품Repository _repository;

        public 적재상품Controller(적재상품Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 적재상품List = await _repository.ListAsync();
            Console.Write(적재상품List.Count());
            return Ok(적재상품List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 적재상품 = await _repository.GetAsync(id);
            if (적재상품 == null)
                return NotFound();

            return Ok(적재상품);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 적재상품 적재상품)
        {
            if (적재상품 == null)
                return BadRequest();

            await _repository.AddAsync(적재상품);

            return CreatedAtAction(nameof(GetById), new { id = 적재상품.Id }, 적재상품);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 적재상품 updated적재상품)
        {
            if (updated적재상품 == null || id != updated적재상품.Id)
                return BadRequest();

            var existing적재상품 = await _repository.GetAsync(id);
            if (existing적재상품 == null)
                return NotFound();

            existing적재상품.Name = updated적재상품.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing적재상품);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing적재상품 = await _repository.GetAsync(id);
            if (existing적재상품 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id}/with출고상품")]
        public async Task<IActionResult> GetByIdWith출고상품(string id)
        {
            var 적재상품 = await _repository.GetByIdWith출고상품(id);
            if (적재상품 == null)
                return NotFound();

            return Ok(적재상품);
        }
        [HttpGet("창고/{창고Id}")]
        public async Task<IActionResult> GetToListBy창고Id(string 창고Id)
        {
            var 적재상품List = await _repository.GetToListBy창고Id(창고Id);
            return Ok(적재상품List);
        }
        [HttpGet("창고상품/{창고상품Id}")]
        public async Task<IActionResult> GetToListBy창고상품Id(string 창고상품Id)
        {
            var 적재상품List = await _repository.GetToListBy창고상품Id(창고상품Id);
            return Ok(적재상품List);
        }
        [HttpGet("입고상품/{입고상품Id}")]
        public async Task<IActionResult> GetToListBy입고상품Id(string 입고상품Id)
        {
            var 적재상품List = await _repository.GetToListBy입고상품Id(입고상품Id);
            return Ok(적재상품List);
        }
    }
}
