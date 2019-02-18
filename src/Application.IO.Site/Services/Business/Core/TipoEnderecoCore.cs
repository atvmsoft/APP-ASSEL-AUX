using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.TipoEndereco;
using Application.IO.Site.Services.Business.Insert;
using Application.IO.Site.Services.Business.Updade;
using System;

namespace Application.IO.Site.Services.Business.Core
{
    public class TipoEnderecoCore
    {
        public ReturnAction Save(TipoEnderecoModel model, Guid id)
        {
            if (model.Id != 0)
                return new TipoEnderecoUpdate().Save(model, id);
            else
                return new TipoEnderecoInsert().Save(model, id);
        }
    }
}
