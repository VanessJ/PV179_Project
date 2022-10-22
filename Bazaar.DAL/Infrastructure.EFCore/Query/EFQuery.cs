using Bazaar.DAL.Data;
using Bazaar.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Bazaar.DAL.Infrastructure.EFCore
{
    public class EFQuery<TEntity> : Query<TEntity> where TEntity : class, new()
    {
        private EFUnitOfWork _unitOfWork;

        protected EFUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = new();
                }

                return _unitOfWork;
            }
        }
        public EFQuery()
        {
            _query = UnitOfWork.Context.Set<TEntity>().AsQueryable();
        }

        public EFQuery(BazaarDBContext dbContext)
        {
            _query = dbContext.Set<TEntity>().AsQueryable();
        }

        public override async Task<IEnumerable<TEntity>> ExecuteAsync()
        {
            return await _query.ToListAsync();
        }
    }
}
