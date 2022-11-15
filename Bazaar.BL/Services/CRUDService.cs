using AutoMapper;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.UnitOfWork;

namespace Bazaar.BL.Services
{
    public abstract class CRUDService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<TEntity> _repository;

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
            TEntity? entity = await _repository.GetByIdAsync(id, includes);

            return _mapper.Map<Tdto?>(entity);
        }

        public async Task<IEnumerable<Tdto>> GetAllAsync<Tdto>()
        {
            IEnumerable<TEntity> entity = await _repository.GetAsync();

            return _mapper.Map<IEnumerable<Tdto>>(entity);
        }

        public async Task CreateAsync<Tdto>(Tdto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            await _repository.InsertAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync<Tdto>(Guid id, Tdto dto)
        {
            TEntity updatedEntity = _mapper.Map<TEntity>(dto);
            
            _repository.Update(updatedEntity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync<Tdto>(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

    }
}
