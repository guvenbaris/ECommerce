using ECommerce.Application.Features.Products.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            await _mediator.Send(request);

            return Ok("Tamamlandı.");
        }
    }
}
