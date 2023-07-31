
using ECommerce.Application.Interfaces.Context;
using System.Data;

namespace ECommerce.Application.Interfaces.Uow
{
    public interface IUnitOfWork
    {
        public IECommerceContext Context { get; set; }
        public IDbTransaction BeginTransaction();
        Task SaveChangesAsync();
    }
}
