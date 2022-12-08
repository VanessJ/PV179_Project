using Bazaar.DAL.Data;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bazaar.Infrastructure.EFCore.Query
{
    public class EFQuery<TEntity> : Query<TEntity> where TEntity : BaseEntity, new()
    {
        public EFQuery(BazaarDBContext dbContext)
        {
            _query = dbContext.Set<TEntity>().AsQueryable();
        }

        public override async Task<IEnumerable<TEntity>> ExecuteAsync(params string[] includes)
        {
            if (!includes.IsNullOrEmpty())
            {
                foreach (var include in includes)
                {
                    _query = _query.Include($"{include}");
                }
            }
            return await _query.ToListAsync();
        }
    }
}
