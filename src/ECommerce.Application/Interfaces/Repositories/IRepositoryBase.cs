using ECommerce.Domain.Entities.Base;

namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(Guid Id);
    }
}
