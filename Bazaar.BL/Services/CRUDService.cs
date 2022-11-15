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
    public abstract class CRUDService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;

        public CRUDService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            var entityName = typeof(TEntity).Name;

            var repositoryInfo = typeof(IUnitOfWork).GetProperty($"{entityName}Repository");

            if (repositoryInfo == null)
            {
                throw new ArgumentException();
            }

            var repository = (IGenericRepository<TEntity>?)repositoryInfo.GetValue(_unitOfWork, null);

            if (repository == null)
            {
                throw new ArgumentException();
            }

            _repository = repository;
        }

        public async Task<Tdto?> GetByIdAsync<Tdto>(Guid id, params string[] includes)
        {
            var entity = await _repository.GetByIdAsync(id, includes);

            return _mapper.Map<Tdto?>(entity);
        }

        public async Task<Tdto?> GetAsync<Tdto>(params string[] includes)
        {
            var entity = await _repository.GetAsync(includes);

            return _mapper.Map<Tdto?>(entity);
        }
        public async Task InsertAsync(TEntity entity)
        {
            await _repository.InsertAsync(entity);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(Guid idToDelete)
        {
            await _repository.DeleteAsync(idToDelete);
            await _repository.SaveAsync();
        }
        public async Task Update(TEntity entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
        }

    }
}
