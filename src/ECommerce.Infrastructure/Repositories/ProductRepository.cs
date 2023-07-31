using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Context;
using ECommerce.Infrastructure.Repositories.EF;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : EFRepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
