﻿using System.Linq.Expressions;

namespace Bazaar.DAL.Infrastructure
{
    public interface IQuery<TEntity> where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> ExecuteAsync();
        Query<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        Query<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> selector, bool ascending = true);
        Query<TEntity> Page(int page, int pageSize);
    }
}
