using ECommerce.Application.Interfaces.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Context
{
    public class ECommerceDbContext : DbContext, IECommerceContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }

        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
