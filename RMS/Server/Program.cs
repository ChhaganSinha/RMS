using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using RMS.DataContext.Models;
using RMS.DataContext;
using RMS.Repositories;
using RMS.Server.Intrastructure;
using Serilog;
using System;
using RMS.Server.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables(prefix: "ASPNETCORE_");

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

var config = (IConfiguration)builder.Configuration;

builder.Services.AddLogging((builder) =>
{
    Serilog.Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
    builder.AddSerilog();
});

builder.Services.AddControllers()
    .AddODataControllers()
    .AddNewtonsoftJson();

builder.Services.AddHttpContextAccessor();

var useSqlLite = builder.Configuration.GetValue<bool>("UseSqlLite");
var sqlLiteAssetAuthConn = builder.Configuration.GetValue<string>("SqlLiteAuthConnectionString");
var sqlLiteAssetConn = builder.Configuration.GetValue<string>("SqlLiteAssetConnectionString");

var conStringAuth = builder.Configuration.GetValue<string>("ConnectionStrings:MySqlAuthDbConnection");
var conString = builder.Configuration.GetValue<string>("ConnectionStrings:MySqlConnection");

if (useSqlLite)
{
    builder.Services.AddDbContext<AuthDbContext>(options =>
        options.UseSqlite(sqlLiteAssetAuthConn));

    builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlite(sqlLiteAssetConn));
}
else
{
    builder.Services.AddDbContext<AuthDbContext>(options =>
    {
        options.UseMySql(conStringAuth, ServerVersion.AutoDetect(conStringAuth));
    });
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySql(conString, ServerVersion.AutoDetect(conString));
    });
}

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+";
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

builder.Services.AddLogging();
builder.Services.AddScoped<BaseRepository>();
builder.Services.AddScoped<IAppRepository, AppRepository>();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();

var defaultRoles = builder.Configuration.GetSection("DefaultRoles").Get<string[]>() ?? new string[] { "SuperAdmin", "Admin" };
//var defaultUsername = builder.Configuration.GetValue<string>("DefaultUser:Username") ?? "DefaultUser";
//var defaultUserId = builder.Configuration.GetValue<string>("DefaultUser:UserId") ?? "default@RMSapp.com";
//var defaultPassword = builder.Configuration.GetValue<string>("DefaultUser:Password") ?? "Asset@2023";

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<AuthDbContext>().Database.Migrate();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (db.Database.EnsureCreated())
    {
        // seed data if a single tenant application
    }
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

    //var adminUser = await userManager.FindByNameAsync("Admin");
    //if (adminUser == null)
    //{
    //    adminUser = new ApplicationUser
    //    {
    //        UserName = defaultUsername,
    //        Email = defaultUserId
    //    };
    //    var result = await userManager.CreateAsync(adminUser, defaultPassword);
    //    if (result.Succeeded)
    //    {
    //        foreach (var roleName in defaultRoles)
    //        {
    //            var roleExists = await roleManager.RoleExistsAsync(roleName);
    //            if (!roleExists)
    //            {
    //                var role = new ApplicationRole { Name = roleName };
    //                await roleManager.CreateAsync(role);
    //            }
    //        }
    //        var addUserRoleResult = await userManager.AddToRoleAsync(adminUser, "SuperAdmin");
    //    }
    //}
}

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.Run();
