using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DAL;
using DAL.Configurations;
using DAL.UOW;
using DAL.UOW.Interfaces;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// used for older style [Column(TypeName = "jsonb")] for LangStr
#pragma warning disable CS0618 // Type or member is obsolete
NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
#pragma warning restore CS0618 // Type or member is obsolete

Console.WriteLine(builder.Environment.EnvironmentName);

if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options
            .UseNpgsql(
                connectionString,
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            )
            // disable tracking, allow id based shared entity creation
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
    );
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options
            .UseNpgsql(
                connectionString,
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            )
            .ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            // disable tracking, allow id based shared entity creation
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
    );
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IAppUow, AppUow>();

builder.Services.AddIdentity<AppUser, AppRole>(o =>
        o.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services
    .AddAuthentication()
    .AddCookie(options => { options.SlidingExpiration = true; })
    .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            //options.SaveToken = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = builder.Configuration["JWTSecurity:Issuer"],
                ValidAudience = builder.Configuration["JWTSecurity:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["JWTSecurity:Key"]!)),
                ClockSkew = TimeSpan.Zero
            };
        }
    );

builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
        policy.SetIsOriginAllowed((host) => true);
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("CorsAllowAll");

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
    .WithStaticAssets();

app.Run();