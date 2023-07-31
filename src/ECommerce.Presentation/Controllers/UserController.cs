using ECommerce.Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            await _mediator.Send(request);

            return Ok("Tamamlandý.");
        }
    }
}
