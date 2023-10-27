using SocialNetwork.Infraestructure.Persistence;
using SocialNetwork.Infraestructure.Identity;
using SocialNetwork.Core.Application;
using SocialNetwork.Infraestructure.Identity.Entites;
using SocialNetwork.Infraestructure.Identity.Seeds;
using Microsoft.AspNetCore.Identity;
using WebApp.SocialNetwork.Middlewares;
using SocialNetwork.Infraestructure.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddScoped<LoginAuthorize>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ValidateUserSession, ValidateUserSession>();


var app = builder.Build();
app.UseSession(); 

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<AplicationUsers>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaulSuperAdminUser.SeedAsync(userManager, roleManager);
        await DefaultBasicUser.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {

    }
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
