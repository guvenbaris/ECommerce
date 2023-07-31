using Rebus.Bus;
using Rebus.Handlers;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder.Saga.Handlers
{
    public class SendOrderConfirmationEmailHandler : IHandleMessages<SendOrderConfirmaitonEmail>
    {
        private readonly IBus _bus;

        public SendOrderConfirmationEmailHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(SendOrderConfirmaitonEmail message)
        {
            // send email order your order has been received
            await _bus.Send(new OrderConfirmationEmailSent(message.OrderId));
        }
    }
}
