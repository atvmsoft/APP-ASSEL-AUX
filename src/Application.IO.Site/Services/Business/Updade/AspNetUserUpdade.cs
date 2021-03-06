﻿using Application.IO.Site.Models.ManageViewModels;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
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

        public ReturnAction Save(Guid idUser, IndexViewModel model)
        {
            var retorno = new ReturnAction();

            var obj = db.Users.AsNoTracking().Where(w => w.Id == idUser).FirstOrDefault();

            if (obj == null) retorno.Mensagens.Add("Usuário não encontrado");
            else if (!CpfDocumentValid(model.NumDocument)) retorno.Mensagens.Add("CPF inválido");

            if (!retorno.Valido) return retorno;

            obj.Name = tCase.ToTitleCase(model.Name);
            obj.NumDocument = model.NumDocument;
            obj.Email = model.Email.ToLower();

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return retorno;
        }
    }
}
