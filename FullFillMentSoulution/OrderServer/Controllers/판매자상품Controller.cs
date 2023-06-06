using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.Model;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 판매자상품Controller : ControllerBase
    {
        private readonly 판매자상품Repository _repository;

        public 판매자상품Controller(판매자상품Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var 판매자상품List = await _repository.ListAsync();
            Console.Write(판매자상품List.Count());
            return Ok(판매자상품List);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var 판매자상품 = await _repository.GetAsync(id);
            if (판매자상품 == null)
                return NotFound();

            return Ok(판매자상품);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 판매자상품 판매자상품)
        {
            if (판매자상품 == null)
                return BadRequest();

            await _repository.AddAsync(판매자상품);

            return CreatedAtAction(nameof(GetById), new { id = 판매자상품.Id }, 판매자상품);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] 판매자상품 updated판매자상품)
        {
            if (updated판매자상품 == null || id != updated판매자상품.Id)
                return BadRequest();

            var existing판매자상품 = await _repository.GetAsync(id);
            if (existing판매자상품 == null)
                return NotFound();

            existing판매자상품.Name = updated판매자상품.Name;
            // 필요한 다른 속성들 업데이트

            await _repository.UpdateAsync(existing판매자상품);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing판매자상품 = await _repository.GetAsync(id);
            if (existing판매자상품 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("{id}/주문")]
        public async Task<IActionResult> GetByIdWith주문(string id)
        {
            var 판매자상품 = await _repository.GetByIdWith주문(id);
            if (판매자상품 == null)
                return NotFound();

            return Ok(판매자상품);
        }

        [HttpGet("{id}/판매자")]
        public async Task<IActionResult> GetByIdWith판매자(string id)
        {
            var 판매자상품 = await _repository.GetByIdWith판매자(id);
            if (판매자상품 == null)
                return NotFound();

            return Ok(판매자상품);
        }

        [HttpGet("{id}/판매자와주문")]
        public async Task<IActionResult> GetByIdWith판매자And주문(string id)
        {
            var 판매자상품 = await _repository.GetByIdWith판매자And주문(id);
            if (판매자상품 == null)
                return NotFound();

            return Ok(판매자상품);
        }
        [HttpGet("price/above/{price}")]
        public async Task<IActionResult> GetByPriceAbove(double price)
        {
            var 판매자상품List = await _repository.GetByPriceAbove(price);
            return Ok(판매자상품List);
        }

        [HttpGet("price/below/{price}")]
        public async Task<IActionResult> GetByPriceBelow(double price)
        {
            var 판매자상품List = await _repository.GetByPriceBelow(price);
            return Ok(판매자상품List);
        }

        [HttpGet("price/range/{minPrice}/{maxPrice}")]
        public async Task<IActionResult> GetByPriceInRange(double minPrice, double maxPrice)
        {
            var 판매자상품List = await _repository.GetByPriceInRange(minPrice, maxPrice);
            return Ok(판매자상품List);
        }

        [HttpGet("saledate/before/{date}")]
        public async Task<IActionResult> GetBySaleDateBefore(string date)
        {
            var 판매자상품List = await _repository.GetBySaleDateBefore(date);
            return Ok(판매자상품List);
        }

        [HttpGet("saledate/after/{date}")]
        public async Task<IActionResult> GetBySaleDateAfter(string date)
        {
            var 판매자상품List = await _repository.GetBySaleDateAfter(date);
            return Ok(판매자상품List);
        }

        [HttpGet("saledate/range/{startDate}/{endDate}")]
        public async Task<IActionResult> GetBySaleDateRange(string startDate, string endDate)
        {
            var 판매자상품List = await _repository.GetBySaleDate(startDate, endDate);
            return Ok(판매자상품List);
        }
    }
}
