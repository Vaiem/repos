using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlogDesing.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BlogDesing.Controllers
{
    public class HomeController : Controller
    {

        IRepositoryAutor repository;
        IRepositoryDesign ReposDesing;
        UserManager<IdentityUser> userManager;
        IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor,IRepositoryAutor repos,IRepositoryDesign reposDesign,UserManager<IdentityUser> usermanag)
        {
            repository = repos;
            ReposDesing = reposDesign;
            userManager = usermanag;
            _httpContextAccessor = httpContextAccessor;
        }
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DesignAll(string categoria, int page = 1)
        {
            int PageOneElement = 1;
            if (ReposDesing.desingsAll.Count() != 0)
            {
                int currentPage = page <= 0 ? 1 : page;
                Pagination pagin = new Pagination
                {
                    Desings = ReposDesing.desingsAll.Where(o => o.Name == categoria || categoria == null)
                    .Skip((currentPage - 1) * PageOneElement).Take(PageOneElement),
                    CountElement = PageOneElement,
                    CurrentCategoria = categoria,
                    CountElementColection = ReposDesing.desingsAll.Where(o => o.Name == categoria || categoria == null).Count(),
                    categoryAll = ReposDesing.desingsAll.Select(o => o.Name).Distinct()
                };
                ViewBag.CurrentPage = currentPage;
                return View(pagin);
            }
            return RedirectToAction("AddDesign");
        }
        [HttpGet]
        public async Task<IActionResult> AddDesign()
        {
            var CurrentUser = await userManager.GetUserAsync(HttpContext.User);
            if (CurrentUser != null)
            {
                
                    return View(new Desing { Autor = CurrentUser.UserName });
                             

            }

            return Redirect("~/Account/Login");
        }
        [HttpPost]
        public IActionResult AddDesign(string desing, IFormFile uploadedFile )
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.Name != null)
                { 
                    var CreatePhoto = new DisignCreate(desing,uploadedFile);
                    var newDesign = CreatePhoto.GetDesing;
                    newDesign.Autor = User.Identity.Name;
                    newDesign.Date = DateTime.Now;
                    //AutorToDesing autorTodesign = new AutorToDesing {
                     //   Autor = repository.autors.FirstOrDefault(o => o.Name == User.Identity.Name),
                     //   Desing = newDesign
                  //  };
                   // newDesign.AutorToDesign.Add(autorTodesign);
                    ReposDesing.AddDesign(newDesign);
                    return RedirectToAction("DesignAll");
                }
            }

            return View();
           
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddFavorites(int id)
        {
            var result = ReposDesing.desingsAll.FirstOrDefault(o => o.DesingId == id);

            if (result != null)
            {
                AutorToDesing autorTodesign = new AutorToDesing {
                       
                       Desing = result
                    };
                var userDb = repository.autors.FirstOrDefault(o => o.Email == User.Identity.Name);
                if (userDb != null)
                {
                    autorTodesign.Autor = userDb;
                    userDb.AutorToDesign.Add(autorTodesign);
                    repository.AddAutor(userDb);
                }
                else
                {
                    var newAutor = new Autor {
                        Name = User.Identity.Name,
                        Email = User.Identity.Name
                    };
                    autorTodesign.Autor = newAutor;
                    newAutor.AutorToDesign.Add(autorTodesign);
                    repository.AddAutor(newAutor);
                }
            }

            return RedirectToAction("DesignAll");
        }

        public IActionResult Favorits()
        {
            if (User.Identity.Name != null)
            {
                var result = repository.autors.FirstOrDefault(o => o.Email == User.Identity.Name);
                return View(result.AutorToDesign);
            }
            return RedirectToAction("Home");
        }

    }

}