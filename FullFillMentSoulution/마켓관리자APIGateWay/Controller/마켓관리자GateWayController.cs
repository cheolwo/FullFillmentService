using AutoMapper;
using IdentityCommon.Models.ForApplicationUser;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace 마켓관리자APIGateWay.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class 마켓관리자GateWayController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _medator;
        private readonly UserManager<ApplicationUser> _userManager;
        public 마켓관리자GateWayController(UserManager<ApplicationUser> userManager,
            IMapper mapper, IMediator  mediator) 
        {
            _userManager = userManager;
            _mapper = mapper;
            _medator = mediator;
        }
    }
}
