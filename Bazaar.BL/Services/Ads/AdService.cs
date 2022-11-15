using AutoMapper;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.QueryObjects;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;

namespace Bazaar.BL.Services.Ads
{
    public class AdService : CRUDService<Ad>, IAdService
    {
        private readonly AdQueryObject _adQueryObject;
        public AdService(IUnitOfWork unitOfWork, IMapper mapper, AdQueryObject adQueryObject) : base(unitOfWork, mapper)
        {
            _adQueryObject = adQueryObject;
        }

        public async Task<IEnumerable<AdListDto>> GetAdsByName(string userName)
        {
            return await _adQueryObject.ExecuteQueryAsync(new AdFilterDto { ContainsTitleName = userName });
        }

        public async Task<IEnumerable<AdListDto>> AdsContainDesctiption(string description)
        {
            return await _adQueryObject.ExecuteQueryAsync(new AdFilterDto { ContainsInDescription = description });
        }

        public async Task<IEnumerable<ReactionDto>> GetAdReactions(Guid id)
        {
            var ad = await GetByIdAsync<AdDto>(id, nameof(Ad.Reactions));
            return ad.Reactions;
        }

        public async Task<IEnumerable<AdListDto>> ExecuteQueryAsync(AdFilterDto filterDto)
        {
            return await _adQueryObject.ExecuteQueryAsync(filterDto);
        }
    }
}
