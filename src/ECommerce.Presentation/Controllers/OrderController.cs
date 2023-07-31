using ECommerce.Application.Features.Orders.Commands.CreateOrder;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            await _mediator.Send(request);

            return Ok("Tamamlandı.");
        }
    }
}
