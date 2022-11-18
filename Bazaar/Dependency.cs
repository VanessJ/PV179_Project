using AutoMapper;
using Bazaar.BL.Config;
using Bazaar.BL.Facade;
using Bazaar.Infrastructure.UnitOfWork;
using Bazaar.Infrastructure.EFCore.Repository;
using Bazaar.Infrastructure.EFCore.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Bazaar.BL.Services.Users;
using Bazaar.BL.Services.Tags;
using Bazaar.BL.Services.Images;
using Bazaar.BL.Services;
using Bazaar.DAL.Data;
using Bazaar.Infrastructure.EFCore.Query;
using Bazaar.Infrastructure.Query;
using Bazaar.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

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

            services.AddDbContext<BazaarDBContext>();
            services.AddSingleton<Func<BazaarDBContext>>(() => new BazaarDBContext(new DbContextOptions<BazaarDBContext>()));

            services.AddTransient(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient(typeof(IQuery<>), typeof(EFQuery<>));

            services.AddSingleton<Func<IMapper>>(() => new Mapper(new MapperConfiguration(BusinessMapperConfig.ConfigureMapping)));
            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IImageService, ImageService>();

            services.AddTransient<IAdFacade, AdFacade>();

            return services.BuildServiceProvider();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
