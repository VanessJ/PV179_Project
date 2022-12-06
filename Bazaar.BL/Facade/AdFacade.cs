using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Images;
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.Services.Tags;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.UnitOfWork;

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

            foreach (var tagId in tagIdS)
            {
                adCreateDto.AdTags.Add(new AdTagDto(){TagId = tagId});
            }

            if (adCreateDto.Images == null && imageCreateDtos.Count() != 0)
            {
                adCreateDto.Images = new List<ImageCreateDto>();
            }

            foreach (var imageCreateDto in imageCreateDtos)
            {
                await _imageService.CreateAsync<ImageCreateDto>(imageCreateDto);
                adCreateDto.Images.Add(imageCreateDto);
            }
            
            await _adService.CreateAsync<AdCreateDto>(adCreateDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<AdListDto>> FilterAds(AdFilterDto filterDto)
        {
            var ads = await _adService.ExecuteQueryAsync(filterDto);
            return ads;
        }

        public async Task<AdDetailDto> AdDetail(Guid id)
        {
            var ad = await _adService.GetByIdAsync<AdDetailDto>(id);
            if (ad == null)
            {
                throw new EntityNotFoundException();
            }
            return ad;
        }


        public async Task<IEnumerable<ReactionDto>> GetAdReactions(Guid id)
        {
            var reactions = await _adService.GetAdReactions(id);
            return reactions;
        }

        public async Task<AdOwnerDetailDto> AdDetailForOwner(Guid id)
        {
            var ad = await _adService.GetByIdAsync<AdOwnerDetailDto>(id);
            if (ad == null)
            {
                throw new ArgumentException();
            }
            return ad;
        }

        public async Task SetAsInvalid(Guid id)
        {
            await _adService.SetAdAsInvalid(id);
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
