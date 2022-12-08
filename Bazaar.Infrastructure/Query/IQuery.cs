using System.Linq.Expressions;

namespace Bazaar.Infrastructure.Query
{
    public interface IQuery<TEntity> where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> ExecuteAsync(params string[] includes);
        Query<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        Query<TEntity> OrderBy(string selector, bool ascending = true);
        Query<TEntity> Page(int page, int pageSize);
    }
}
