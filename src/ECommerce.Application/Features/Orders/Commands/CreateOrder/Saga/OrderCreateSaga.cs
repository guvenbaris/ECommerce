using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder.Saga
{
    public class OrderCreateSaga : Saga<OrderCreateSagaData>,
        IAmInitiatedBy<OrderCreatedEvent>,
        IHandleMessages<OrderConfirmationEmailSent>,
        IHandleMessages<OrderPaymentRequestSent>,
        IHandleMessages<OrderPaymentSuccessEmailSent>,
        IHandleMessages<OrderPaymentErrorEmailSent>
    {
        private readonly IBus _bus;

        public OrderCreateSaga(IBus bus)
        {
            _bus = bus;
        }

        protected override void CorrelateMessages(ICorrelationConfig<OrderCreateSagaData> config)
        {
            config.Correlate<OrderCreatedEvent>(m => m.OrderId, s => s.OrderId);
            config.Correlate<OrderConfirmationEmailSent>(m => m.OrderId, s => s.OrderId);
            config.Correlate<OrderPaymentRequestSent>(m => m.OrderId, s => s.OrderId);
            config.Correlate<OrderPaymentSuccessEmailSent>(m => m.OrderId, s => s.OrderId);
            config.Correlate<SendOrderPaymentSuccessEmail>(m => m.OrderId, s => s.OrderId);
            config.Correlate<SendOrderPaymentErrorEmail>(m => m.OrderId, s => s.OrderId);
        }

        public async Task Handle(OrderCreatedEvent message)
        {
            if (!IsNew)
            {
                return;
            }

            await _bus.Send(new SendOrderConfirmaitonEmail(message.OrderId));
        }

        public async Task Handle(OrderConfirmationEmailSent message)
        {
            Data.OrderConfirmationEmail = true;

            await _bus.Send(new SendOrderPaymentRequest(message.OrderId));                        
        }

        public async Task Handle(OrderPaymentRequestSent message)
        {
            Data.PaymentRequestSent = true;

            await _bus.Send(new OrderPaymentSuccessEmailSent(message.OrderId));            
        }

        public async Task Handle(OrderPaymentSuccessEmailSent message)
        {
            await _bus.Send(new SendOrderPaymentSuccessEmail(message.OrderId));

            MarkAsComplete();

            return;    
        }

        public async Task Handle(OrderPaymentErrorEmailSent message)
        {
            await _bus.Send(new SendOrderPaymentErrorEmail(message.OrderId,message.Message));

            MarkAsComplete();

            return;
        }
    }
}
