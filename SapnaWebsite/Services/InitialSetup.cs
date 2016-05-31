using Microsoft.AspNetCore.Identity;
using SapnaWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapnaWebsite.Services
{
    public class InitialSetup
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private RoleManager<Role> _roleManager;

        public InitialSetup(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task EnsureDataSetupAsync()
        {
            if(!_roleManager.Roles.Any())
            {
                Role role = new Role { Name = "Admin" };
                await _roleManager.CreateAsync(role);

                Role member = new Role { Name = "Member" };
                await _roleManager.CreateAsync(member);
            }

            if(!_userManager.Users.Any())
            {
                User user = new User { UserName = "Admin", Email = "admin@gmail.com" };
                await _userManager.CreateAsync(user, "Sapna2016");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
