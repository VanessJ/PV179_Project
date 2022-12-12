using Bazaar.App.Config;
using Bazaar.BL.Facade;
using Microsoft.AspNetCore.Identity;
using Bazaar.DAL.Data;
using Bazaar.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BazaarDBContext>();

builder.Services.AddSession(options =>
{
    //sessions hold for 20 minutes
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Register services for dependency injection
Dependencies.RegisterDependencyInjection(builder.Services);

var app = builder.Build();

//create admin account
await using (var scope = app.Services.CreateAsyncScope())
{
    CreateAdmin(scope.ServiceProvider, builder.Configuration).Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();

async Task CreateAdmin(IServiceProvider serviceProvider, IConfiguration configuration)
{
    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var adminFacade = serviceProvider.GetRequiredService<IAdminFacade>();

    var roleName = "Admin";

    var roleExist = await RoleManager.RoleExistsAsync(roleName);
    if (!roleExist)
    {
        var res = await RoleManager.CreateAsync(new IdentityRole(roleName));
    }

    var user = await UserManager.FindByEmailAsync(configuration["Admin:UserEmail"]);

    if (user != null)
    {
        await adminFacade.UpgradeUser(new Guid(user.Id));
    }
}