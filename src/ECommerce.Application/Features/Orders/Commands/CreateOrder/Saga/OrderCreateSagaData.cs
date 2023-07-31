using Rebus.Sagas;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder.Saga
{
    public class OrderCreateSagaData : ISagaData
    {
        public Guid Id { get ; set; }
        public int Revision { get ; set; }
        public Guid OrderId { get; set; }
        public bool OrderConfirmationEmail { get; set; }
        public bool PaymentRequestSent { get; set; }
    }
}
