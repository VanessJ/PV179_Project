using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.DAL.Models;

namespace Bazaar.BL.Services.Ads
{
    public interface IAdService : ICRUDService
    {
        public Task<IEnumerable<AdListDto>> GetAdsByName(string userName);
        public
            Task<IEnumerable<AdListDto>> AdsContainDesctiption(string description);

        public Task<IEnumerable<ReactionDto>> GetAdReactions(Guid id);

        public Task<IEnumerable<AdListDto>> ExecuteQueryAsync(AdFilterDto filterDto);

    }
}