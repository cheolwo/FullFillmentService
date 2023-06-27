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
    }
}
