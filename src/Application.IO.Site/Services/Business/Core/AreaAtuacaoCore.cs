using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.AreaAtuacao;
using Application.IO.Site.Services.Business.Insert;
using Application.IO.Site.Services.Business.Updade;
using System;

namespace Application.IO.Site.Services.Business.Core
{
    public class AreaAtuacaoCore
    {
        public ReturnAction Save(AreaAtuacaoModel model, Guid id)
        {
            if (model.Id != 0)
                return new AreaAtuacaoUpdate().Save(model, id);
            else
                return new AreaAtuacaoInsert().Save(model, id);
        }
    }
}
