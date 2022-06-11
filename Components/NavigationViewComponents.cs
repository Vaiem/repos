using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDesing.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogDesing.Components
{
    public class NavigationViewComponents : ViewComponent
    {
        IRepositoryDesign repositoryDesign { get; set; }
        public NavigationViewComponents(IRepositoryDesign repository)
        {
            repositoryDesign = repository;
        }

        public IViewComponentResult Invoke()
        {
           return View(repositoryDesign.desingsAll.Select(o => o.Name).Distinct());
        }

    }
}
