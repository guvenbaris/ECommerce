using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IRepositoryBase<OrderEntity>
    {
        Task<OrderEntity> GetOrderById(Guid Id);
    }
}
