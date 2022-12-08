using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace Bazaar.Infrastructure.Query
{
    public abstract class Query<TEntity> : IQuery<TEntity> where TEntity : class, new()
    {
        protected IQueryable<TEntity> _query;


        public Query<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            _query = _query.Where(predicate);
            return this;
        }

        public Query<TEntity> Page(int page, int pageSize)
        {
            _query = _query.Skip((page - 1) * pageSize).Take(pageSize);
            return this;
        }

        public Query<TEntity> OrderBy(string selector, bool ascending = true)
        {
            _query = ascending switch
            {
                true => _query.OrderBy($"{selector} ASC"),
                false => _query.OrderBy($"{selector} DESC"),
            };
            return this;
        }

        public abstract Task<IEnumerable<TEntity>> ExecuteAsync(params string[] includes);
    }
}

