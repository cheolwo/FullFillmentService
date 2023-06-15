using AutoMapper;
using Common.Cache;
using Common.DTO;
using Common.Model;
using Common.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Common.Controller
{
    public class CommodityQueryController<TEntity, TDto> : EntityQueryController<TEntity, TDto>
    where TEntity : Commodity
    where TDto : ReadDto
    {
        private readonly ICommodityQueryRepository<TEntity> _repository;
        public CommodityQueryController(ICommodityQueryRepository<TEntity> repository, IMapper mapper, MemoryModule<TEntity> memoryModule, ILogger<CommodityQueryController<TEntity, TDto>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("quantity/greaterThan/{quantity}")]
        public async Task<ActionResult<List<TDto>>> GetByQuantityGreaterThan(string quantity)
        {
            try
            {
                var entities = _memoryModule.GetEntities().Where(e => int.TryParse(e.Quantity, out var q) && q > int.Parse(quantity)).ToList();
                if (!entities.Any())
                {
                    entities = await _repository.GetByQuantityGreaterThanAsync(quantity);
                }
                var dtos = _mapper.Map<List<TDto>>(entities);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve entities by quantity greater than {Quantity}.", quantity);
                return StatusCode(500, "Failed to retrieve entities.");
            }
        }

        [HttpGet("quantity/lessThan/{quantity}")]
        public async Task<ActionResult<List<TDto>>> GetByQuantityLessThan(string quantity)
        {
            try
            {
                var entities = _memoryModule.GetEntities().Where(e => int.TryParse(e.Quantity, out var q) && q < int.Parse(quantity)).ToList();
                if (!entities.Any())
                {
                    entities = await _repository.GetByQuantityLessThanAsync(quantity);
                }
                var dtos = _mapper.Map<List<TDto>>(entities);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve entities by quantity less than {Quantity}.", quantity);
                return StatusCode(500, "Failed to retrieve entities.");
            }
        }

        [HttpGet("quantity/between/{minValue}/{maxValue}")]
        public async Task<ActionResult<List<TDto>>> GetByQuantityBetween(string minValue, string maxValue)
        {
            try
            {
                var entities = _memoryModule.GetEntities().Where(e => int.TryParse(e.Quantity, out var q) && q >= int.Parse(minValue) && q <= int.Parse(maxValue)).ToList();
                if (!entities.Any())
                {
                    entities = await _repository.GetByQuantityBetweenAsync(minValue, maxValue);
                }
                var dtos = _mapper.Map<List<TDto>>(entities);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve entities by quantity between {MinValue} and {MaxValue}.", minValue, maxValue);
                return StatusCode(500, "Failed to retrieve entities.");
            }
        }
    }
}
