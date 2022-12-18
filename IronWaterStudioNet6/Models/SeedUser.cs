using IronWaterStudioNet6.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IronWaterStudioNet6.Models
{
    public static class SeedUser
    {
        public static async Task SeedAsync(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            IConfigurationSection section 
                = configuration.GetSection("AdminUserInfo");
            var configUser = new IdentityUser {
                UserName = section.GetSection("UserName").Value,
                Email = section.GetSection("UserEmail").Value,
            };
            await userManager.CreateAsync(configUser,
                section.GetSection("UserPassword").Value);
        }
    }
}
