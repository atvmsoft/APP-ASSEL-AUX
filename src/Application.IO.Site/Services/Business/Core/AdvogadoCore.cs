using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using Application.IO.Site.Services.Business.Insert;
using Application.IO.Site.Services.Business.Updade;
using System;

namespace Application.IO.Site.Services.Business.Core
{
    public class AdvogadoCore
    {
        public ReturnAction Save(AdvogadoModel model, Guid id)
        {
            if (model.Id != 0)
                return new AdvogadoUpdate().Save(model, id);
            else
                return new AdvogadoInsert().Save(model, id);
        }
    }
}
