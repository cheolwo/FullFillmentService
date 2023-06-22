using AutoMapper;
using Common.Cache;
using Common.Controller;
using Microsoft.AspNetCore.Mvc;
using 주문Common.DTO.주문자;
using 주문Common.Model;
using 주문Common.Model.Repository;

namespace 주문QueryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 주문자QueryController : CenterQueryController<주문자, Read주문자DTO>
    {
        private readonly I주문자QueryRepository _repository;

        public 주문자QueryController(I주문자QueryRepository repository, IMapper mapper,
            MemoryModule<주문자> memoryModule, ILogger<CenterQueryController<주문자, Read주문자DTO>> logger)
            : base(repository, mapper, memoryModule, logger)
        {
            _repository = repository;
        }

        [HttpGet("{id}/with주문")]
        public async Task<ActionResult<Read주문자DTO>> GetByIdWith주문(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith주문(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문자 entity by Id '{id}' with 주문 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자 entity by Id '{id}' with 주문 from the cache.");
            }

            var dto = _mapper.Map<Read주문자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with댓글")]
        public async Task<ActionResult<Read주문자DTO>> GetByIdWith댓글(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith댓글(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문자 entity by Id '{id}' with 댓글 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자 entity by Id '{id}' with 댓글 from the cache.");
            }

            var dto = _mapper.Map<Read주문자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/with상품문의")]
        public async Task<ActionResult<Read주문자DTO>> GetByIdWith상품문의(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWith상품문의(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문자 entity by Id '{id}' with 상품문의 from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자 entity by Id '{id}' with 상품문의 from the cache.");
            }

            var dto = _mapper.Map<Read주문자DTO>(entity);
            return Ok(dto);
        }

        [HttpGet("{id}/withRelatedData")]
        public async Task<ActionResult<Read주문자DTO>> GetByIdWithRelatedData(string id)
        {
            var entity = _memoryModule.GetEntity(id);
            if (entity == null)
            {
                entity = await _repository.GetByIdWithRelatedData(id);

                if (entity == null)
                {
                    return NotFound();
                }

                _memoryModule.SetEntity(id, entity);
                _logger.LogInformation($"Fetched 주문자 entity by Id '{id}' with related data from the repository and cached the entity.");
            }
            else
            {
                _logger.LogInformation($"Retrieved 주문자 entity by Id '{id}' with related data from the cache.");
            }

            var dto = _mapper.Map<Read주문자DTO>(entity);
            return Ok(dto);
        }
    }
}
