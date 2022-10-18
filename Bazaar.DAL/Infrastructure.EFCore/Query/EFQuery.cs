using Bazaar.DAL.Data;
using Bazaar.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Bazaar.DAL.Infrastructure.EFCore
{
    public class EFQuery<TEntity> : Query<TEntity> where TEntity : class, new()
    {
        private BazaarDBContext _dbContext;

        public EFQuery(BazaarDBContext dbContext)
        {
            _dbContext = dbContext;
            _query = _dbContext.Set<TEntity>().AsQueryable();
        }

        public override async Task<IEnumerable<TEntity>> ExecuteAsync()
        {
            return await _query.ToListAsync();
        }
    }
}
