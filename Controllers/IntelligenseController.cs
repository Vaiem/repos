using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogDesing.Models;

namespace BlogDesing.Controllers
{
    [Route("api/[controller]")]
    public class IntelligenseController : Controller
    {
        IRepositoryDesign repositoryDesign;
        public IntelligenseController(IRepositoryDesign design)
        {
            repositoryDesign = design;
        }
        [HttpGet]
        public IEnumerable<Desing> Get() => repositoryDesign.desingsAll;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = repositoryDesign.desingsAll.FirstOrDefault(o => o.DesingId == id);
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }
      
    }
}