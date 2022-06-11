using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDesing.Models
{
    public interface IRepositoryAutor
    {

        IQueryable<Autor> autors { get; }

        void AddAutor(Autor autor);

        

    }
}
