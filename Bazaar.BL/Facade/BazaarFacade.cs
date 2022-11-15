using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class BazaarFacade : IBazaarFacade
    {
        private ServiceProvider _serviceProvider;
        public BazaarFacade(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task AddNewAdd(IEnumerable<ImageCreateDto> imageDtos, IEnumerable<TagCreateDto> tagDtos, AdCreateDto adCreateDto)
        {
            var imageService = _serviceProvider.GetService<IImageService>();
            var tagService = _serviceProvider.GetService<ITagService>();
            var adService = _serviceProvider.GetService<IAdService>();
            var uow = _serviceProvider.GetService<IUnitOfWork>();

            foreach (var image in imageDtos)
            {
                await imageService.CreateAsync<ImageCreateDto>(image);
            }

            foreach (var tag in tagDtos)
            {
                await tagService.CreateAsync<TagCreateDto>(tag);
            }

            await adService.CreateAsync<AdCreateDto>(adCreateDto);
            await uow.CommitAsync();


        }

        public Task Browse()
        {
            throw new NotImplementedException();
        }
    }
}
