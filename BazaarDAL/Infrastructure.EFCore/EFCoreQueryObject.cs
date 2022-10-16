using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.DAL.Data;
using Bazaar.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bazaar.DAL.Infrastructure.EFCore
{
    public class EFCoreQueryObject<TEntity> : QueryObject<TEntity> where TEntity : class, new()
    {
        private BazaarDBContext _dbContext;
        private UnitOfWork.UnitOfWork _unitOfWork;

        protected UnitOfWork.UnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork != null)
                {
                    _unitOfWork = new(_dbContext);
                }

                return _unitOfWork;
            }
        }


        public EFCoreQueryObject(BazaarDBContext dbContext)
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
