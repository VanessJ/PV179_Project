using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Base;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.BL.Facade
{
    public interface IAdFacade
    {
        Task AddNewAdAsync(Guid userId, IEnumerable<ImageCreateDto> imageCreateDtos, IEnumerable<Guid> tagIdS, AdCreateDto adCreateDto);

        Task<IEnumerable<AdListDto>> FilterAds(AdFilterDto filterDto);

        Task<AdDetailDto> AdDetail(Guid id);

        Task<IEnumerable<ReactionDto>> GetAdReactions(Guid id);

        Task<IEnumerable<AdListDto>> GetOwnerAds(Guid id);

        Task<int> GetHigherPrice();

        Task SetAsInvalid(Guid id);

        Task AcceptAdReaction(Guid reactionId, Guid adId);

        Task DeleteAd(Guid id);

        Task EditAd(AdEditDto dto);

        Task<IEnumerable<TagDto>> GetAllTags();

        Task<TagDto> GetTagById(Guid tagId);

        Task<IEnumerable<TagListDto>> FilterTags(TagFilterDto filterDto);

        Task Browse();
    } 
}
