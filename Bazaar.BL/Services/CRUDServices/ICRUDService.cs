namespace Bazaar.BL.Services.CRUDServices
{
    public interface ICRUDService
    {
        public Task<Tdto?> GetByIdAsync<Tdto>(Guid id, params string[] includes);

        public Task<IEnumerable<Tdto>> GetAllAsync<Tdto>();

        public Task<Guid> CreateAsync<Tdto>(Tdto dto);
        public Task UpdateAsync<Tdto>(Tdto dto);
        public Task DeleteAsync(Guid id);
    }
}
