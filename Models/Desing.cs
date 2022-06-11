using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace BlogDesing.Models
{
    public class Desing
    {
        public int DesingId { get; set; } 

        [Required]
        public string Name { get; set; }

        
        public string Autor { get; set; }

        
        public DateTime Date { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] PhotoOne {get;set;}


        [JsonIgnore]
        public ICollection<AutorToDesing> AutorToDesign { get; set; }

        public Desing()
        {
            AutorToDesign = new List<AutorToDesing>();
        }

    }
}
