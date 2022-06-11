using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDesing.Models
{
    public interface IRepositoryDesign
    {
        void AddDesign(Desing desing);

        IQueryable<Desing> desingsAll { get; }


    }
}
