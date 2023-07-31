using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities.Base;
using ECommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories.EF
{
    public class EFRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;

        public EFRepositoryBase(DbContext context)
        {  
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public async Task<TEntity> FindByIdAsync(Guid Id)
        {
            return await _dbSet.FirstAsync(x=> x.Id == Id);
        }
        private async Task SaveChangesAsync()
        {
            try
            {
                var affectedRowCount = await _context.SaveChangesAsync();
                if (affectedRowCount == 0)
                {
                    // throw error
                }
            }
            catch (Exception ex)
            {
                // throw error
            }
        }
    }
}
