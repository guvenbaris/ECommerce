using ECommerce.Application.Features.Orders.Commands.CreateOrder.Saga;
using ECommerce.Application.Interfaces.Uow;
using ECommerce.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rebus.Bus;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _bus;

        public CreateOrderHandler(IUnitOfWork unitOfWork, IBus bus)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
        }

        public async Task Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateOrderResponse();
            var user =  await _unitOfWork.Context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "User not found";
                return;
            }

            var product = await _unitOfWork.Context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);

            if (product == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Product not found";
                return;
            }

            if (product.StockQuantity == 0)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Product quantity it's not enough.";
                return;
            }
            var order = request.Adapt<OrderEntity>();
            await _unitOfWork.Context.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            

            await _bus.Send(new OrderCreatedEvent(order.Id));
        }
    }
}
