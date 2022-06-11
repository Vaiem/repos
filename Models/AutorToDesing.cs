using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDesing.Models
{
    public class AutorToDesing
    {
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        public int DesingId { get; set; }
        public Desing Desing { get; set; }
    }
}
