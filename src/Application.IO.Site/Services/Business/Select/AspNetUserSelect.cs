using Application.IO.Site.Models;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AspNetUserSelect : AbstractionContext
    {
        public ApplicationUser GetByDocument(string numDocument)
        {
            return db.Users.Where(w => w.NumDocument == numDocument).FirstOrDefault();
        }
    }
}
