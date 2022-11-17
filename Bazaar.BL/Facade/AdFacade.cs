using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Images;
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
        public AdFacade(IUserService userService, IAdService adService, ITagService tagService, IImageService imageService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _adService = adService;
            _tagService = tagService;
            _imageService = imageService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewAdAsync(Guid userId, IEnumerable<ImageCreateDto> imageCreateDtos, IEnumerable<Guid> tagIdS, AdCreateDto adCreateDto)
        {
            adCreateDto.Creator = await _userService.GetByIdAsync<UserDto>(userId);

            foreach (var tagId in tagIdS)
            {
                var tagDto = await _tagService.GetByIdAsync<TagDto>(tagId);
                adCreateDto.Tags.Add(tagDto);
            }

            foreach (var imageCreateDto in imageCreateDtos)
            {
                adCreateDto.Images.Add(imageCreateDto);
            }

            await _adService.CreateAsync<AdCreateDto>(adCreateDto);
            await _unitOfWork.CommitAsync();
        }

        public Task Browse()
        {
            throw new NotImplementedException();
        }
    }
}
