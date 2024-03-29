﻿using AutoMapper;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.UnitOfWork;

namespace Bazaar.BL.Services.CRUDServices
{
    public abstract class CRUDService<TEntity> : ICRUDService
        where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<TEntity> _repository;

        public CRUDService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.GetRepository<TEntity>();
        }

        public async Task<Tdto?> GetByIdAsync<Tdto>(Guid id, params string[] includes)
        {
            TEntity? entity = await _repository.GetByIdAsync(id, includes);

            return _mapper.Map<Tdto?>(entity);
        }

        public async Task<IEnumerable<Tdto>> GetAllAsync<Tdto>(params string[] includes)
        {
            IEnumerable<TEntity> entity = await _repository.GetAsync(includes);

            return _mapper.Map<IEnumerable<Tdto>>(entity);
        }

        public async Task<Guid> CreateAsync<Tdto>(Tdto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            var id = await _repository.InsertAsync(entity);
            return id;
        }

        public async Task UpdateAsync<Tdto>(Tdto dto)
        {
            TEntity updatedEntity = _mapper.Map<TEntity>(dto);

            _repository.Update(updatedEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
