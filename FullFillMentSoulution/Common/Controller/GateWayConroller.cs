using AutoMapper;
using Common.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Common.Controller
{
    public class GateWayCommandConroller<T> : ControllerBase where T : CudDTO
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        public GateWayCommandConroller(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
