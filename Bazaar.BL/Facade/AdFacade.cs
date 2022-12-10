using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Base;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Images;
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.Services.Tags;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.UnitOfWork;
using Optional;

namespace Bazaar.BL.Facade
{
    public class AdFacade : IAdFacade
    {
        private readonly IAdService _adService;
        private readonly ITagService _tagService;
        private readonly IImageService _imageService;
        private readonly IReactionService _reactionService;
        private readonly IUnitOfWork _unitOfWork;
        public AdFacade(IAdService adService, ITagService tagService, IImageService imageService,IReactionService reactionService, IUnitOfWork unitOfWork)
        {
            _adService = adService;
            _tagService = tagService;
            _imageService = imageService;
            _reactionService = reactionService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewAdAsync(Guid userId, IEnumerable<ImageCreateDto> imageCreateDtos, IEnumerable<Guid> tagIdS, AdCreateDto adCreateDto)
        {
            adCreateDto.UserId = userId;

            if (adCreateDto.AdTags == null && tagIdS.Count() != 0)
            {
                adCreateDto.AdTags = new List<AdTagDto>();
            }

            if (adCreateDto.Images == null && imageCreateDtos.Count() != 0)
            {
                adCreateDto.Images = new List<ImageCreateDto>();
            }

            foreach (var tagId in tagIdS)
            {
                adCreateDto.AdTags.Add(new AdTagDto(){TagId = tagId});
            }

            foreach (var imageCreateDto in imageCreateDtos)
            {

                adCreateDto.Images.Add(imageCreateDto);
            }
            
            await _adService.CreateAsync<AdCreateDto>(adCreateDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> GetHigherPrice()
        {
            var ads = await _adService.ExecuteQueryAsync(new AdFilterDto() { OderCriteria = "Price".Some(), OrderAscending = false.Some() });

            return ads == null || ads.Count() == 0 ? 0 : ads.First().Price;
        }
        public async Task<IEnumerable<AdListDto>> FilterAds(AdFilterDto filterDto)
        {
            var ads = await _adService.ExecuteQueryAsync(filterDto);

            return ads;
        }

        public async Task AddReaction(ReactionCreateDto reactionCreateDto)
        {
            var ads = await _reactionService.CreateAsync(reactionCreateDto);
            await _unitOfWork.CommitAsync();
        }


        public async Task<AdDetailDto> AdDetail(Guid id)
        {
            var ad = await _adService.GetByIdAsync<AdDetailDto>(id, nameof(Ad.Creator), nameof(Ad.Reactions), nameof(Ad.AdTags), "AdTags.Tag", nameof(Ad.Images));
            if (ad == null)
            {
                throw new EntityNotFoundException();
            }
            if (ad.AdTags == null)
            {
                ad.AdTags = new List<AdTagDto>();
            }
            return ad;
        }

        public async Task<IEnumerable<TagDto>> GetAllTags()
        {
            var tags = await _tagService.GetAllAsync<TagDto>();
            return tags;
        }

        public async Task<TagDto> GetTagById(Guid tagId)
        {
            var tag = await _tagService.GetByIdAsync<TagDto>(tagId);
            return tag;
        }
        
        public async Task<IEnumerable<TagListDto>> FilterTags(TagFilterDto filterDto)
        {
            var tags = await _tagService.ExecuteQueryAsync(filterDto);
            return tags;
        }


        public async Task<IEnumerable<ReactionDto>> GetAdReactions(Guid id)
        {
            var reactions = await _adService.GetAdReactions(id);
            var reactionsWithIncludes = new List<ReactionDto>();
            foreach (var reaction in reactions)
            {
                var reactionWithIncludes = await _reactionService.GetByIdAsync<ReactionDto>(reaction.Id, nameof(Reaction.User));
                reactionsWithIncludes.Add(reactionWithIncludes);
            }
            return reactionsWithIncludes;
        }

        public async Task<IEnumerable<AdListDto>> GetOwnerAds(Guid id)
        {
            var ads = await _adService.ExecuteQueryAsync(new AdFilterDto() { UserId = id.Some() });
            if (ads == null)
            {
                throw new ArgumentException();
            }
            return ads;
        }

        public async Task SetAsInvalid(Guid id)
        {
            await _adService.SetAdAsInvalid(id);
        }

        public async Task DeclineAdReaction(Guid reactionId)
        {
            await _reactionService.DeclineReaction(reactionId);
            await _unitOfWork.CommitAsync();
        }

        public async Task AcceptAdReaction(Guid reactionId, Guid adId)
        {
            await _reactionService.AcceptReaction(reactionId);
            await _adService.SetAdAsInvalid(adId);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAd(Guid id)
        {
            var adDeleteDto = await _adService.GetByIdAsync<AdDeleteDto>(id);
            if (adDeleteDto == null)
            {
                throw new ArgumentException();
            }
            adDeleteDto.IsValid = false;
            await _adService.UpdateAsync(adDeleteDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAd(AdEditDto dto)
        {
            await _adService.UpdateAsync<AdEditDto>(dto);
            await _unitOfWork.CommitAsync();
        }

        public Task Browse()
        {
            throw new NotImplementedException();
        }
    }
}
