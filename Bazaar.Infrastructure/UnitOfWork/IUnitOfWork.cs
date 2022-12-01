using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Repository;

namespace Bazaar.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity;

        public Task CommitAsync();
    }
}
