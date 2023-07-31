namespace ECommerce.Application.Features.Orders.Commands.CreateOrder.Saga
{
    public record OrderCreatedEvent(Guid OrderId);
    public record OrderConfirmationEmailSent(Guid OrderId);
    public record OrderPaymentRequestSent(Guid OrderId);
    public record OrderPaymentSuccessEmailSent(Guid OrderId);
    public record OrderPaymentErrorEmailSent(Guid OrderId,string Message);
    public record SendOrderConfirmaitonEmail(Guid OrderId);
    public record SendOrderPaymentRequest(Guid OrderId);
    public record SendOrderPaymentSuccessEmail(Guid OrderId);
    public record SendOrderPaymentErrorEmail(Guid OrderId,string message);
}
