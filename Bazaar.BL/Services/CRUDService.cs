using AutoMapper;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bazaar.BL.Services
{
    public abstract class CRUDService<T> where T : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public CRUDService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Tdto?> GetByIdAsync<Tdto>(int id, params string[] includes)
        {
            string entityName = typeof(T).Name;

            PropertyInfo? repositoryInfo = typeof(IUnitOfWork).GetProperty($"{entityName}Repository");

            if (repositoryInfo == null)
            {
                throw new ArgumentException();
            }
            
            IGenericRepository<T>? repository = (IGenericRepository<T>?) repositoryInfo.GetValue(_unitOfWork, null);

            if (repository == null)
            {
                throw new ArgumentException();
            }

            T entity = await repository.GetByIdAsync(id, includes);

            return _mapper.Map<Tdto?>(entity);

        }
    }
}
