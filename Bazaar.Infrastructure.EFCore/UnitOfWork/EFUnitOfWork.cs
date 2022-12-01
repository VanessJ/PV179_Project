using Bazaar.DAL.Models;
using Bazaar.DAL.Data;
using Bazaar.Infrastructure.UnitOfWork;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.EFCore.Repository;


namespace Bazaar.Infrastructure.EFCore.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public BazaarDBContext _bazaarDbContext;

        private Dictionary<Type, object> _repositories;

        public EFUnitOfWork(BazaarDBContext bazaarDbContext)
        {
            _bazaarDbContext = bazaarDbContext;
            _repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories.Add(typeof(T), new EFGenericRepository<T>(_bazaarDbContext));
            }

            return (EFGenericRepository<T>) _repositories[typeof(T)];
        }

        public async Task CommitAsync()
        {
            await _bazaarDbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _bazaarDbContext.DisposeAsync();
        }
    }
}
