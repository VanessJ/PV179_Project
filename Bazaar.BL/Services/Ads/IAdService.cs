using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Services.CRUDServices;

namespace Bazaar.BL.Services.Ads
{
    public interface IAdService : ICRUDService
    {
        Task SetAdAsInvalid(Guid id);

        Task<IEnumerable<ReactionDto>> GetAdReactions(Guid id);

        Task<IEnumerable<AdListDto>> ExecuteQueryAsync(AdFilterDto filterDto);

    }
}