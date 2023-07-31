using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Context;
using ECommerce.Infrastructure.Repositories.EF;

namespace ECommerce.Infrastructure.Repositories
{
    public class UserRepository : EFRepositoryBase<UserEntity> , IUserRepository
    {
        public UserRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
