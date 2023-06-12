using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.판매자상품;
using 주문Common.Model;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 판매자상품Controller : ControllerBase
    {
        private readonly 판매자상품Repository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<판매자상품Controller> _logger;

        public 판매자상품Controller(판매자상품Repository repository, IMapper mapper, ILogger<판매자상품Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create판매자상품DTO 판매자상품DTO)
        {
            _logger.LogInformation("Create called");

            if (판매자상품DTO == null)
                return BadRequest();

            var 판매자상품 = _mapper.Map<판매자상품>(판매자상품DTO);
            await _repository.AddAsync(판매자상품);

            var created판매자상품DTO = _mapper.Map<Read판매자상품DTO>(판매자상품);
            return CreatedAtAction(nameof(GetById), new { id = created판매자상품DTO.Id }, created판매자상품DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update판매자상품DTO updated판매자상품DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated판매자상품DTO == null || id != updated판매자상품DTO.Id)
                return BadRequest();

            var existing판매자상품 = await _repository.GetAsync(id);
            if (existing판매자상품 == null)
                return NotFound();

            _mapper.Map(updated판매자상품DTO, existing판매자상품);

            await _repository.UpdateAsync(existing판매자상품);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing판매자상품 = await _repository.GetAsync(id);
            if (existing판매자상품 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation($"GetById called with ID: {id}");

            var 판매자상품 = await _repository.GetAsync(id);
            if (판매자상품 == null)
                return NotFound();

            var 판매자상품DTO = _mapper.Map<Read판매자상품DTO>(판매자상품);
            return Ok(판매자상품DTO);
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
