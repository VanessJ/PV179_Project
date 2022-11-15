using Bazaar.DAL.Models;

namespace Bazaar.Infrastructure.Repository
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync(Guid id, params string[] includes);

        Task InsertAsync(TEntity entity);

        Task DeleteAsync(Guid idToDelete);

        void Update(TEntity entity);

        Task SaveAsync();
    }
}
