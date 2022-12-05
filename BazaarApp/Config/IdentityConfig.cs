using Bazaar.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace Bazaar.App.Config
{
    public static class IdentityConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddIdentityCore<User>(x =>
            {
                x.Password.RequiredLength = 4;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
            })
                .AddDefaultTokenProviders();

            services.AddAuthentication(x =>
            {
                x.DefaultScheme = IdentityConstants.ApplicationScheme;
                x.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            })
                .AddIdentityCookies();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Identity/Login");
                opt.ExpireTimeSpan = TimeSpan.FromDays(14);
                opt.SlidingExpiration = true;
            });
        }
    }
}
