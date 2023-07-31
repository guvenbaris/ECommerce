using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Context;
using ECommerce.Infrastructure.Repositories.EF;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class OrderRepository : EFRepositoryBase<OrderEntity>, IOrderRepository
    {
        private readonly ECommerceDbContext _context;
        public OrderRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderEntity> GetOrderById(Guid Id)
        {
            return await _context.Orders.Include(u => u.User).Include(p => p.Product).FirstAsync(x=>x.Id == Id);
        }
    }
}
