using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogDesing.Models
{
    public class ReposytoryAutor : IRepositoryAutor
    {
        private DbContextAll context;
        public ReposytoryAutor(DbContextAll cont)
        {
            context = cont;
        }

        public IQueryable<Autor> autors => context.autors.Include(o => o.AutorToDesign).ThenInclude(o => o.Desing); 

        public void AddAutor(Autor autor)
        {
            context.AttachRange(autors.Select(o => o.AutorToDesign));
            if (autor.AutorId == 0)
            {
                context.Add(autor);

            }
            context.SaveChanges();
        }
    }
}
