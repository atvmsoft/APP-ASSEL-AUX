using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using Application.IO.Site.Services.Business.Insert;
using Application.IO.Site.Services.Business.Updade;
using System;

namespace Application.IO.Site.Services.Business.Core
{
    public class AdvogadoEnderecoCore
    {
        public ReturnAction Save(AdvogadoEnderecoModel model, Guid id)
        {
            if (model.IdEnd != 0)
                return new AdvogadoEnderecoUpdate().Save(model, id);
            else
                return new AdvogadoEnderecoInsert().Save(model, id);
        }
    }
}
