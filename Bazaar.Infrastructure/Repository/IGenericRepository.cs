using Bazaar.DAL.Models;

namespace Bazaar.Infrastructure.Repository
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(int id);

        Task Insert(TEntity entity);

        Task Delete(int idToDelete);

        void Update(TEntity entity);

        Task Save();
    }
}
