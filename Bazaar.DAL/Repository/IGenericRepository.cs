using Bazaar.DAL.Models;

namespace Bazaar.DAL.Repository
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(Guid id);

        Task Insert(TEntity entity);

        Task Delete(Guid idToDelete);

        void Update(TEntity entity);

        Task Save();
    }
}
