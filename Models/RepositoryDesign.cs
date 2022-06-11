using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogDesing.Models
{
    public class RepositoryDesign : IRepositoryDesign
    {
        DbContextAll Context;
        public RepositoryDesign(DbContextAll contextAll)
        {
            Context = contextAll;
        }

        public IQueryable<Desing> desingsAll => Context.desings.Include(o => o.AutorToDesign).ThenInclude(o => o.Autor);

        public void AddDesign(Desing desing)
        {
            Context.AttachRange(desing.AutorToDesign.Select(o=>o.Autor));

            if (desing.DesingId==0)
            {
                Context.Add(desing);
            }
            Context.SaveChanges();
        }
    }
}
