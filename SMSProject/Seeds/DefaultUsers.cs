﻿using Microsoft.AspNetCore.Identity;
using SMSProject.Data.Consts;
using SMSProject.Models;

namespace SMSProject.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser admin = new()
            {
                UserName = "admin",
                Email = "admin@SMS.com",
                FullName = "Admin",
                EmailConfirmed = true,
                Grade = "SuperGrade"
            };

            var user = await userManager.FindByEmailAsync(admin.Email);

            if (user is null) 
            { 
                await userManager.CreateAsync(admin, "P@ssword123");
                await userManager.AddToRoleAsync(admin, AppRoles.Admin);
            }
        }
    }
}
