using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedWebsite.Models
{
    public static class IdentityHelper
    {
        public const string Instructor = "Instructor";
        public const string Student = "Student";

        /// <summary>
        /// Sets the IdentityOptions 
        /// </summary>
        /// <param name="options"></param>
        public static void SetIdentityOptions(IdentityOptions options)
        {
            // sign in options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            // password options
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;

            // lock out options
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 5;
        }
        /// <summary>
        /// Creates roles passed in as strings
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = 
                provider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                // creates role if it does not exist
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        internal static async Task CreateDefaultInstructor(IServiceProvider serviceProvider)
        {
            const string email = "computerprogramming@cptc.edu";
            const string username = "instructor";
            const string password = "programming";

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            // check if any users are in the database
            if(userManager.Users.Count() == 0)
            {
                IdentityUser instructor = new IdentityUser()
                {
                    Email = email,
                    UserName = username,
                };
                // create the instructor
                await userManager.CreateAsync(instructor, password);
                // add them to instructor role
                await userManager.AddToRoleAsync(instructor, Instructor);
            }
        }
    }
}
