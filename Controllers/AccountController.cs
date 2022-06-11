using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlogDesing.Models;

namespace BlogDesing.Controllers
{
  
    public class AccountController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> SignInManager;
        IRegistration Registration;
        IRepositoryAutor repositoryAutor;
        public AccountController(IRepositoryAutor repository, UserManager<IdentityUser> manage,SignInManager<IdentityUser> signInManager,IRegistration registration)
        {
            repositoryAutor = repository;
            userManager = manage;
            SignInManager = signInManager;
            Registration = registration;
        }
        [HttpGet]        
        public IActionResult Register()
        {
            return View(new LoginView());
        }
        [HttpPost]       
        public async Task<IActionResult> Register(LoginView login)
        {
            if(ModelState.IsValid)
            { 
                await Registration.AddUser(login.Name, login.Password);

                return RedirectToAction(nameof(Login));
            }
            return View();
        }

        [HttpGet]            
        public IActionResult Login()
        {
            
            return View(new LoginView());
        }
        [HttpPost]      
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginView login)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(login.Name);
                if (user != null)
                {
                    await SignInManager.SignOutAsync();
                    if((await SignInManager.PasswordSignInAsync(login.Name, login.Password,true,false)).Succeeded)
                    {
                       // repositoryAutor.AddAutor(new Autor { Name = login.Name, Password = login.Password });
                        return Redirect("~/Home/DesignAll");
                    }
                }
                else { return RedirectToAction("Register"); }
            }

            else { ModelState.AddModelError("Проверьте правильность,введеных данных", null); }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return Redirect("~/Home/Index");
        }
        
    }
}