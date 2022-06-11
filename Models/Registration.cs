using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace BlogDesing.Models
{
    public class Registration : IRegistration
    {
        UserManager<IdentityUser> manageIdentity;
        SignInManager<IdentityUser> _signInManager;
        public Registration(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> sign)
        {
            manageIdentity = userManager;
            _signInManager = sign;
        }

        public async Task AddUser(string UserName, string Password)
        {
           IdentityUser user = await manageIdentity.FindByIdAsync(UserName);
            if (user == null)
            {
                var userAuth = new IdentityUser(UserName);
                if ((await manageIdentity.CreateAsync(userAuth, Password)).Succeeded)
                {
                    await _signInManager.SignInAsync(userAuth,true);
                } 
            }
        }

     
    }
}
