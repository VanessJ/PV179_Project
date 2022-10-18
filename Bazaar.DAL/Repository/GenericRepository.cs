using Microsoft.EntityFrameworkCore;
using Bazaar.DAL.Models;
using Bazaar.DAL.Data;

namespace Bazaar.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private BazaarDBContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(BazaarDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task Delete(int idToDelete)
        {
            var entityToDelete = await _dbSet.FindAsync(idToDelete);

            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbContext.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }


        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

    }
}
