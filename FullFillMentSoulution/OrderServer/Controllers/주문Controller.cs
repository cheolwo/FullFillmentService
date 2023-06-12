using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCommon.Repository;
using 주문Common.DTO.For주문;
using 주문Common.Model;

namespace OrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문Controller : ControllerBase
    {
        private readonly 주문Repository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<주문Controller> _logger;

        public 주문Controller(주문Repository repository, IMapper mapper, ILogger<주문Controller> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create주문DTO 주문DTO)
        {
            _logger.LogInformation("Create called");

            if (주문DTO == null)
                return BadRequest();

            var 주문 = _mapper.Map<주문>(주문DTO);
            await _repository.AddAsync(주문);

            var created주문DTO = _mapper.Map<Read주문DTO>(주문);
            return CreatedAtAction(nameof(GetById), new { id = created주문DTO.Id }, created주문DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Update주문DTO updated주문DTO)
        {
            _logger.LogInformation($"Update called with ID: {id}");

            if (updated주문DTO == null || id != updated주문DTO.Id)
                return BadRequest();

            var existing주문 = await _repository.GetAsync(id);
            if (existing주문 == null)
                return NotFound();

            _mapper.Map(updated주문DTO, existing주문);

            await _repository.UpdateAsync(existing주문);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"Delete called with ID: {id}");

            var existing주문 = await _repository.GetAsync(id);
            if (existing주문 == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation($"GetById called with ID: {id}");

            var 주문 = await _repository.GetAsync(id);
            if (주문 == null)
                return NotFound();

            var 주문DTO = _mapper.Map<Read주문DTO>(주문);
            return Ok(주문DTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GetAll called");

            var 주문List = await _repository.ListAsync();
            var 주문DTOs = _mapper.Map<List<Read주문DTO>>(주문List);
            return Ok(주문DTOs);
        }
        [HttpGet("price/above/{price}")]
        public async Task<IActionResult> GetByPriceAbove(double price)
        {
            _logger.LogInformation($"GetByPriceAbove called with price: {price}");

            var 주문List = await _repository.GetByPriceAbove(price);
            var 주문DTOs = _mapper.Map<List<Read주문DTO>>(주문List);
            return Ok(주문DTOs);
        }

        [HttpGet("price/below/{price}")]
        public async Task<IActionResult> GetByPriceBelow(double price)
        {
            _logger.LogInformation($"GetByPriceBelow called with price: {price}");

            var 주문List = await _repository.GetByPriceBelow(price);
            var 주문DTOs = _mapper.Map<List<Read주문DTO>>(주문List);
            return Ok(주문DTOs);
        }

        [HttpGet("price/range/{minPrice}/{maxPrice}")]
        public async Task<IActionResult> GetByPriceInRange(double minPrice, double maxPrice)
        {
            _logger.LogInformation($"GetByPriceInRange called with minPrice: {minPrice}, maxPrice: {maxPrice}");

            var 주문List = await _repository.GetByPriceInRange(minPrice, maxPrice);
            var 주문DTOs = _mapper.Map<List<Read주문DTO>>(주문List);
            return Ok(주문DTOs);
        }
        [HttpGet("GetByIdWith판매자상품/{id}")]
        public async Task<IActionResult> GetByIdWith판매자상품(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자상품 called with ID: {id}");

            var 주문 = await _repository.GetByIdWith판매자상품(id);
            if (주문 == null)
                return NotFound();

            var 주문DTO = _mapper.Map<Read주문DTO>(주문);
            return Ok(주문DTO);
        }

        [HttpGet("GetByIdWith주문자/{id}")]
        public async Task<IActionResult> GetByIdWith주문자(string id)
        {
            _logger.LogInformation($"GetByIdWith주문자 called with ID: {id}");

            var 주문 = await _repository.GetByIdWith주문자(id);
            if (주문 == null)
                return NotFound();

            var 주문DTO = _mapper.Map<Read주문DTO>(주문);
            return Ok(주문DTO);
        }

        [HttpGet("GetByIdWith판매자/{id}")]
        public async Task<IActionResult> GetByIdWith판매자(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자 called with ID: {id}");

            var 주문 = await _repository.GetByIdWith판매자(id);
            if (주문 == null)
                return NotFound();

            var 주문DTO = _mapper.Map<Read주문DTO>(주문);
            return Ok(주문DTO);
        }

        [HttpGet("GetByIdWith판매자And판매자상품/{id}")]
        public async Task<IActionResult> GetByIdWith판매자And판매자상품(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자And판매자상품 called with ID: {id}");

            var 주문 = await _repository.GetByIdWith판매자And판매자상품(id);
            if (주문 == null)
                return NotFound();

            var 주문DTO = _mapper.Map<Read주문DTO>(주문);
            return Ok(주문DTO);
        }

        [HttpGet("GetByIdWith판매자And판매자상품And주문자/{id}")]
        public async Task<IActionResult> GetByIdWith판매자And판매자상품And주문자(string id)
        {
            _logger.LogInformation($"GetByIdWith판매자And판매자상품And주문자 called with ID: {id}");

            var 주문 = await _repository.GetByIdWith판매자And판매자상품And주문자(id);
            if (주문 == null)
                return NotFound();

            var 주문DTO = _mapper.Map<Read주문DTO>(주문);
            return Ok(주문DTO);
        }
    }
}
