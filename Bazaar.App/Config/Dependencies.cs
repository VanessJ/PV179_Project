
using Bazaar.BL.Facade;
using Bazaar.BL.QueryObjects.Ads;
using Bazaar.BL.QueryObjects.Tags;
using Bazaar.BL.QueryObjects.Users;
using Bazaar.BL.Services;
using Bazaar.BL.Services.Ads;
using Bazaar.BL.Services.Images;
using Bazaar.BL.Services.Reactions;
using Bazaar.BL.Services.Reviews;
using Bazaar.BL.Services.Tags;
using Bazaar.BL.Services.Users;
using Bazaar.DAL.Data;
using Bazaar.Infrastructure.EFCore.Query;
using Bazaar.Infrastructure.EFCore.Repository;
using Bazaar.Infrastructure.EFCore.UnitOfWork;
using Bazaar.Infrastructure.Query;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.UnitOfWork;

namespace Bazaar.App.Config
{
    public static class Dependencies
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            services.AddDbContext<BazaarDBContext>();
            //builder.Services.AddTransient<DbContext>(x => x.GetRequiredService<BazaarDBContext>());
            services.AddTransient<IConfigurationBuilder, ConfigurationBuilder>();

            services.AddAutoMapper(typeof(BusinessMapperConfig), typeof(PresentationMapperConfig));

            services.AddTransient(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient(typeof(IQuery<>), typeof(EFQuery<>));


            services.AddTransient<IUserQueryObject, UserQueryObject>();
            services.AddTransient<ITagQueryObject, TagQueryObject>();
            services.AddTransient<IAdQueryObject, AdQueryObject>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IReactionService, ReactionService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IReactionService, ReactionService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IAdService, AdService>();


            services.AddTransient<IAdFacade, AdFacade>();
            services.AddTransient<IAdminFacade, AdminFacade>();
            services.AddTransient<IUserFacade, UserFacade>();
        }
    }
}
