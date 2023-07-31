using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Uow;
using ECommerce.Application.Models.Base;
using ECommerce.Domain.Entities;
using Rebus.Bus;
using Rebus.Handlers;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder.Saga.Handlers
{
    public class SendOrderPaymentRequestHandler : IHandleMessages<SendOrderPaymentRequest>
    {
        private readonly IBus _bus;
        private readonly IOrderRepository  _orderRepository;

        public SendOrderPaymentRequestHandler(IBus bus, IOrderRepository orderRepository)
        {
            _bus = bus;
            _orderRepository = orderRepository;
        }

        public async Task Handle(SendOrderPaymentRequest message)
        {
            var order = await _orderRepository.GetOrderById(message.OrderId);

            var chekcOrder = CheckOrder(order);

            if (chekcOrder.IsSuccess)
            {
                order.IsApproved = true;

                await _orderRepository.UpdateAsync(order);

                await _bus.Send(new OrderPaymentRequestSent(order.Id));
            }
            else
            {
                await _bus.Send(new OrderPaymentErrorEmailSent(order.Id, chekcOrder.ErrorMessage));
            }
        }

        private BaseResponseModel CheckOrder(OrderEntity order)
        {
            var responseModel = new BaseResponseModel
            {
                IsSuccess = true                
            };

            if (order == null)
            {
                responseModel.ErrorMessage = "Order not found.";
                responseModel.IsSuccess = false;
                return responseModel;
            }

            if (order!.Product == null)
            {

            }

            var product = order.Product;

            if (product!.StockQuantity == 0)
            {
                responseModel.ErrorMessage = "Product quantity not enough for order";
                responseModel.IsSuccess = false;
                return responseModel;
            }


            if (product.Price > order.User.Balance)
            {
                responseModel.ErrorMessage = "User balance not enough";
                responseModel.IsSuccess = false;
                return responseModel;
            }
            return responseModel;
        }
    }
}
