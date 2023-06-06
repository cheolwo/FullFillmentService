using Microsoft.AspNetCore.Mvc;
using 창고Common;
using 창고Common.Repository;

namespace WarehouseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 창고Controller : ControllerBase
    {
        private readonly 창고Repository _repository;

        public 창고Controller(창고Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 창고List = await _repository.ListAsync();
            Console.Write(창고List.Count());
            return Ok(창고List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 창고 = await _repository.GetAsync(id);
            if (창고 == null)
                return NotFound();

            return Ok(창고);
        }
        [HttpGet("getByAddress")]
        public async Task<IActionResult> GetByAddress(string address)
        {
            var entity = await _repository.GetByAddress(address);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
        [HttpGet("getByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var entity = await _repository.GetByEmail(email);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpGet("getByFaxNumber")]
        public async Task<IActionResult> GetByFaxNumber(string faxNumber)
        {
            var entity = await _repository.GetByFaxNumber(faxNumber);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
        [HttpGet("getByPhoneNumber")]
        public async Task<IActionResult> GetByPhoneNumber(string phoneNumber)
        {
            var entity = await _repository.GetByPhoneNumber(phoneNumber);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
        [HttpGet("getByCode")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var entity = await _repository.GetByCode(code);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
        [HttpGet("getByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var entity = await _repository.GetByName(name);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }


        [HttpGet("{id}/with창고상품")]
        public async Task<IActionResult> GetByIdWith창고상품(string id)
        {
            var 창고 = await _repository.GetByIdWith창고상품(id);
            if (창고 == null)
                return NotFound();

            return Ok(창고);
        }
        [HttpGet("{id}/with입고상품")]
        public async Task<IActionResult> GetByIdWith입고상품(string id)
        {
            var 창고 = await _repository.GetByIdWith입고상품(id);
            if (창고 == null)
                return NotFound();

            return Ok(창고);
        }
        [HttpGet("{id}/with적재상품")]
        public async Task<IActionResult> GetByIdWith적재상품(string id)
        {
            var 창고 = await _repository.GetByIdWith적재상품(id);
            if (창고 == null)
                return NotFound();

            return Ok(창고);
        }
        [HttpGet("{id}/with출고상품")]
        public async Task<IActionResult> GetByIdWith출고상품(string id)
        {
            var 창고 = await _repository.GetByIdWith출고상품(id);
            if (창고 == null)
                return NotFound();

            return Ok(창고);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 창고 창고)
        {
            if (창고 == null)
                return BadRequest();

            await _repository.AddAsync(창고);

            return CreatedAtAction(nameof(GetById), new { id = 창고.Id }, 창고);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 창고 updated창고)
        {
            if (updated창고 == null || id != updated창고.Id)
                return BadRequest();

            var existing창고 = await _repository.GetAsync(id);
            if (existing창고 == null)
                return NotFound();

            existing창고.Name = updated창고.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing창고);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing창고 = await _repository.GetAsync(id);
            if (existing창고 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
