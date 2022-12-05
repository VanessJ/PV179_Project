using Bazaar.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Bazaar.App.Config
{
    public static class IdentityConfig
    {
        public static void Configure(IServiceCollection services)
        {

            services.AddDefaultIdentity<IdentityUser>();
        }
    }
}
