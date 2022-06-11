using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDesing.Models
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<AutorToDesing> AutorToDesign { get; set; }

        public Autor()
        {
            AutorToDesign = new List<AutorToDesing>();
        }
            
    }
}
