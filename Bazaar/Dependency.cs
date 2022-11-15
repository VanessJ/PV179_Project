using Bazaar.BL.Facade;
using Bazaar.Infrastructure.UnitOfWork;
using Bazaar.Infrastructure.EFCore;
using Bazaar.Infrastructure.EFCore.Repository;
using Bazaar.Infrastructure.EFCore.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Bazaar.BL.Services.Users;
using Bazaar.BL.Services.Tags;
using Bazaar.BL.Services.Images;
using Bazaar.BL.Services.Users;
using Bazaar.BL.Services;

namespace Bazaar
{
    public class Dependencies : IDisposable
    {
        private ServiceProvider _serviceProvider;

        public ServiceProvider ServiceProvider
        {
            get => _serviceProvider;
        }

        public Dependencies()
        {
            _serviceProvider = RegisterDependencyInjection();
        }
        private ServiceProvider RegisterDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddScoped<IBazaarFacade,BazaarFacade>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            return services.BuildServiceProvider();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
