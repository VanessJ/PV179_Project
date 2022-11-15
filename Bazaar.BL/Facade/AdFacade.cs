using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bazaar.BL.Facade
{
    public class AdFacade : IAdFacade
    {
        private ServiceProvider _serviceProvider;
        public AdFacade()
        {
            using var dependencies = new Dependencies();
            _serviceProvider = dependencies.ServiceProvider;
        }
        public Task AddNew(Guid userId, IEnumerable<Guid> imageIds, IEnumerable<Guid> tagIds, AdCreateDto adCreateDto)
        {
            var userService = _serviceProvider.GetService<IUserService>();
            var imageService = _serviceProvider.GetService<IImageService>();
            var tagService = _serviceProvider.GetService<ITagService>();
            var adService = _serviceProvider.GetService<IAdService>();

        }

        public Task Browse()
        {
            throw new NotImplementedException();
        }
    }
}
