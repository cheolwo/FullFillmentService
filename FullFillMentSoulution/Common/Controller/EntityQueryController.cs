using AutoMapper;
using Common.Cache;
using Common.DTO;
using Common.Model;
using Common.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Common.Controller
{
    public class EntityQueryController<TEntity, TDto> : ControllerBase where TEntity : Entity
                                                                        where TDto : ReadDto
    {
        protected readonly IMapper _mapper;
        protected readonly IEntityQueryRepository<TEntity> _entityQueryRepository;
        protected readonly MemoryModule<TEntity> _memoryModule;
        protected readonly ILogger<EntityQueryController<TEntity, TDto>> _logger;
        public EntityQueryController(IMapper mapper, IEntityQueryRepository<TEntity> entityQueryRepository,
             MemoryModule<TEntity> memoryModule, ILogger<EntityQueryController<TEntity, TDto>> logger)
        {
            _mapper = mapper;
            _entityQueryRepository = entityQueryRepository;
            _memoryModule = memoryModule;
            _logger = logger;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetById(string id)
        {
            try
            {
                TEntity entity = _memoryModule.GetEntity(id);

                if (entity == null)
                {
                    entity = await _entityQueryRepository.GetAsync(id);

                    if (entity == null)
                    {
                        _logger.LogInformation($"Entity with ID '{id}' not found.");
                        return NotFound();
                    }

                    _memoryModule.SetEntity(id, entity);
                }

                TDto dto = _mapper.Map<TDto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving entity with ID '{id}'.");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TDto>>> GetToList()
        {
            try
            {
                List<TEntity> entities = _memoryModule.LoadEntities();

                if (entities.Count == 0)
                {
                    entities = (await _entityQueryRepository.ListAsync()).ToList();
                    entities.ForEach(entity => _memoryModule.SetEntity(entity.Id, entity));
                }

                List<TDto> dtos = _mapper.Map<List<TDto>>(entities);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving entities.");
                return StatusCode(500);
            }
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<TDto>> GetByCode(string code)
        {
            try
            {
                TEntity entity = await _entityQueryRepository.GetByCode(code);

                if (entity == null)
                {
                    _logger.LogInformation($"Entity with code '{code}' not found.");
                    return NotFound();
                }

                TDto dto = _mapper.Map<TDto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving entity with code '{code}'.");
                return StatusCode(500);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<TDto>> GetByName(string name)
        {
            try
            {
                TEntity entity = await _entityQueryRepository.GetByName(name);

                if (entity == null)
                {
                    _logger.LogInformation($"Entity with name '{name}' not found.");
                    return NotFound();
                }

                TDto dto = _mapper.Map<TDto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving entity with name '{name}'.");
                return StatusCode(500);
            }
        }

        [HttpGet("any")]
        public ActionResult<bool> Any()
        {
            try
            {
                bool any = _memoryModule.LoadEntities().Any();
                return Ok(any);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking if any entities exist.");
                return StatusCode(500);
            }
        }

        [HttpGet("count")]
        public ActionResult<long> Count()
        {
            try
            {
                long count = _memoryModule.LoadEntities().Count;
                return Ok(count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while counting entities.");
                return StatusCode(500);
            }
        }

        [HttpGet("count/{property}/{value}")]
        public ActionResult<long> Count(string property, string value)
        {
            try
            {
                Expression<Func<TEntity, bool>> where = GetWhereExpression(property, value);
                long count = _memoryModule.LoadEntities().Count(where.Compile());
                return Ok(count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while counting entities with property '{property}' and value '{value}'.");
                return StatusCode(500);
            }
        }

        private Expression<Func<TEntity, bool>> GetWhereExpression(string property, string value)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "e");
            MemberExpression propertyExpression = Expression.Property(parameter, property);
            ConstantExpression valueExpression = Expression.Constant(value);
            BinaryExpression equalityExpression = Expression.Equal(propertyExpression, valueExpression);
            Expression<Func<TEntity, bool>> whereExpression = Expression.Lambda<Func<TEntity, bool>>(equalityExpression, parameter);
            return whereExpression;
        }
    }
}
