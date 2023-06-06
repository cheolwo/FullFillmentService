using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.Model;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문Controller : ControllerBase
    {
        private readonly 주문Repository _repository;

        public 주문Controller(주문Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 주문List = await _repository.ListAsync();
            return Ok(주문List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 주문 = await _repository.GetAsync(id);
            if (주문 == null)
                return NotFound();

            return Ok(주문);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 주문 주문)
        {
            if (주문 == null)
                return BadRequest();

            await _repository.AddAsync(주문);

            return CreatedAtAction(nameof(GetById), new { id = 주문.Id }, 주문);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 주문 updated주문)
        {
            if (updated주문 == null || id != updated주문.Id)
                return BadRequest();

            var existing주문 = await _repository.GetAsync(id);
            if (existing주문 == null)
                return NotFound();

            existing주문.Name = updated주문.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing주문);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing주문 = await _repository.GetAsync(id);
            if (existing주문 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("GetByIdWith판매자상품/{id}")]
        public async Task<IActionResult> GetByIdWith판매자상품(string id)
        {
            var 주문 = await _repository.GetByIdWith판매자상품(id);
            if (주문 == null)
                return NotFound();

            return Ok(주문);
        }

        [HttpGet("GetByIdWith주문자/{id}")]
        public async Task<IActionResult> GetByIdWith주문자(string id)
        {
            var 주문 = await _repository.GetByIdWith주문자(id);
            if (주문 == null)
                return NotFound();

            return Ok(주문);
        }

        [HttpGet("GetByIdWith판매자/{id}")]
        public async Task<IActionResult> GetByIdWith판매자(string id)
        {
            var 주문 = await _repository.GetByIdWith판매자(id);
            if (주문 == null)
                return NotFound();

            return Ok(주문);
        }

        [HttpGet("GetByIdWith판매자And판매자상품/{id}")]
        public async Task<IActionResult> GetByIdWith판매자And판매자상품(string id)
        {
            var 주문 = await _repository.GetByIdWith판매자And판매자상품(id);
            if (주문 == null)
                return NotFound();

            return Ok(주문);
        }

        [HttpGet("GetByIdWith판매자And판매자상품And주문자/{id}")]
        public async Task<IActionResult> GetByIdWith판매자And판매자상품And주문자(string id)
        {
            var 주문 = await _repository.GetByIdWith판매자And판매자상품And주문자(id);
            if (주문 == null)
                return NotFound();

            return Ok(주문);
        }

        [HttpGet("GetByPriceAbove/{price}")]
        public async Task<IActionResult> GetByPriceAbove(double price)
        {
            var 주문List = await _repository.GetByPriceAbove(price);
            return Ok(주문List);
        }

        [HttpGet("GetByPriceBelow/{price}")]
        public async Task<IActionResult> GetByPriceBelow(double price)
        {
            var 주문List = await _repository.GetByPriceBelow(price);
            return Ok(주문List);
        }

        [HttpGet("GetByPriceInRange/{minPrice}/{maxPrice}")]
        public async Task<IActionResult> GetByPriceInRange(double minPrice, double maxPrice)
        {
            var 주문List = await _repository.GetByPriceInRange(minPrice, maxPrice);
            return Ok(주문List);
        }
    }
}
