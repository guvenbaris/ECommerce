using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderRequest  : IRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public bool IsApproved { get; set; } = false;
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
