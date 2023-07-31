using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Interfaces.Context
{
    public interface IECommerceContext 
    {
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
