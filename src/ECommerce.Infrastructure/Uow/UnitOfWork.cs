using ECommerce.Application.Interfaces.Context;
using ECommerce.Application.Interfaces.Uow;
using ECommerce.Infrastructure.Context;
using System.Data;

namespace ECommerce.Infrastructure.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public IECommerceContext Context { get; set; }
        private readonly ECommerceDbContext _dbContext;

        public UnitOfWork(ECommerceDbContext context)
        {
            Context = context;
            _dbContext = context;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                var affectedRowCount = await _dbContext.SaveChangesAsync();
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

        public IDbTransaction BeginTransaction()
        {
            var transaction = _dbContext.Database.BeginTransaction();
            return (IDbTransaction)transaction;
        }
    }
}
