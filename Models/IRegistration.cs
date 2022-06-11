using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDesing.Models
{
    public interface IRegistration
    {

         Task AddUser(string UserName, string Password);



    }
}
