using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
namespace BlogDesing.Models
{
    public class DefaultSeed
    {
        public static void Seed(IApplicationBuilder application)
         {
            DbContextAll context = application.ApplicationServices.GetRequiredService<DbContextAll>();
            context.Database.Migrate();
            context.SaveChanges();
            // @Html.Raw("<img style='width:80px; height:80px;' src=\"data:image/jpeg;base64,"
           // +Convert.ToBase64String() + "\" />"))
         }
    }
}
