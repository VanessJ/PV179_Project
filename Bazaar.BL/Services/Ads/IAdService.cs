using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Services.CRUDServices;
using Bazaar.DAL.Models;

namespace Bazaar.BL.Services.Ads
{
    public interface IAdService : ICRUDService
    {
        public Task SetAdAsInvalid(Guid id);

        public Task<IEnumerable<ReactionDto>> GetAdReactions(Guid id);

        public Task<IEnumerable<AdListDto>> ExecuteQueryAsync(AdFilterDto filterDto);

    }
}