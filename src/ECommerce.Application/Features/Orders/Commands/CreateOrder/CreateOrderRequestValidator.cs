using FluentValidation;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            // Kurallar yazılacak
        }
    }
}
