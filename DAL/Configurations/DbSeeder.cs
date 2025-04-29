using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DAL.Configurations;

public static class DbSeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        
        await context.Database.EnsureCreatedAsync();

        string[] roleNames = ["Admin", "User"];
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new AppRole { Name = roleName });
            }
        }

        var adminEmail = configuration["SeedData:AdminEmail"] 
            ?? throw new InvalidOperationException("AdminEmail is not configured in appsettings.json");
        var adminPassword = configuration["SeedData:AdminPassword"] 
            ?? throw new InvalidOperationException("AdminPassword is not configured in appsettings.json");
        var userName = configuration["SeedData:AdminUserName"] 
            ?? throw new InvalidOperationException("AdminUserName is not configured in appsettings.json");
        var dateOfBirthStr = configuration["SeedData:AdminDateOfBirth"];
        DateTime? dateOfBirth = null;
        
        if (DateTime.TryParse(dateOfBirthStr, out var parsedDate))
        {
            dateOfBirth = DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);
        }

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new AppUser
            {
                UserName = userName,
                Email = adminEmail,
                EmailConfirmed = true,
                DateOfBirth = dateOfBirth
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
} 