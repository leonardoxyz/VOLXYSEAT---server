using MediatR;
using Microsoft.AspNetCore.Mvc;
using VOLXYSEAT.API.Application.Commands.Account.Login;
using VOLXYSEAT.API.Application.Commands.Account.Register;

namespace VOLXYSEAT.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("new-user")]
        //[ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] RegisterUserCommand request)
        {
            var result = await _mediator.Send(request);
            return result ? Ok() : BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand request)
        {
            var result = await _mediator.Send(request);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
