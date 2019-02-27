using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using Application.IO.Site.Services.Business.Insert;
using Application.IO.Site.Services.Business.Updade;
using System;

namespace Application.IO.Site.Services.Business.Core
{
    public class AdvogadoContatoCore
    {
        public ReturnAction Save(AdvogadoContatoModel model, Guid id)
        {
            if (model.Id != 0)
                return new AdvogadoContatoUpdate().Save(model, id);
            else
                return new AdvogadoContatoInsert().Save(model, id);
        }
    }
}
