using Application.IO.Site.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Application.IO.Site.Models.Services.Abstractions
{
    public abstract class AbstractionContext
    {
        protected ApplicationDbContext db;

        public AbstractionContext()
        {
            var bild = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("DefaultConnection"));

            db = new ApplicationDbContext(bild.Options);
        }
    }
}
