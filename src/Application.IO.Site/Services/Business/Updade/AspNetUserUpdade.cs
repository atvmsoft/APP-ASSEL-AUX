using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.IO.Site.Services.Business.Updade
{
    public class AspNetUserUpdade : AbstractionContext
    {
        public DomainNotification DateAccountConfirm(Guid idUser)
        {
            var user = db.Users.Where(w => w.Id == idUser).FirstOrDefault();
            if (user == null)
                return new DomainNotification("User", "Usuário não localizado");

            user.UserEmailConfirm = DateTime.Now;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            return null;
        }
    }
}
