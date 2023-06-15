using AutoMapper;
using Common.Cache;
using Common.DTO;
using Common.Model;
using Common.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Common.Controller
{
    public class CenterQueryController<TEntity, TDto> : EntityQueryController<TEntity, TDto>
    where TEntity : Center
    where TDto : ReadDto
    {
        private readonly ICenterQueryRepository<TEntity> _repository;
        public CenterQueryController(ICenterQueryRepository<TEntity> repository, IMapper mapper, MemoryModule<TEntity> memoryModule, ILogger<CenterQueryController<TEntity, TDto>> logger)
            : base(mapper, repository, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("address/{address}")]
        public async Task<ActionResult<TDto>> GetByAddress(string address)
        {
            try
            {
                var entity = _memoryModule.GetEntities().FirstOrDefault(e => e.Address == address);
                if (entity == null)
                {
                    entity = await _repository.GetByAddress(address);
                }

                if (entity == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<TDto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve entity by address {Address}.", address);
                return StatusCode(500, "Failed to retrieve entity.");
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<TDto>> GetByEmail(string email)
        {
            try
            {
                var entity = _memoryModule.GetEntities().FirstOrDefault(e => e.Email == email);
                if (entity == null)
                {
                    entity = await _repository.GetByEmail(email);
                }

                if (entity == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<TDto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve entity by email {Email}.", email);
                return StatusCode(500, "Failed to retrieve entity.");
            }
        }

        [HttpGet("faxNumber/{faxNumber}")]
        public async Task<ActionResult<TDto>> GetByFaxNumber(string faxNumber)
        {
            try
            {
                var entity = _memoryModule.GetEntities().FirstOrDefault(e => e.FaxNumber == faxNumber);
                if (entity == null)
                {
                    entity = await _repository.GetByFaxNumber(faxNumber);
                }

                if (entity == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<TDto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve entity by fax number {FaxNumber}.", faxNumber);
                return StatusCode(500, "Failed to retrieve entity.");
            }
        }

        [HttpGet("phoneNumber/{phoneNumber}")]
        public async Task<ActionResult<TDto>> GetByPhoneNumber(string phoneNumber)
        {
            try
            {
                var entity = _memoryModule.GetEntities().FirstOrDefault(e => e.PhoneNumber == phoneNumber);
                if (entity == null)
                {
                    entity = await _repository.GetByPhoneNumber(phoneNumber);
                }

                if (entity == null)
                {
                    return NotFound();
                }

                var dto = _mapper.Map<TDto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve entity by phone number {PhoneNumber}.", phoneNumber);
                return StatusCode(500, "Failed to retrieve entity.");
            }
        }
    }
}
