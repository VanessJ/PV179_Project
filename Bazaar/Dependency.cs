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
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.Services.Reviews;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Dtos.Tag;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Bazaar.BL.QueryObjects.Ads;
using Bazaar.BL.QueryObjects.Tags;
using Bazaar.BL.QueryObjects.Users;

namespace BazaarDI
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

            services.AddAutoMapper(BusinessMapperConfig.ConfigureMapping);
            //services.AddSingleton<Func<IMapper>>(() => new Mapper(new MapperConfiguration(BusinessMapperConfig.ConfigureMapping)));


            services.AddTransient<IUserQueryObject, UserQueryObject>();
            services.AddTransient<ITagQueryObject, TagQueryObject>();
            services.AddTransient<IAdQueryObject, AdQueryObject>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IReactionService, ReactionService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IAdService, AdService>();


            services.AddTransient<IAdFacade, AdFacade>();

            return services.BuildServiceProvider();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
