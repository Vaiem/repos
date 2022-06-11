using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDesing.Models
{
    public class Pagination
    {
        public IEnumerable<Desing> Desings;

        public int CountElementColection { get; set; }

        public int allCountPage => (int)Math.Ceiling((decimal)CountElementColection / CountElement);

        public int CountElement { get; set; }
       
        public string CurrentCategoria { get; set; }

         public IEnumerable<string> categoryAll { get; set; }
    }
}
