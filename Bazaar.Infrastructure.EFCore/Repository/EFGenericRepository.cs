using Microsoft.EntityFrameworkCore;
using Bazaar.Infrastructure.Repository;
using Bazaar.DAL.Models;
using Bazaar.DAL.Data;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Bazaar.Infrastructure.EFCore.Repository
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private BazaarDBContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public EFGenericRepository(BazaarDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task DeleteAsync(Guid idToDelete)
        {
            var entityToDelete = await _dbSet.FindAsync(idToDelete);

            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbContext.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(params string[] includes)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();
            if (!includes.IsNullOrEmpty())
            {
                foreach (var include in includes)
                {
                    queryable = queryable.Include($"{include}");
                }
            }

            return await queryable.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, params string[] includes)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();
            if (!includes.IsNullOrEmpty())
            {
                foreach (var include in includes)
                {
                    queryable = queryable.Include($"{include}");
                }
            }
            return await queryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Guid> InsertAsync(TEntity entity)
        {
            if (entity.Id == null || entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            await _dbSet.AddAsync(entity);
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

    }
}
