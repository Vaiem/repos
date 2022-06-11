using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogDesing.Models
{
    public class DbContextIdent : IdentityDbContext<IdentityUser>
    {
        public DbContextIdent(DbContextOptions<DbContextIdent> options) : base(options)
        {

        }
    }
}
