using Rebus.Handlers;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder.Saga.Handlers
{
    public class SendOrderPaymentErrorEmailHandler : IHandleMessages<SendOrderPaymentErrorEmail>
    {
        public async Task Handle(SendOrderPaymentErrorEmail message)
        {
            // Send error email
            return;
        }
    }
}
