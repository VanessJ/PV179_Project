using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Images;
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.Services.Tags;
using Bazaar.BL.Services.Users;
using Bazaar.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Bazaar.BL.Facade
{
    public class AdFacade : IAdFacade
    {
        private readonly IUserService _userService;
        private readonly IAdService _adService;
        private readonly ITagService _tagService;
        private readonly IImageService _imageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReactionService _reactionService;
        public AdFacade(IUserService userService, IAdService adService, ITagService tagService, IImageService imageService,IReactionService reactionService,
                        IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _adService = adService;
            _tagService = tagService;
            _imageService = imageService;
            _reactionService = reactionService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewAdAsync(Guid userId, IEnumerable<ImageCreateDto> imageCreateDtos, IEnumerable<Guid> tagIdS, AdCreateDto adCreateDto)
        {
            adCreateDto.Creator = await _userService.GetByIdAsync<UserDto>(userId);

            foreach (var tagId in tagIdS)
            {
                var tagDto = await _tagService.GetByIdAsync<TagDto>(tagId);
                if (tagDto == null)
                {
                    throw new ArgumentException();
                }
                adCreateDto.Tags.Add(tagDto);
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
                throw new ArgumentException();
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
            await _adService.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task EditAd(AdEditDto dto)
        {
            await _adService.UpdateAsync<AdEditDto>(dto);
        }

        public Task Browse()
        {
            throw new NotImplementedException();
        }
    }
}
