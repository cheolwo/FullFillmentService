using Microsoft.AspNetCore.Mvc;
using 창고Common;
using 창고Common.Repository;

namespace WarehouseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 출고상품Controller : ControllerBase
    {
        private readonly 출고상품Repository _repository;

        public 출고상품Controller(출고상품Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 출고상품List = await _repository.ListAsync();
            Console.Write(출고상품List.Count());
            return Ok(출고상품List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 출고상품 = await _repository.GetAsync(id);
            if (출고상품 == null)
                return NotFound();

            return Ok(출고상품);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 출고상품 출고상품)
        {
            if (출고상품 == null)
                return BadRequest();

            await _repository.AddAsync(출고상품);

            return CreatedAtAction(nameof(GetById), new { id = 출고상품.Id }, 출고상품);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 출고상품 updated출고상품)
        {
            if (updated출고상품 == null || id != updated출고상품.Id)
                return BadRequest();

            var existing출고상품 = await _repository.GetAsync(id);
            if (existing출고상품 == null)
                return NotFound();

            existing출고상품.Name = updated출고상품.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing출고상품);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing출고상품 = await _repository.GetAsync(id);
            if (existing출고상품 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("창고/{창고Id}")]
        public async Task<IActionResult> GetToListBy창고Id(string 창고Id)
        {
            var 출고상품List = await _repository.GetToListBy창고Id(창고Id);
            return Ok(출고상품List);
        }
        [HttpGet("창고상품/{창고상품Id}")]
        public async Task<IActionResult> GetToListBy창고상품Id(string 창고상품Id)
        {
            var 출고상품List = await _repository.GetToListBy창고상품Id(창고상품Id);
            return Ok(출고상품List);
        }
        [HttpGet("입고상품/{입고상품Id}")]
        public async Task<IActionResult> GetToListBy입고상품Id(string 입고상품Id)
        {
            var 출고상품List = await _repository.GetToListBy입고상품Id(입고상품Id);
            return Ok(출고상품List);
        }
        [HttpGet("적재상품/{적재상품Id}")]
        public async Task<IActionResult> GetToListBy적재상품Id(string 적재상품Id)
        {
            var 출고상품List = await _repository.GetToListBy적재상품Id(적재상품Id);
            return Ok(출고상품List);
        }


    }
}
