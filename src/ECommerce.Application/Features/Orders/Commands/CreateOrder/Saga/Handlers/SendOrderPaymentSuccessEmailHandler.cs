using Rebus.Handlers;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder.Saga.Handlers
{
    public class SendOrderPaymentSuccessEmailHandler : IHandleMessages<SendOrderPaymentSuccessEmail>
    {
        public async Task Handle(SendOrderPaymentSuccessEmail message)
        {
            // Send payment success message

            return;
        }
    }
}
