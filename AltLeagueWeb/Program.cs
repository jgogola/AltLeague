global using System.Data;
global using AltLeague.Models;
global using AltLeague.Models.Extensions;
global using AltLeague.Services;

using System.Security.Claims;
using AltLeague.Areas.CelebrityDeathPool.Services;
using AltLeague.Areas.League.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISQLService, SQLService>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();

builder.Services.AddScoped<ILKLeagueTypeRepository, LKLeagueTypeRepository>();
builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
builder.Services.AddScoped<IPlayerLeagueRepository, PlayerLeagueRepository>();

builder.Services.AddScoped<ILKCelebrityTypeRepository, LKCelebrityTypeRepository>();
builder.Services.AddScoped<ICelebrityRepository, CelebrityRepository>();

builder.Services.AddScoped<IPlayerCelebrityRosterRepository, PlayerCelebrityRosterRepository > ();


builder.Services.AddSession(options =>
{
    //Pulling the value idletimeout from appsettings.json to populate the session's IdleTimeout
    options.IdleTimeout = TimeSpan.FromMinutes(builder.Configuration.GetValue<int>("SessionSettings:IdleTimeout"));
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication("UserAuth_AltLeague").AddCookie("UserAuth_AltLeague", options =>
{
    options.Cookie.Name = "UserAuth_AltLeague";
    options.LoginPath = "/Home/Login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SiteAdminPolicy",
        policy => policy.RequireClaim(ClaimTypes.Role, ((int)User_Roles.Site_Admin).ToString()));

    options.AddPolicy("LeagueAdminPolicy",
        policy => policy.RequireClaim(ClaimTypes.Role, ((int)User_Roles.Site_Admin).ToString(),((int)User_Roles.League_Admin).ToString()));

    options.AddPolicy("LeaguePlayerPolicy",
        policy => policy.RequireClaim(ClaimTypes.Role,  ((int)User_Roles.Site_Admin).ToString(), ((int)User_Roles.League_Admin).ToString(), ((int)User_Roles.League_Player).ToString()));
    // policy => policy.RequireClaim(ClaimTypes.Role, new string[] { ((int)User_Roles.Site_Admin).ToString(), ((int)User_Roles.Competition_Admin).ToString(), ((int)User_Roles.Competition_Player).ToString() }));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
